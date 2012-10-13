using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using IWin32Window = System.Windows.Forms.IWin32Window;

namespace AttachToAnything {
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [CLSCompliant(false), ComVisible(true)]
    public class AttachTargetOptionPage : DialogPage {
        #region TargetsTypeConverter Class

        private class TargetsTypeConverter : TypeConverter {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
                return sourceType == typeof(string);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
                var @string = value as string;
                if (@string == null)
                    return base.ConvertFrom(context, culture, value);

                if (string.IsNullOrEmpty(@string))
                    return new List<string>();

                return @string.Split(';').ToList();
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                return destinationType == typeof(string);
            }

            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
                if (destinationType != typeof(string))
                    return base.ConvertTo(context, culture, value, destinationType);

                return string.Join(";", (IList<string>)value);
            }
        }

        #endregion

        public AttachTargetOptionPage() {
            this.Targets = new List<string> { "w3wp.exe" };
        }

        [TypeConverter(typeof(TargetsTypeConverter))]
        public IList<string> Targets { get; set; }

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
