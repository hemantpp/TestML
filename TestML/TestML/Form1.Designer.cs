namespace TestML
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
            this.btnGenerateData = new System.Windows.Forms.Button();
            this.btnDownloadGeneratedData = new System.Windows.Forms.Button();
            this.btnLoadDataFromFile = new System.Windows.Forms.Button();
            this.btnGenerateAndDownload = new System.Windows.Forms.Button();
            this.btn90Accuracy = new System.Windows.Forms.Button();
            this.btnDeleteDataFromDB = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.FlatAppearance.BorderSize = 2;
            this.btnGenerateData.Location = new System.Drawing.Point(23, 20);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(186, 60);
            this.btnGenerateData.TabIndex = 0;
            this.btnGenerateData.Text = "Generate Random Data and Load it to Database";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // btnDownloadGeneratedData
            // 
            this.btnDownloadGeneratedData.FlatAppearance.BorderSize = 2;
            this.btnDownloadGeneratedData.Location = new System.Drawing.Point(234, 20);
            this.btnDownloadGeneratedData.Name = "btnDownloadGeneratedData";
            this.btnDownloadGeneratedData.Size = new System.Drawing.Size(186, 60);
            this.btnDownloadGeneratedData.TabIndex = 1;
            this.btnDownloadGeneratedData.Text = "Export Data from Database to File: c:\\temp\\db.txt";
            this.btnDownloadGeneratedData.UseVisualStyleBackColor = true;
            this.btnDownloadGeneratedData.Click += new System.EventHandler(this.btnDownloadGeneratedData_Click);
            // 
            // btnLoadDataFromFile
            // 
            this.btnLoadDataFromFile.FlatAppearance.BorderSize = 2;
            this.btnLoadDataFromFile.Location = new System.Drawing.Point(23, 194);
            this.btnLoadDataFromFile.Name = "btnLoadDataFromFile";
            this.btnLoadDataFromFile.Size = new System.Drawing.Size(186, 60);
            this.btnLoadDataFromFile.TabIndex = 2;
            this.btnLoadDataFromFile.Text = "Load Data from File: c:\\temp\\db.txt";
            this.btnLoadDataFromFile.UseVisualStyleBackColor = true;
            this.btnLoadDataFromFile.Click += new System.EventHandler(this.btnLoadDataFromFile_Click);
            // 
            // btnGenerateAndDownload
            // 
            this.btnGenerateAndDownload.FlatAppearance.BorderSize = 2;
            this.btnGenerateAndDownload.Location = new System.Drawing.Point(234, 105);
            this.btnGenerateAndDownload.Name = "btnGenerateAndDownload";
            this.btnGenerateAndDownload.Size = new System.Drawing.Size(186, 60);
            this.btnGenerateAndDownload.TabIndex = 4;
            this.btnGenerateAndDownload.Text = "Generate Data And Export it to File: c:\\temp\\db.txt";
            this.btnGenerateAndDownload.UseVisualStyleBackColor = true;
            this.btnGenerateAndDownload.Click += new System.EventHandler(this.btnGenerateAndDownload_Click);
            // 
            // btn90Accuracy
            // 
            this.btn90Accuracy.FlatAppearance.BorderSize = 2;
            this.btn90Accuracy.Location = new System.Drawing.Point(23, 105);
            this.btn90Accuracy.Name = "btn90Accuracy";
            this.btn90Accuracy.Size = new System.Drawing.Size(186, 60);
            this.btn90Accuracy.TabIndex = 5;
            this.btn90Accuracy.Text = "Generate Data for 90% Accuracy to File: c:\\temp\\db.txt";
            this.btn90Accuracy.UseVisualStyleBackColor = true;
            this.btn90Accuracy.Click += new System.EventHandler(this.btn90Accuracy_Click);
            // 
            // btnDeleteDataFromDB
            // 
            this.btnDeleteDataFromDB.FlatAppearance.BorderSize = 2;
            this.btnDeleteDataFromDB.Location = new System.Drawing.Point(234, 194);
            this.btnDeleteDataFromDB.Name = "btnDeleteDataFromDB";
            this.btnDeleteDataFromDB.Size = new System.Drawing.Size(186, 60);
            this.btnDeleteDataFromDB.TabIndex = 6;
            this.btnDeleteDataFromDB.Text = "Delete All Data from Database";
            this.btnDeleteDataFromDB.UseVisualStyleBackColor = true;
            this.btnDeleteDataFromDB.Click += new System.EventHandler(this.btnDeleteDataFromDB_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.Location = new System.Drawing.Point(146, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 41);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 66);
            this.label1.TabIndex = 8;
            this.label1.Text = "Once Data is generated and loaded in to the database, please use Power BI to view" +
    " the various measurements.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteDataFromDB);
            this.Controls.Add(this.btn90Accuracy);
            this.Controls.Add(this.btnGenerateAndDownload);
            this.Controls.Add(this.btnLoadDataFromFile);
            this.Controls.Add(this.btnDownloadGeneratedData);
            this.Controls.Add(this.btnGenerateData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateData;
        private System.Windows.Forms.Button btnDownloadGeneratedData;
        private System.Windows.Forms.Button btnLoadDataFromFile;
        private System.Windows.Forms.Button btnGenerateAndDownload;
        private System.Windows.Forms.Button btn90Accuracy;
        private System.Windows.Forms.Button btnDeleteDataFromDB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}

