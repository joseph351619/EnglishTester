namespace EnglishTester
{
    partial class ControlPanel
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
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnInsertQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(116, 54);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "開始測驗";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnInsertQuestion
            // 
            this.btnInsertQuestion.Location = new System.Drawing.Point(288, 54);
            this.btnInsertQuestion.Name = "btnInsertQuestion";
            this.btnInsertQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnInsertQuestion.TabIndex = 1;
            this.btnInsertQuestion.Text = "輸入題目";
            this.btnInsertQuestion.UseVisualStyleBackColor = true;
            this.btnInsertQuestion.Click += new System.EventHandler(this.btnInsertQuestion_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInsertQuestion);
            this.Controls.Add(this.btnStartTest);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnInsertQuestion;
    }
}