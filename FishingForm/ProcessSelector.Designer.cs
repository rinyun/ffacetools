namespace Fishing
{
    partial class ProcessSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbProcessList = new System.Windows.Forms.ListBox();
            this.btnProcessAttach = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProcessList
            // 
            this.lbProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProcessList.Location = new System.Drawing.Point(0, 39);
            this.lbProcessList.Name = "lbProcessList";
            this.lbProcessList.Size = new System.Drawing.Size(357, 147);
            this.lbProcessList.TabIndex = 0;
            this.lbProcessList.UseTabStops = false;
            // 
            // btnProcessAttach
            // 
            this.btnProcessAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessAttach.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessAttach.Location = new System.Drawing.Point(0, 185);
            this.btnProcessAttach.Name = "btnProcessAttach";
            this.btnProcessAttach.Size = new System.Drawing.Size(357, 34);
            this.btnProcessAttach.TabIndex = 1;
            this.btnProcessAttach.Text = "Attach to the Selected Process";
            this.btnProcessAttach.UseVisualStyleBackColor = true;
            this.btnProcessAttach.Click += new System.EventHandler(this.btnProcessAttach_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProcess.Location = new System.Drawing.Point(0, 0);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(0);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Padding = new System.Windows.Forms.Padding(3);
            this.lblProcess.Size = new System.Drawing.Size(357, 33);
            this.lblProcess.TabIndex = 0;
            this.lblProcess.Text = "Only fully logged in characters are listed.  Choose a character to fish with, the" +
                "n click the \'Attach to the Selected Process\' button at the bottom.";
            // 
            // ProcessSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 219);
            this.ControlBox = false;
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnProcessAttach);
            this.Controls.Add(this.lbProcessList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcessSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select A Process";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbProcessList;
        private System.Windows.Forms.Button btnProcessAttach;
        private System.Windows.Forms.Label lblProcess;
    }
}