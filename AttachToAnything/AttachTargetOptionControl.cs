using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Process = EnvDTE.Process;

namespace AttachToAnything {
    public partial class AttachTargetOptionControl : UserControl {
        public IList<string> Model { get; set; }

        public AttachTargetOptionControl() {
            InitializeComponent();
        }
        
        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            if (!this.Visible)
                return;

            listTargets.Items.Clear();
            listTargets.Items.AddRange(this.Model.Select(item => new ListViewItem { Text = item }).ToArray());

            Task.Factory.StartNew(FillProcessesAsync);
        }

        private void FillProcessesAsync() {
            try {
                var dte = (DTE)this.GetService(typeof(DTE));
                var processNames = dte.Debugger.LocalProcesses
                                               .Cast<Process>()
                                               .Select(p => Path.GetFileName(p.Name))
                                               .Distinct()
                                               .OrderBy(n => n)
                                               .ToArray();

                comboProcesses.Invoke((Action)(() => {
                    comboProcesses.Items.Clear();
                    comboProcesses.Items.AddRange(processNames);
                }));
            }
            catch (Exception ex) {
                // not sure where it will be shown though:
                Trace.TraceError(ex.ToString());
            }
        }

        private void listTargets_Resize(object sender, EventArgs e) {
            columnTarget.Width = -2; // magic value, fit width
        }

        private void listTargets_AfterLabelEdit(object sender, LabelEditEventArgs e) {
            this.Model[e.Item] = e.Label;
        }

        private void listTargets_SelectedIndexChanged(object sender, EventArgs e) {
            buttonRemove.Enabled = (listTargets.SelectedIndices.Count > 0);
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            listTargets.Items.Add(new ListViewItem(comboProcesses.Text));
            this.Model.Add(comboProcesses.Text);
            comboProcesses.Text = "";
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            this.Model.RemoveAt(listTargets.SelectedIndices[0]);
            listTargets.Items.RemoveAt(listTargets.SelectedIndices[0]);
        }

        private void comboProcesses_TextChanged(object sender, EventArgs e) {
            buttonAdd.Enabled = comboProcesses.Text.Length > 0;
        }
    }
}
