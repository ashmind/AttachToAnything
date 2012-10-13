using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachToAnything {
    public class AttachTargetModel {
        public string Target      { get; set; }
        public string DisplayName { get; set; }

        public AttachTargetModel() {
        }

        public AttachTargetModel(string target, string displayName) {
            this.Target = target;
            this.DisplayName = displayName;
        }
    }
}
