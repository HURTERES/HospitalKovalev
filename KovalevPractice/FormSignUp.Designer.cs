namespace KovalevPractice
{
    partial class FormSignUp
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
            this.LblQueue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblMin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnComplete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TbxReason = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TbxAddress = new System.Windows.Forms.RichTextBox();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblQueue
            // 
            this.LblQueue.AutoSize = true;
            this.LblQueue.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.LblQueue.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblQueue.ForeColor = System.Drawing.Color.Black;
            this.LblQueue.Location = new System.Drawing.Point(336, 170);
            this.LblQueue.Margin = new System.Windows.Forms.Padding(0);
            this.LblQueue.Name = "LblQueue";
            this.LblQueue.Size = new System.Drawing.Size(65, 24);
            this.LblQueue.TabIndex = 89;
            this.LblQueue.Text = "0 чел.";
            this.LblQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(79, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 27);
            this.label10.TabIndex = 88;
            this.label10.Text = "Больных в очереди:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMin
            // 
            this.LblMin.AutoSize = true;
            this.LblMin.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.LblMin.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblMin.ForeColor = System.Drawing.Color.Black;
            this.LblMin.Location = new System.Drawing.Point(336, 197);
            this.LblMin.Margin = new System.Windows.Forms.Padding(0);
            this.LblMin.Name = "LblMin";
            this.LblMin.Size = new System.Drawing.Size(64, 24);
            this.LblMin.TabIndex = 87;
            this.LblMin.Text = "0 мин\r\n";
            this.LblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(79, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 27);
            this.label8.TabIndex = 86;
            this.label8.Text = "Среднее время ожидания:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnComplete
            // 
            this.BtnComplete.BackColor = System.Drawing.Color.Tan;
            this.BtnComplete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnComplete.Enabled = false;
            this.BtnComplete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnComplete.FlatAppearance.BorderSize = 0;
            this.BtnComplete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnComplete.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnComplete.ForeColor = System.Drawing.Color.White;
            this.BtnComplete.Location = new System.Drawing.Point(65, 231);
            this.BtnComplete.Name = "BtnComplete";
            this.BtnComplete.Size = new System.Drawing.Size(333, 35);
            this.BtnComplete.TabIndex = 85;
            this.BtnComplete.Text = "Подтвердить запись\r\n\r\n";
            this.BtnComplete.UseVisualStyleBackColor = false;
            this.BtnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.TbxReason);
            this.panel3.ForeColor = System.Drawing.Color.DarkCyan;
            this.panel3.Location = new System.Drawing.Point(12, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 40);
            this.panel3.TabIndex = 81;
            // 
            // TbxReason
            // 
            this.TbxReason.BackColor = System.Drawing.Color.White;
            this.TbxReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxReason.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxReason.ForeColor = System.Drawing.Color.Black;
            this.TbxReason.Location = new System.Drawing.Point(19, 3);
            this.TbxReason.Name = "TbxReason";
            this.TbxReason.Size = new System.Drawing.Size(395, 32);
            this.TbxReason.TabIndex = 66;
            this.TbxReason.Text = "Причина обращения";
            this.TbxReason.TextChanged += new System.EventHandler(this.RtbxFIO_TextChanged);
            this.TbxReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxReason_KeyPress);
            this.TbxReason.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TbxReason_MouseDown);
            this.TbxReason.MouseLeave += new System.EventHandler(this.TbxReason_MouseLeave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(65, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 28);
            this.flowLayoutPanel1.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Запись больного";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TbxAddress);
            this.panel2.ForeColor = System.Drawing.Color.DarkCyan;
            this.panel2.Location = new System.Drawing.Point(12, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 40);
            this.panel2.TabIndex = 90;
            // 
            // TbxAddress
            // 
            this.TbxAddress.BackColor = System.Drawing.Color.White;
            this.TbxAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxAddress.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxAddress.ForeColor = System.Drawing.Color.Black;
            this.TbxAddress.Location = new System.Drawing.Point(19, 3);
            this.TbxAddress.Name = "TbxAddress";
            this.TbxAddress.Size = new System.Drawing.Size(395, 32);
            this.TbxAddress.TabIndex = 66;
            this.TbxAddress.Text = "Введите адрес";
            this.TbxAddress.TextChanged += new System.EventHandler(this.TbxAddress_TextChanged);
            this.TbxAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxAddress_KeyPress);
            this.TbxAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
            this.TbxAddress.MouseLeave += new System.EventHandler(this.TbxAddress_MouseLeave);
            // 
            // FormSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(465, 287);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblQueue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblMin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnComplete);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSignUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ❤️ ГБУЗ Новозыбковская ЦРБ";
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnComplete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox TbxReason;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox TbxAddress;
        public System.Windows.Forms.Label LblQueue;
        public System.Windows.Forms.Label LblMin;
    }
}