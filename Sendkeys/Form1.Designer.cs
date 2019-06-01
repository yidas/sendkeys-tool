namespace Sendkeys
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
            this.switchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // switchButton
            // 
            this.switchButton.Location = new System.Drawing.Point(80, 56);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(133, 66);
            this.switchButton.TabIndex = 0;
            this.switchButton.Text = "Start";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(291, 243);
            this.Controls.Add(this.switchButton);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button switchButton;
    }
}

