namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_1 = new Label();
            lbl_2 = new Label();
            btn_1 = new Button();
            btn_2 = new Button();
            SuspendLayout();
            // 
            // lbl_1
            // 
            lbl_1.AutoSize = true;
            lbl_1.Location = new Point(345, 193);
            lbl_1.Name = "lbl_1";
            lbl_1.Size = new Size(0, 15);
            lbl_1.TabIndex = 0;
            // 
            // lbl_2
            // 
            lbl_2.AutoSize = true;
            lbl_2.Location = new Point(523, 238);
            lbl_2.Name = "lbl_2";
            lbl_2.Size = new Size(0, 15);
            lbl_2.TabIndex = 1;
            // 
            // btn_1
            // 
            btn_1.Location = new Point(313, 330);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(75, 23);
            btn_1.TabIndex = 2;
            btn_1.Text = "click me";
            btn_1.UseVisualStyleBackColor = true;
            btn_1.Click += btn_1_Click;
            // 
            // btn_2
            // 
            btn_2.Location = new Point(509, 330);
            btn_2.Name = "btn_2";
            btn_2.Size = new Size(75, 23);
            btn_2.TabIndex = 3;
            btn_2.Text = "click me";
            btn_2.UseVisualStyleBackColor = true;
            btn_2.Click += btn_2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_2);
            Controls.Add(btn_1);
            Controls.Add(lbl_2);
            Controls.Add(lbl_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_1;
        private Label lbl_2;
        private Button btn_1;
        private Button btn_2;
    }
}