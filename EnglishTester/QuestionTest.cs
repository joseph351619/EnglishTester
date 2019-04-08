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
        public List<Answers> answers = new List<Answers>();
        public QuestionTest()
        {
            InitializeComponent();
        }
        public void QuestionInitiate()
        {
            QuestionsBLL bll = new QuestionsBLL();
            List<int> questionNos = bll.GetAllQuestionsNo();
            Random random = new Random();
            int questionNo = 0;
            if (questionNos.Count() > 0)
                questionNo = questionNos[random.Next(questionNos.Count())];
            Questions questions = bll.GetQuestions(questionNo);
            VocabularyBLL vocabularyBLL = new VocabularyBLL();
            lblQuestion.Text = questions.Question;
            answers.Add( new Answers(1, questions.Vocabulary.Word, true));
            //lblAnswer1.Text = Options[0];
            //lblAnswer2.Text = Options[1];
            //lblAnswer3.Text = Options[2];
            //lblAnswer4.Text = Options[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            //if (rdoAnswer1.Checked && Options[0].IsCorrect)
            //    success = true;
            //if (rdoAnswer2.Checked && Options[1].IsCorrect)
            //    success = true;
            //if (rdoAnswer3.Checked && Options[2].IsCorrect)
            //    success = true;
            //if (rdoAnswer4.Checked && Options[3].IsCorrect)
            //    success = true;
            if (answers.Where(a => a.IsAnswer).FirstOrDefault().Content == txtAnswer.Text.Trim())
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

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            QuestionInitiate();
        }
    }
}
