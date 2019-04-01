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

namespace EnglishTester
{
    public partial class QuestionInsert : Form
    {
        public QuestionInsert()
        {
            InitializeComponent();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            Questions question = new Questions() { Question = txtQuestion.Text, Explanation = txtQuestionExplanation.Text };
            List<Answers> answers = new List<Answers>();
            answers.Add(new Answers() { Answer = txtAnswer1.Text, Explanation = txtAnswerExplanation1.Text, IsCorrect = rdoAnswer1.Checked });
            answers.Add(new Answers() { Answer = txtAnswer2.Text, Explanation = txtAnswerExplanation2.Text, IsCorrect = rdoAnswer2.Checked });
            answers.Add(new Answers() { Answer = txtAnswer3.Text, Explanation = txtAnswerExplanation3.Text, IsCorrect = rdoAnswer3.Checked });
            answers.Add(new Answers() { Answer = txtAnswer4.Text, Explanation = txtAnswerExplanation4.Text, IsCorrect = rdoAnswer4.Checked });
            QuestionsBLL BLL = new QuestionsBLL();
            BLL.InsertQuestion(question, answers);
            MessageBox.Show("Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;
            string[] questionWords = question.Split(' ');
            Label[] words = new Label[questionWords.Length];
            int space = 0;
            for(int i=0; i< questionWords.Length; ++i)
            {
                words[i] = new Label();
                words[i].Text = questionWords[i];
                words[i].Name = $"lblQuestionWord{i}";
                words[i].MouseClick += QuestionWords_Click;
                words[i].Left = space;
                space += 50;
                words[i].Size = new Size(50, 22);
                panel1.Controls.Add(words[i]);
            }
        }

        private void QuestionWords_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);
        }
    }
}
