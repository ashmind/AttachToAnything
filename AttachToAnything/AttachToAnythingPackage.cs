using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace AttachToAnything {
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(AttachTargetOptionPage), "Attach To Anything", "General", 100, 120, false)]
    [Guid(GuidList.AttachToAnythingPackageString)]
    public sealed class AttachToAnythingPackage : Package {
        private AttachToAnythingController controller;

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

            var optionsPage = (AttachTargetOptionPage)this.GetDialogPage(typeof(AttachTargetOptionPage));
            this.controller = new AttachToAnythingController((DTE)GetService(typeof(DTE)), optionsPage);

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null == mcs)
                return;

            var attachToCommandID = new CommandID(GuidList.AttachToAnythingCommandSet, (int)PkgCmdIDList.AttachTo);
            var attachToCommand = new OleMenuCommand(AttachToInvokeCallback, attachToCommandID) {
                ParametersDescription = "$"
            };
            mcs.AddCommand(attachToCommand);

            var attachToGetListCommandID = new CommandID(GuidList.AttachToAnythingCommandSet, (int)PkgCmdIDList.AttachToGetList);
            var attachGetListCommand = new OleMenuCommand(AttachGetListInvokeCalback, attachToGetListCommandID);
            mcs.AddCommand(attachGetListCommand);
        }

        private void AttachToInvokeCallback(object sender, EventArgs e) {
            var eventArgs = (OleMenuCmdEventArgs)e;

            // requesting current value?
            if (eventArgs.OutValue != IntPtr.Zero) {
                Marshal.GetNativeVariantForObject("", eventArgs.OutValue);
                return;
            }

            var target = (string)eventArgs.InValue;
            controller.AttachTo(target);
        }

        private void AttachGetListInvokeCalback(object sender, EventArgs e) {
            var eventArgs = (OleMenuCmdEventArgs)e;

            if (eventArgs == null)
                return;

            if (eventArgs.InValue != null)
                throw new ArgumentException("In parameter must not be specified");

            if (eventArgs.OutValue == IntPtr.Zero)
                throw new ArgumentException("Out parameter can not be NULL");

            Marshal.GetNativeVariantForObject(this.controller.GetTargets().ToArray(), eventArgs.OutValue);
        }
    }
}