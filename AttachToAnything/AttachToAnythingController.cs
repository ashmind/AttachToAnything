using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using Process = EnvDTE.Process;

namespace AttachToAnything {
    public class AttachToAnythingController {
        private const string OpenDialogTarget = "<open dialog>";

        private readonly DTE dte;
        private readonly AttachTargetOptionPage options;

        public AttachToAnythingController(DTE dte, AttachTargetOptionPage options) {
            this.dte = dte;
            this.options = options;
        }

        public IEnumerable<AttachTargetModel> GetTargets() {
            return this.options.Targets.Concat(new[] {
                new AttachTargetModel(OpenDialogTarget, "Other process…")
            });
        }

        public void AttachTo(string targetDisplayName) {
            var target = this.options.Targets.Single(t => t.DisplayName == targetDisplayName);
            if (target.Target == OpenDialogTarget) {
                dte.ExecuteCommand("Tools.AttachtoProcess");
                return;
            }

            var found = false;
            foreach (Process process in dte.Debugger.LocalProcesses) {
                var fileName = Path.GetFileName(process.Name);
                if (fileName == target.Target) {
                    found = true;
                    process.Attach();
                }
            }

            if (!found)
                MessageBox.Show("Failed to find " + target.Target + ".", "Attach To Anything", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
