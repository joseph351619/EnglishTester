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
        List<Options> Options;
        bool QuestionStatus = false;
        public QuestionTest()
        {
            InitializeComponent();
        }
        public void QuestionInitiate()
        {
            pnlAnswer.Hide();
            QuestionsBLL bll = new QuestionsBLL();
            List<int> questionNos = bll.GetAllQuestionsNo();
            Random random = new Random();
            int questionNo = 0;
            if (questionNos.Count() > 0)
                questionNo = questionNos[random.Next(questionNos.Count())];
            Questions questions = bll.GetQuestions(questionNo);
            VocabularyBLL vocabularyBLL = new VocabularyBLL();
            lblQuestion.Text = questions.Question;
            rtxtQuestionExplanation.Text = questions.Explanation;
            rtxtAnswerExplanation.Text = Options.Where(a => a.IsAnswer).FirstOrDefault().Explanation;
            lblCorrectAnswer.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmAction();
        }
        private void ConfirmAction()
        {
            //bool success = false;
            var option = Options.Where(a => a.IsAnswer).FirstOrDefault();
            if (txtAnswer.Text.Trim() == option.Content)
            {
                lblResult.Text = "True";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblCorrectAnswer.Text = option.Content;
                lblResult.Text = "Fail";
                lblResult.ForeColor = Color.Red;
            }
            pnlAnswer.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            QuestionInitiate();
        }

        private void QuestionTest_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (QuestionStatus)
                {
                    QuestionStatus = false;
                    QuestionInitiate();
                }
                else
                {
                    QuestionStatus = true;
                    ConfirmAction();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
