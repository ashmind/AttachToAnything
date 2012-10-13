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

        private readonly IList<AttachTargetModel> targets = new List<AttachTargetModel> {
            new AttachTargetModel("w3wp.exe",       "IIS (local)"),
            new AttachTargetModel(OpenDialogTarget, "Other process…")
        };
        private readonly DTE dte;

        public AttachToAnythingController(DTE dte) {
            this.dte = dte;
        }

        public IEnumerable<AttachTargetModel> GetTargets() {
            return this.targets;
        }

        public void AttachTo(string targetDisplayName) {
            var target = this.targets.Single(t => t.DisplayName == targetDisplayName);
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
                MessageBox.Show("Failed to find " + target.Target + " process.", "Attach To Anything", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
