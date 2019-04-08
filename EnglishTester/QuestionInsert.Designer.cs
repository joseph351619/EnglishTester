namespace EnglishTester
{
    partial class QuestionInsert
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnStore = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtQuestionExplanation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnswerExplanation1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAnswerType = new System.Windows.Forms.ComboBox();
            this.btnNewOption = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "題目";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(127, 55);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(646, 89);
            this.txtQuestion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "答案";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(117, 323);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 22);
            this.txtAnswer.TabIndex = 3;
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(713, 415);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 7;
            this.btnStore.Text = "儲存";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(127, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 87);
            this.panel1.TabIndex = 18;
            // 
            // txtQuestionExplanation
            // 
            this.txtQuestionExplanation.Location = new System.Drawing.Point(127, 235);
            this.txtQuestionExplanation.Multiline = true;
            this.txtQuestionExplanation.Name = "txtQuestionExplanation";
            this.txtQuestionExplanation.Size = new System.Drawing.Size(636, 48);
            this.txtQuestionExplanation.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "題目解答說明";
            // 
            // txtAnswerExplanation1
            // 
            this.txtAnswerExplanation1.Location = new System.Drawing.Point(117, 361);
            this.txtAnswerExplanation1.Name = "txtAnswerExplanation1";
            this.txtAnswerExplanation1.Size = new System.Drawing.Size(100, 22);
            this.txtAnswerExplanation1.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "答案說明";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "題目類型";
            // 
            // cboAnswerType
            // 
            this.cboAnswerType.FormattingEnabled = true;
            this.cboAnswerType.Location = new System.Drawing.Point(127, 15);
            this.cboAnswerType.Name = "cboAnswerType";
            this.cboAnswerType.Size = new System.Drawing.Size(121, 20);
            this.cboAnswerType.TabIndex = 28;
            // 
            // btnNewOption
            // 
            this.btnNewOption.Location = new System.Drawing.Point(27, 400);
            this.btnNewOption.Name = "btnNewOption";
            this.btnNewOption.Size = new System.Drawing.Size(75, 23);
            this.btnNewOption.TabIndex = 29;
            this.btnNewOption.Text = "新增選項";
            this.btnNewOption.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(243, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 88);
            this.panel2.TabIndex = 30;
            // 
            // QuestionInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNewOption);
            this.Controls.Add(this.cboAnswerType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAnswerExplanation1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuestionExplanation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "QuestionInsert";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtQuestionExplanation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnswerExplanation1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAnswerType;
        private System.Windows.Forms.Button btnNewOption;
        private System.Windows.Forms.Panel panel2;
    }
}

