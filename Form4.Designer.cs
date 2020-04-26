namespace Biometric_Document
{
    partial class Form4
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
            this.VerifySC = new System.Windows.Forms.Button();
            this.VerifyDB = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReceiptID = new System.Windows.Forms.TextBox();
            this.TransactionID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.matricNo = new System.Windows.Forms.TextBox();
            this.resultsTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // VerifySC
            // 
            this.VerifySC.Location = new System.Drawing.Point(27, 396);
            this.VerifySC.Name = "VerifySC";
            this.VerifySC.Size = new System.Drawing.Size(143, 23);
            this.VerifySC.TabIndex = 15;
            this.VerifySC.Text = "Verify From Scanner";
            this.VerifySC.UseVisualStyleBackColor = true;
            // 
            // VerifyDB
            // 
            this.VerifyDB.Location = new System.Drawing.Point(27, 341);
            this.VerifyDB.Name = "VerifyDB";
            this.VerifyDB.Size = new System.Drawing.Size(143, 23);
            this.VerifyDB.TabIndex = 14;
            this.VerifyDB.Text = "Verify From Server";
            this.VerifyDB.UseVisualStyleBackColor = true;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(36, 254);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(114, 23);
            this.GenerateButton.TabIndex = 13;
            this.GenerateButton.Text = "Generate Receipt";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Receipt Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Transaction ID";
            // 
            // ReceiptID
            // 
            this.ReceiptID.Location = new System.Drawing.Point(93, 188);
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.Size = new System.Drawing.Size(138, 20);
            this.ReceiptID.TabIndex = 10;
            // 
            // TransactionID
            // 
            this.TransactionID.Location = new System.Drawing.Point(93, 137);
            this.TransactionID.Name = "TransactionID";
            this.TransactionID.Size = new System.Drawing.Size(138, 20);
            this.TransactionID.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Refresh Records";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Matric Number";
            // 
            // matricNo
            // 
            this.matricNo.Location = new System.Drawing.Point(94, 83);
            this.matricNo.Name = "matricNo";
            this.matricNo.Size = new System.Drawing.Size(138, 20);
            this.matricNo.TabIndex = 20;
            // 
            // resultsTable
            // 
            this.resultsTable.AllowUserToAddRows = false;
            this.resultsTable.AllowUserToDeleteRows = false;
            this.resultsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsTable.Location = new System.Drawing.Point(237, 49);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.ReadOnly = true;
            this.resultsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsTable.Size = new System.Drawing.Size(593, 430);
            this.resultsTable.TabIndex = 21;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 491);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.matricNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VerifySC);
            this.Controls.Add(this.VerifyDB);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReceiptID);
            this.Controls.Add(this.TransactionID);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VerifySC;
        private System.Windows.Forms.Button VerifyDB;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReceiptID;
        private System.Windows.Forms.TextBox TransactionID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox matricNo;
        private System.Windows.Forms.DataGridView resultsTable;
    }
}