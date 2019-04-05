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
        //int testWordsSelected = 0;
        bool QuestionConfirm = false;
        Label[] words;
        public QuestionInsert()
        {
            InitializeComponent();
            cboAnswerType.DataSource = AnswerType.Types();
            cboAnswerType.DisplayMember = AnswerType.DisplayName();
            cboAnswerType.ValueMember = AnswerType.ValueName();
        }


        private void btnStore_Click(object sender, EventArgs e)
        {
            var questionText = string.Join(" ", words.Select(a => a.Text));
            Questions question = new Questions() {
                Question = questionText,
                Explanation = txtQuestionExplanation.Text,
                Type = (Enums.AnswerType)cboAnswerType.SelectedValue };
            List<Answers> answers = new List<Answers>();
            answers.Add(new Answers() { Answer = txtAnswer.Text.Trim(), Type= (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation.Text, IsCorrect = true});
            //answers.Add(new Answers() { Answer = txtOption1.Text, Type = (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtOptionExplanation1.Text, IsCorrect = false });
            QuestionsBLL BLL = new QuestionsBLL();
            BLL.InsertQuestion(question, answers);
            MessageBox.Show("Success");
            txtAnswer.Text = string.Empty;
            //txtOption1.Text = string.Empty;
            txtQuestion.Text = string.Empty;
            txtAnswerExplanation.Text = string.Empty;
            txtQuestionExplanation.Text = string.Empty;
            txtQuestion.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QuestionConfirm)
            {
                QuestionConfirm = false;
                txtAnswer.Text = string.Empty;
                txtQuestion.BringToFront();
            }
            else
            {
                QuestionConfirm = true;
                panel1.BringToFront();
                string question = txtQuestion.Text;
                string[] questionWords = question.Split(' ');
                words = new Label[questionWords.Length];
                int space = 0;
                panel1.Controls.Clear();
                for(int i=0; i< questionWords.Length; ++i)
                {
                    words[i] = new Label();
                    words[i].MaximumSize = new Size(100, 0);
                    words[i].AutoSize = true;
                    words[i].Text = questionWords[i];
                    words[i].Tag = questionWords[i];
                    words[i].Name = $"lblQuestionWord{i}";
                    words[i].MouseClick += QuestionWords_Click;
                    //words[i].Size = new Size(50, 22);
                    panel1.Controls.Add(words[i]);
                    words[i].Left = space;
                    space += 1 + words[i].Width;
                }
            }
        }

        private void QuestionWords_Click(object sender, EventArgs e)
        {
            var text= ((Label)sender).Tag.ToString();
            var textDisplay = ((Label)sender).Text;
            if(text == textDisplay)
            {
                textDisplay = string.Empty;
                var filterText = string.Empty;
                for(int i=0; i<text.Length; ++i)
                {
                    if (text[i] == '.' || text[i] == ',')
                    {
                        textDisplay += text[i];
                    }
                    else
                    {
                        textDisplay += '_';
                        filterText += text[i];
                    }
                }
                ((Label)sender).Text = textDisplay;
                txtAnswer.Text = filterText;
            }
            else
            {
                ((Label)sender).Text = text;
                txtAnswer.Text = txtAnswer.Text.Replace(text, "");
            }
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }
    }
}
