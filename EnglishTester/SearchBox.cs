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
    public partial class SearchBox : Form
    {
        private string _searchContent;
        public SearchBox()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_Load(object sender, EventArgs e)
        {
            QuestionsBLL bll = new QuestionsBLL();
            //bdsSearch.DataSource =
            //lbSearchResult.DataBindings =
        }
    }
}
