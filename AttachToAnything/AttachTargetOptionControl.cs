using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AttachToAnything {
    public partial class AttachTargetOptionControl : UserControl {
        public AttachTargetOptionControl() {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            this.listTargets.Items.Clear();
            this.listTargets.Items.AddRange(this.Model.Select(item => new ListViewItem { Text = item }).ToArray());
        }

        public IList<string> Model { get; set; }

        private void listTargets_Click(object sender, EventArgs e) {
            listTargets.SelectedItems[0].BeginEdit();
        }

        private void listTargets_Resize(object sender, EventArgs e) {
            columnTarget.Width = -2; // magic value, fit width
        }

        private void listTargets_AfterLabelEdit(object sender, LabelEditEventArgs e) {
            var index = listTargets.SelectedIndices[0];
            if (index < this.Model.Count) {
                this.Model[index] = e.Label;
            }
            else {
                this.Model.Add(e.Label);
            }
        }

        private void listTargets_SelectedIndexChanged(object sender, EventArgs e) {
            buttonRemove.Enabled = (listTargets.SelectedIndices.Count > 0);
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var item = new ListViewItem("<new>") {Selected = true};
            listTargets.Items.Add(item);

            item.BeginEdit();
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            this.Model.RemoveAt(listTargets.SelectedIndices[0]);
            listTargets.Items.RemoveAt(listTargets.SelectedIndices[0]);
        }
    }
}
