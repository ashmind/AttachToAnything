using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AttachToAnything {
    public partial class AttachTargetOptionControl : UserControl {
        public AttachTargetOptionControl() {
            InitializeComponent();
        }

        public IList<AttachTargetModel> Model {
            get { return (IList<AttachTargetModel>)sourceModel.DataSource; }
            set { sourceModel.DataSource = value; }
        }

        private void gridTargets_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != columnDelete.Index)
                return;

            sourceModel.RemoveAt(e.RowIndex);
        }
    }
}
