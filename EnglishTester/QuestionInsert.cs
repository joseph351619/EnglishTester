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
        List<Label> words = new List<Label>();
        int wordsSelectedCount = 0;
        bool questionConfirmed = false;
        public QuestionInsert()
        {
            InitializeComponent();
            cboAnswerType.DataSource = AnswerType.Types();
            cboAnswerType.DisplayMember = AnswerType.DisplayName();
            cboAnswerType.ValueMember = AnswerType.ValueName();
        }


        private void btnStore_Click(object sender, EventArgs e)
        {
            var questionSentence = string.Join(" ", words.Select(a => a.Text));
            Questions question = new Questions() {
                Question = questionSentence,
                Explanation = txtQuestionExplanation.Text,
                Type = (Enums.AnswerType)cboAnswerType.SelectedValue };
            List<Options> answers = new List<Options>();
            answers.Add(new Options() {
                Option = txtAnswer.Text,
                Type = (Enums.AnswerType)cboAnswerType.SelectedValue,
                Explanation = txtAnswerExplanation1.Text,
                IsAnswer = true
            });
            QuestionsBLL BLL = new QuestionsBLL();
            Vocabulary vocabulary = new Vocabulary(txtAnswer.Text);
            BLL.InsertQuestion(question, vocabulary, answers);
            MessageBox.Show("Success");
            txtAnswer.Text = string.Empty;
            txtQuestion.Text = string.Empty;
            questionConfirmed = false;
            txtQuestion.BringToFront();
            txtAnswerExplanation1.Text = string.Empty;
            txtQuestionExplanation.Text = string.Empty;
            wordsSelectedCount = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!questionConfirmed)
            {
                words.Clear();
                questionConfirmed = true;
                string question = txtQuestion.Text;
                string[] questionWords = question.Split(' ');
                int space = 0;
                panel1.Controls.Clear();
                panel1.BringToFront();
                for(int i=0; i< questionWords.Length; ++i)
                {
                    var word = new Label();
                    word.MaximumSize = new Size(100, 0);
                    word.AutoSize = true;
                    word.Text = questionWords[i];
                    word.Name = $"lblQuestionWord{i}";
                    word.MouseClick += QuestionWords_Click;
                    word.Tag = questionWords[i];
                    panel1.Controls.Add(word);
                    word.Left = space;
                    space += 1 + word.Width;
                    words.Add(word);
                }
            }
            else
            {
                wordsSelectedCount = 0;
                txtAnswer.Text = string.Empty;
                questionConfirmed = false;
                txtQuestion.BringToFront();
            }
        }

        private void QuestionWords_Click(object sender, EventArgs e)
        {
            var selectedWord = ((Label)sender).Text;
            if (selectedWord == "____")
            {
                var removeWord = ((Label)sender).Tag.ToString();
                ((Label)sender).Text = removeWord;
                txtAnswer.Text = txtAnswer.Text.Replace(removeWord, "");
                wordsSelectedCount--;
            }
            else
            {
                if (wordsSelectedCount < Configuration.TestWords)
                {
                    ((Label)sender).Text = "____";
                    txtAnswer.Text += string.IsNullOrEmpty(txtAnswer.Text) ? selectedWord : $"...{selectedWord}..." ;
                    wordsSelectedCount++;
                }
                else
                {
                    MessageBox.Show("More than limited selected count");
                }

            }
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }
    }
}
