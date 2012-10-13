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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listTargets = new System.Windows.Forms.ListView();
            this.columnTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 37);
            this.panel1.TabIndex = 3;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(87, 13);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 13);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
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
            this.listTargets.Location = new System.Drawing.Point(10, 10);
            this.listTargets.MultiSelect = false;
            this.listTargets.Name = "listTargets";
            this.listTargets.Size = new System.Drawing.Size(483, 265);
            this.listTargets.TabIndex = 4;
            this.listTargets.UseCompatibleStateImageBehavior = false;
            this.listTargets.View = System.Windows.Forms.View.Details;
            this.listTargets.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listTargets_AfterLabelEdit);
            this.listTargets.SelectedIndexChanged += new System.EventHandler(this.listTargets_SelectedIndexChanged);
            this.listTargets.Click += new System.EventHandler(this.listTargets_Click);
            this.listTargets.Resize += new System.EventHandler(this.listTargets_Resize);
            // 
            // columnTarget
            // 
            this.columnTarget.Text = "Process Names";
            this.columnTarget.Width = 479;
            // 
            // AttachTargetOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTargets);
            this.Controls.Add(this.panel1);
            this.Name = "AttachTargetOptionControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(503, 322);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListView listTargets;
        private System.Windows.Forms.ColumnHeader columnTarget;




    }
}
