using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachToAnything {
    public class AttachTargetModel {
        public string Target { get; private set; }
        public string DisplayName { get; private set; }

        public AttachTargetModel(string target, string displayName) {
            this.Target = target;
            this.DisplayName = displayName;
        }
    }
}
