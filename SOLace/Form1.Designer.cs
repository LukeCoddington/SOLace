namespace SOLace
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.blueBase = new System.Windows.Forms.Button();
            this.redBase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // blueBase
            // 
            this.blueBase.BackColor = System.Drawing.SystemColors.HotTrack;
            this.blueBase.Location = new System.Drawing.Point(754, 1);
            this.blueBase.Name = "blueBase";
            this.blueBase.Size = new System.Drawing.Size(126, 119);
            this.blueBase.TabIndex = 0;
            this.blueBase.UseVisualStyleBackColor = false;
            // 
            // redBase
            // 
            this.redBase.BackColor = System.Drawing.Color.Red;
            this.redBase.Location = new System.Drawing.Point(2, 513);
            this.redBase.Name = "redBase";
            this.redBase.Size = new System.Drawing.Size(122, 114);
            this.redBase.TabIndex = 1;
            this.redBase.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(881, 628);
            this.Controls.Add(this.redBase);
            this.Controls.Add(this.blueBase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button blueBase;
        private System.Windows.Forms.Button redBase;
    }
}

