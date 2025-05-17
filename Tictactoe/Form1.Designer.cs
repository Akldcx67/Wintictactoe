namespace Tictactoe
{
    partial class Form1
    {
        /// <summary>
        /// Mandatory constructor variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Free up any resources that are being used.
        /// </summary>
        /// <param name="disposing">true if the managed resource should be deleted; otherwise false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code automatically created by the Windows Form Builder

        /// <summary>
        /// Required method for constructor support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgain = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(12, 12);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(151, 67);
            this.btnAgain.TabIndex = 0;
            this.btnAgain.Text = "start over";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(12, 96);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(151, 82);
            this.btnAnalysis.TabIndex = 1;
            this.btnAnalysis.Text = "Analyses";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnAgain);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Tag = "Analyses";
            this.Text = "Analyses";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.Button btnAnalysis;
    }
}

