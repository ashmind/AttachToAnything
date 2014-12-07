using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using AttachToAnything.Internal;
using AttachToAnything.UI;
using EnvDTE;
using ExceptionBreaker.Implementation;
using Process = EnvDTE.Process;

namespace AttachToAnything {
    public class AttachToAnythingController {
        private const string OpenDialogTarget = "Other…";

        private readonly DTE _dte;
        private readonly AttachTargetOptionPage _options;
        private readonly ProcessWaitSource _waitSource;
        private readonly IDiagnosticLogger _logger;

        public AttachToAnythingController(DTE dte, AttachTargetOptionPage options, ProcessWaitSource waitSource, IDiagnosticLogger logger) {
            _dte = dte;
            _options = options;
            _waitSource = waitSource;
            _logger = logger;
        }

        public IEnumerable<string> GetTargets() {
            return _options.Targets.Concat(new[] { OpenDialogTarget });
        }

        public void AttachTo(string processNameOrOpenDialog) {
            if (processNameOrOpenDialog == OpenDialogTarget) {
                _logger.WriteLine("Opening 'Attach to Process' dialog…");
                _dte.ExecuteCommand("Tools.AttachtoProcess");
                return;
            }

            var processName = processNameOrOpenDialog;
            var found = false;
            foreach (Process process in _dte.Debugger.LocalProcesses) {
                var fileName = Path.GetFileName(process.Name);
                if (fileName.Equals(processName, StringComparison.InvariantCultureIgnoreCase)) {
                    found = true;
                    _logger.WriteLine("Attaching to '{0}'.", fileName);
                    process.Attach();
                }
            }

            if (!found)
                WaitUntilStarted(processName);
        }

        private void WaitUntilStarted(string processName) {
            _logger.WriteLine("Waiting until '{0}' starts.", processName);

            var dialog = new WaitDialog();
            var dispatcher = Dispatcher.CurrentDispatcher;
            using (var cancellation = new CancellationTokenSource()) {
                _waitSource.WaitForAsync(processName, cancellation.Token).ContinueWith(_ => {
                    dispatcher.Invoke((Action)dialog.Close, DispatcherPriority.Send);
                    AttachTo(processName);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                dialog.Model = new WaitDialogModel(processName, _waitSource.IsEfficient);
                var result = dialog.ShowModal();
                if (result == false)
                    cancellation.Cancel();
            }
        }
    }
}
