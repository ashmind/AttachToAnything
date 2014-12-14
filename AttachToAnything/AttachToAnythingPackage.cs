using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using AttachToAnything.Internal;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace AttachToAnything {
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPageInExistingCategory(typeof(AttachTargetOptionPage), "Debugger", "AttachToAnything", 113)]
    [Guid(GuidList.PackageString)]
    public sealed class AttachToAnythingPackage : Package {
        private AttachToAnythingController _controller;

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public AttachToAnythingPackage() {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this));
        }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize() {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this));
            base.Initialize();

            var logger = new DiagnosticLogger("AttachToAnything");

            var optionsPage = (AttachTargetOptionPage)GetDialogPage(typeof(AttachTargetOptionPage));
            _controller = new AttachToAnythingController(this, (DTE)GetService(typeof(DTE)), optionsPage, new ProcessWaitSource(logger), logger);

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var menuCommandService = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null == menuCommandService)
                return;
            
            SetupAttachCommand(menuCommandService);
            SetupOptionsCommand(menuCommandService);
        }

        private void SetupAttachCommand(OleMenuCommandService menuCommandService) {
            var dynamicItemRootId = new CommandID(GuidList.Commands, (int) CommandIDs.AttachToDynamicStub);
            var dynamicMenuCommand = new DynamicMenuCommand(
                (sender, e) => {
                    var invokedCommand = (DynamicMenuCommand)sender;
                    _controller.HandleAttachTo(invokedCommand.Text);
                },
                dynamicItemRootId,
                index => _controller.GetTargets().ElementAtOrDefault(index)
            );
            menuCommandService.AddCommand(dynamicMenuCommand);
        }

        private void SetupOptionsCommand(OleMenuCommandService menuCommandService) {
            var optionsCommandId = new CommandID(GuidList.Commands, (int)CommandIDs.Options);
            var optionsCommand = new OleMenuCommand((sender, e) => _controller.HandleOptions(), optionsCommandId);
            menuCommandService.AddCommand(optionsCommand);
        }
    }
}