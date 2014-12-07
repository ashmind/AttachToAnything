using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachToAnything.UI {
    public class WaitDialogModel {
        public string ProcessName { get; private set; }
        public bool Efficient { get; private set; }

        public WaitDialogModel(string processName, bool efficient) {
            ProcessName = processName;
            Efficient = efficient;
        }
    }
}
