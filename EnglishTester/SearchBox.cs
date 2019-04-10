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
    public partial class SearchBox : Form
    {
        private string _searchContent = string.Empty;
        QuestionSourceBLL bll = new QuestionSourceBLL();
        public int SourceID;
        public string SourceName;
        public delegate void ClickEventHandler();
        public event ClickEventHandler ConfirmEvent;
        public event ClickEventHandler CancelEvent;
        public SearchBox()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchContent = txtSearch.Text;
            bdsSearch.DataSource = bll.SearchSource(_searchContent);
        }

        

        private void SearchBox_Load(object sender, EventArgs e)
        {
            bdsSearch.DataSource = bll.SearchSource(_searchContent);
            lbSearchResult.DataSource = bdsSearch;
            lbSearchResult.ValueMember = "ID";
            lbSearchResult.DisplayMember = "Source";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(lbSearchResult.SelectedItems.Count > 0 || lbSearchResult.Items.Count==1)
            {
                SourceID = (int)lbSearchResult.SelectedValue;
                SourceName = ((QuestionSource)lbSearchResult.SelectedItem).Source;
            }
            if(lbSearchResult.Items.Count == 0)
            {
                QuestionSource source = new QuestionSource(txtSearch.Text);
                bll.Add(source);
                SourceID = source.ID;
                SourceName = source.Source;
            }
            txtSearch.Text = string.Empty;
            ConfirmEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            CancelEvent();
        }

        private void SearchBox_Deactivate(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            CancelEvent();
        }
    }
}
