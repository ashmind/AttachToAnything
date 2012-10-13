using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using IWin32Window = System.Windows.Forms.IWin32Window;

namespace AttachToAnything {
    /// <summary>
    /// Interaction logic for AttachTargetOptionView.xaml
    /// </summary>
    public partial class AttachTargetOptionView : Window, IWin32Window {
        private readonly WindowInteropHelper interopHelper;

        public AttachTargetOptionView() {
            InitializeComponent();
            interopHelper = new WindowInteropHelper(this);
        }

        public IntPtr Handle {
            get { return interopHelper.Handle; }
        }
    }
}
