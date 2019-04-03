using EnglishTester.Data;
using EnglishTester.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishTester.Common;

namespace EnglishTester
{
    public partial class QuestionInsert : Form
    {
        public delegate void ClickEventHandler();
        public event ClickEventHandler ClickEvent;
        int testWordsSelected = 0;
        public QuestionInsert()
        {
            InitializeComponent();
            cboAnswerType.DataSource = AnswerType.Types();
            cboAnswerType.DisplayMember = AnswerType.DisplayName();
            cboAnswerType.ValueMember = AnswerType.ValueName();
        }


        private void btnStore_Click(object sender, EventArgs e)
        {
            Questions question = new Questions() {
                Question = txtQuestion.Text,
                Explanation = txtQuestionExplanation.Text,
                Type = (Enums.AnswerType)cboAnswerType.SelectedValue };
            List<Answers> answers = new List<Answers>();
            answers.Add(new Answers() { Answer = txtAnswer1.Text, Type= (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation1.Text, IsCorrect = rdoAnswer1.Checked });
            answers.Add(new Answers() { Answer = txtAnswer2.Text, Type = (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation2.Text, IsCorrect = rdoAnswer2.Checked });
            answers.Add(new Answers() { Answer = txtAnswer3.Text, Type = (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation3.Text, IsCorrect = rdoAnswer3.Checked });
            answers.Add(new Answers() { Answer = txtAnswer4.Text, Type = (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation4.Text, IsCorrect = rdoAnswer4.Checked });
            QuestionsBLL BLL = new QuestionsBLL();
            BLL.InsertQuestion(question, answers);
            MessageBox.Show("Success");
            txtAnswer1.Text = string.Empty;
            txtAnswer2.Text = string.Empty;
            txtAnswer3.Text = string.Empty;
            txtAnswer4.Text = string.Empty;
            txtQuestion.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string[] questionWords = question.Split(' ');
            Label[] words = new Label[questionWords.Length];
            int space = 0;
            panel1.Controls.Clear();
            for(int i=0; i< questionWords.Length; ++i)
            {
                words[i] = new Label();
                words[i].MaximumSize = new Size(100, 0);
                words[i].AutoSize = true;
                words[i].Text = questionWords[i];
                words[i].Name = $"lblQuestionWord{i}";
                words[i].MouseClick += QuestionWords_Click;
                //words[i].Size = new Size(50, 22);
                panel1.Controls.Add(words[i]);
                words[i].Left = space;
                space += 5 + words[i].Width;
            }
        }

        private void QuestionWords_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }
    }
}
