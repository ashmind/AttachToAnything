namespace AttachToAnything {
    partial class AttachTargetOptionControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Panel panel;
            this.comboProcesses = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listTargets = new System.Windows.Forms.ListView();
            this.columnTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            panel = new System.Windows.Forms.Panel();
            panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(this.comboProcesses);
            panel.Controls.Add(this.buttonRemove);
            panel.Controls.Add(this.buttonAdd);
            panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel.Location = new System.Drawing.Point(10, 346);
            panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            panel.Size = new System.Drawing.Size(561, 43);
            panel.TabIndex = 3;
            // 
            // comboProcesses
            // 
            this.comboProcesses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboProcesses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboProcesses.FormattingEnabled = true;
            this.comboProcesses.Location = new System.Drawing.Point(0, 14);
            this.comboProcesses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboProcesses.Name = "comboProcesses";
            this.comboProcesses.Size = new System.Drawing.Size(286, 28);
            this.comboProcesses.TabIndex = 4;
            this.comboProcesses.TextChanged += new System.EventHandler(this.comboProcesses_TextChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(379, 15);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 28);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(295, 15);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(10, 4, 3, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 28);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listTargets
            // 
            this.listTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTarget});
            this.listTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTargets.LabelEdit = true;
            this.listTargets.Location = new System.Drawing.Point(10, 13);
            this.listTargets.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listTargets.MultiSelect = false;
            this.listTargets.Name = "listTargets";
            this.listTargets.Size = new System.Drawing.Size(561, 333);
            this.listTargets.TabIndex = 4;
            this.listTargets.UseCompatibleStateImageBehavior = false;
            this.listTargets.View = System.Windows.Forms.View.Details;
            this.listTargets.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listTargets_AfterLabelEdit);
            this.listTargets.SelectedIndexChanged += new System.EventHandler(this.listTargets_SelectedIndexChanged);
            this.listTargets.Resize += new System.EventHandler(this.listTargets_Resize);
            // 
            // columnTarget
            // 
            this.columnTarget.Text = "Process Names";
            this.columnTarget.Width = 479;
            // 
            // AttachTargetOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTargets);
            this.Controls.Add(panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AttachTargetOptionControl";
            this.Padding = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.Size = new System.Drawing.Size(581, 402);
            panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListView listTargets;
        private System.Windows.Forms.ColumnHeader columnTarget;
        private System.Windows.Forms.ComboBox comboProcesses;




    }
}
