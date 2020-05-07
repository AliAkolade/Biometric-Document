namespace Biometric_Document
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.VerifyDB = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReceiptID = new System.Windows.Forms.TextBox();
            this.TransactionID = new System.Windows.Forms.TextBox();
            this.VerifySC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // VerifyDB
            // 
            this.VerifyDB.Location = new System.Drawing.Point(439, 156);
            this.VerifyDB.Name = "VerifyDB";
            this.VerifyDB.Size = new System.Drawing.Size(143, 23);
            this.VerifyDB.TabIndex = 7;
            this.VerifyDB.Text = "Verify From Server";
            this.VerifyDB.UseVisualStyleBackColor = true;
            this.VerifyDB.Click += new System.EventHandler(this.VerifyDB_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(133, 255);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(114, 23);
            this.GenerateButton.TabIndex = 6;
            this.GenerateButton.Text = "Generate Document";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Receipt Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transaction ID";
            // 
            // ReceiptID
            // 
            this.ReceiptID.Location = new System.Drawing.Point(120, 206);
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.Size = new System.Drawing.Size(138, 20);
            this.ReceiptID.TabIndex = 3;
            // 
            // TransactionID
            // 
            this.TransactionID.Location = new System.Drawing.Point(120, 152);
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.Size = new System.Drawing.Size(138, 20);
            this.TransactionID.TabIndex = 2;
            // 
            // VerifySC
            // 
            this.VerifySC.Location = new System.Drawing.Point(439, 213);
            this.VerifySC.Name = "VerifySC";
            this.VerifySC.Size = new System.Drawing.Size(143, 23);
            this.VerifySC.TabIndex = 8;
            this.VerifySC.Text = "Verify From Scanner";
            this.VerifySC.UseVisualStyleBackColor = true;
            this.VerifySC.Click += new System.EventHandler(this.VerifySC_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Generate Document";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Verify Documents";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VerifySC);
            this.Controls.Add(this.VerifyDB);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReceiptID);
            this.Controls.Add(this.TransactionID);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VerifyDB;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReceiptID;
        private System.Windows.Forms.TextBox TransactionID;
        private System.Windows.Forms.Button VerifySC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}