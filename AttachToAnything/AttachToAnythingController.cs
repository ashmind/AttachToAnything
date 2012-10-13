using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;

namespace AttachToAnything {
    public class AttachToAnythingController {
        private readonly DTE dte;
        private const string OpenDialogTarget = "…";

        public AttachToAnythingController(DTE dte) {
            this.dte = dte;
        }

        public string[] GetAttachTargets() {
            return new[] { "w3wp", OpenDialogTarget };
        }

        public void AttachTo(string target) {
            if (target == OpenDialogTarget) {
                dte.ExecuteCommand("Tools.AttachtoProcess");
                return;
            }

            throw new NotImplementedException();
        }
    }
}
