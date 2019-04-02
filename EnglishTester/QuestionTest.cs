using EnglishTester.BLL;
using EnglishTester.Data;
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
    public partial class QuestionTest : Form
    {
        public delegate void ClickEventHandler();
        public event ClickEventHandler ClickEvent;
        List<Answers> Answers;
        public QuestionTest()
        {
            InitializeComponent();
            QuestionInitiate();
        }
        public void QuestionInitiate()
        {
            QuestionsBLL bll = new QuestionsBLL();
            List<int> questionNos = bll.GetAllQuestionsNo();
            Random random = new Random();
            int questionNo = questionNos[random.Next(questionNos.Count())];
            Questions questions = bll.GetQuestions(questionNo);
            AnswersBLL answerBLL = new AnswersBLL();
            Answers = answerBLL.GetAnswers(questionNo).ToList();
            lblQuestion.Text = questions.Question;
            lblAnswer1.Text = Answers[0].Answer;
            lblAnswer2.Text = Answers[1].Answer;
            lblAnswer3.Text = Answers[2].Answer;
            lblAnswer4.Text = Answers[3].Answer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (rdoAnswer1.Checked && Answers[0].IsCorrect)
                success = true;
            if (rdoAnswer2.Checked && Answers[1].IsCorrect)
                success = true;
            if (rdoAnswer3.Checked && Answers[2].IsCorrect)
                success = true;
            if (rdoAnswer4.Checked && Answers[3].IsCorrect)
                success = true;
            if (success)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Fail");

            QuestionInitiate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }
    }
}
