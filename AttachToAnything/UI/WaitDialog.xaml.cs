using System;
using System.Collections.Generic;
using System.Linq;

namespace AttachToAnything.UI {
    public partial class WaitDialog {
        public WaitDialog() {
            InitializeComponent();
        }

        public WaitDialogModel Model {
            get { return (WaitDialogModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
