using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using AttachToAnything.Internal;
using Microsoft.VisualStudio.Shell;
using IWin32Window = System.Windows.Forms.IWin32Window;

namespace AttachToAnything {
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [CLSCompliant(false), ComVisible(true)]
    public class AttachTargetOptionPage : DialogPage {
        #region TargetsTypeConverter
        private class TargetsTypeConverter : JsonTypeConverterBase<IList<AttachTargetModel>> {}
        #endregion

        public AttachTargetOptionPage() {
            this.Targets = new List<AttachTargetModel> {
                new AttachTargetModel("w3wp.exe", "IIS (local)")
            };
        }

        [TypeConverter(typeof(TargetsTypeConverter))]
        public IList<AttachTargetModel> Targets { get; set; }

        protected override IWin32Window Window {
            get {
                var view = new AttachTargetOptionControl {
                    Model = this.Targets
                };
                return view;
            }
        }
    }
}
