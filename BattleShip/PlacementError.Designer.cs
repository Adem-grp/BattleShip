namespace BattleShip
{
    partial class PlacementError
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
            this.errorbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // errorbutton
            // 
            this.errorbutton.Location = new System.Drawing.Point(254, 132);
            this.errorbutton.Name = "errorbutton";
            this.errorbutton.Size = new System.Drawing.Size(100, 48);
            this.errorbutton.TabIndex = 0;
            this.errorbutton.Text = "Ok";
            this.errorbutton.UseVisualStyleBackColor = true;
            this.errorbutton.Click += new System.EventHandler(this.errorbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(182, 54);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(280, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Ships Collide please choose another space";
            // 
            // PlacementError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 192);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.errorbutton);
            this.Name = "PlacementError";
            this.Text = "PlacementError";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button errorbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}