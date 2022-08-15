namespace BattleShip
{
    partial class AlreadyHit
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.errorbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(310, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(262, 47);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "You Already Hit";
            // 
            // errorbutton
            // 
            this.errorbutton.Location = new System.Drawing.Point(368, 144);
            this.errorbutton.Name = "errorbutton";
            this.errorbutton.Size = new System.Drawing.Size(100, 48);
            this.errorbutton.TabIndex = 3;
            this.errorbutton.Text = "Ok";
            this.errorbutton.UseVisualStyleBackColor = true;
            this.errorbutton.Click += new System.EventHandler(this.errorbutton_Click);
            // 
            // AlreadyHit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 249);
            this.Controls.Add(this.errorbutton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "AlreadyHit";
            this.Text = "AlreadyHitcs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button errorbutton;
    }
}