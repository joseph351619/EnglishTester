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
        QuestionsBLL questionsBLL = new QuestionsBLL();
        AnswersBLL answersBLL = new AnswersBLL();
        Questions _currentQuestion = null;
        List<Answers> _currentOption = null;
        bool QuestionConfirm = false;
        Label[] words;
        public QuestionInsert()
        {
            InitializeComponent();
            bdnQuestions.BindingSource = bdsQuestions;
            cboAnswerType.DataSource = AnswerType.Types();
            cboAnswerType.DisplayMember = AnswerType.DisplayName();
            cboAnswerType.ValueMember = AnswerType.ValueName();
        }
        private void QuestionInsert_Load(object sender, EventArgs e)
        {
            this.bdsQuestions.PositionChanged += bdsQuestions_BindingSource_PositionChanged;
            this.bdsQuestions.DataSource = this.questionsBLL.ReadAll();
            TextBoxDataBinding();
        }
        private void TextBoxDataBinding()
        {
            this.txtQuestion.DataBindings.Add(new Binding("Text", bdsQuestions, "Question"));
            this.txtQuestionExplanation.DataBindings.Add(new Binding("Text", bdsQuestions, "Explanation"));
            this.cboAnswerType.DataBindings.Add(new Binding("Text", bdsQuestions, "Type"));
            this.lblInsertTime.DataBindings.Add(new Binding("Text", bdsQuestions, "InsertTime"));
            //this.txtAnswer.DataBindings.Add(new Binding("Answer", _currentOption[0], "Answer"));
            //this.txtAnswerExplanation.DataBindings.Add(new Binding("Explanation", _currentOption[0], "Explanation"));
            //this.txtOption1.DataBindings.Add(new Binding("Answer", _currentOption[0], "Answer"));
            //this.txtOptionExplanation1.DataBindings.Add(new Binding("Explanation", _currentOption[0], "Explanation"));

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
                        textDisplay += string.IsNullOrEmpty(textDisplay) ? "" : " ";
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
        private void bdsQuestions_BindingSource_PositionChanged(object sender, EventArgs e)
        {
            var source = (BindingSource)sender;
            if(source.Position < 0)
            {
                this.bdsQuestions.DataSource = null;
                return;
            }
            this._currentQuestion = (Questions)source.Current;
            this._currentOption = answersBLL.GetAnswers(_currentQuestion.NO).ToList();
            txtAnswer.Text = _currentOption.Where(a => a.IsCorrect).FirstOrDefault().Answer;
            txtAnswerExplanation.Text = _currentOption.Where(a => a.IsCorrect).FirstOrDefault().Explanation;
            var options = _currentOption.Where(a => !a.IsCorrect).ToList();
            if (options.Count() > 0)
            {
                txtOption1.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[0].Answer;
                txtOptionExplanation1.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[0].Explanation;
            }
            if(options.Count() > 1)
            {
                txtOption2.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[1].Answer;
                txtOptionExplanation2.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[1].Explanation;
            }
            if(options.Count() > 2)
            {
                txtOption3.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[2].Answer;
                txtOptionExplanation3.Text = _currentOption.Where(a => !a.IsCorrect).ToList()[2].Explanation;
            }
            //this.bdsOptions.DataSource = answersBLL.GetAnswers(_currentQuestion.NO);
        }

        private void bdsQuestions_AddingNew(object sender, AddingNewEventArgs e)
        {
            var question = new Questions();
            e.NewObject = question;

            List<Answers> answers = new List<Answers>();
            answers.Add(new Answers() { Answer = txtAnswer.Text.Trim(), Type = (Enums.AnswerType)cboAnswerType.SelectedValue, Explanation = txtAnswerExplanation.Text, IsCorrect = true });
            this.questionsBLL.InsertQuestion(question, answers);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var question = (Questions)this.bdsQuestions.Current;
            this.questionsBLL.Delete(question);
        }
    }
}
