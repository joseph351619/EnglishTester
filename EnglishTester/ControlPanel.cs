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
    public partial class ControlPanel : Form
    {
        public QuestionInsert insertForm = new QuestionInsert();
        public QuestionTest testForm = new QuestionTest();
        public ControlPanel()
        {
            InitializeComponent();
        }
        

        private void btnInsertQuestion_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            insertForm.Visible = true;
            insertForm.ClickEvent += BackAction;
        }
        private void BackAction()
        {
            this.Visible = true;
            insertForm.Visible = false;
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            testForm.Visible = true;
            testForm.ClickEvent += BackControl;
        }
        private void BackControl()
        {
            this.Visible = true;
            testForm.Visible = false;
        }
    }
}
