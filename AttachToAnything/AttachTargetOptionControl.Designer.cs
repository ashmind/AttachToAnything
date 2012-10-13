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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridTargets = new System.Windows.Forms.DataGridView();
            this.sourceModel = new System.Windows.Forms.BindingSource(this.components);
            this.columnDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTargets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTargets
            // 
            this.gridTargets.AllowUserToResizeColumns = false;
            this.gridTargets.AllowUserToResizeRows = false;
            this.gridTargets.AutoGenerateColumns = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.gridTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTargets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDisplayName,
            this.columnProcessName,
            this.columnDelete});
            this.gridTargets.DataSource = this.sourceModel;
            this.gridTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTargets.Location = new System.Drawing.Point(10, 10);
            this.gridTargets.Name = "gridTargets";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTargets.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.gridTargets.RowTemplate.Height = 24;
            this.gridTargets.Size = new System.Drawing.Size(483, 302);
            this.gridTargets.TabIndex = 0;
            this.gridTargets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTargets_CellContentClick);
            // 
            // sourceModel
            // 
            this.sourceModel.AllowNew = true;
            this.sourceModel.DataSource = typeof(AttachToAnything.AttachTargetModel);
            // 
            // columnDisplayName
            // 
            this.columnDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnDisplayName.DataPropertyName = "DisplayName";
            this.columnDisplayName.HeaderText = "Display As";
            this.columnDisplayName.Name = "columnDisplayName";
            this.columnDisplayName.Width = 99;
            // 
            // columnProcessName
            // 
            this.columnProcessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnProcessName.DataPropertyName = "Target";
            this.columnProcessName.HeaderText = "Process";
            this.columnProcessName.Name = "columnProcessName";
            // 
            // columnDelete
            // 
            this.columnDelete.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.columnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.columnDelete.DefaultCellStyle = dataGridViewCellStyle26;
            this.columnDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.columnDelete.LinkColor = System.Drawing.SystemColors.ControlText;
            this.columnDelete.Name = "columnDelete";
            this.columnDelete.HeaderText = " ";
            this.columnDelete.ReadOnly = true;
            this.columnDelete.Text = "×";
            this.columnDelete.ToolTipText = "Delete";
            this.columnDelete.UseColumnTextForLinkValue = true;
            this.columnDelete.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.columnDelete.Width = 21;
            // 
            // AttachTargetOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridTargets);
            this.Name = "AttachTargetOptionControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(503, 322);
            ((System.ComponentModel.ISupportInitialize)(this.gridTargets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTargets;
        private System.Windows.Forms.BindingSource sourceModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProcessName;
        private System.Windows.Forms.DataGridViewLinkColumn columnDelete;

    }
}
