using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace The_Error_Application
{
    public partial class frmProgramLang : Form
    {
        public frmProgramLang()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgLanguage prog = new ProgLanguage();
            prog.ProgLanguageDesc = txtDescription.Text;

            int x = bll.InsertProgLanguage(prog);
            if (x > 0)
            {
                MessageBox.Show(x + " Added!");
            }
            else
            {
                MessageBox.Show(x + " Added!");
            }
        }

        private void dgvProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get all details at specified row and inserting into a datatable 
            DataTable dt = new DataTable();
            dt = bll.GetProgLanguageByID(int.Parse(dgvProgram.SelectedRows[0].Cells["ProgLanguageID"].Value.ToString()));
            //displaying specific column at textbox
            txtDescription.Text = dt.Rows[0]["ProgLanguageDesc"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProgLanguage prog = new ProgLanguage();
            prog.ProgLanguageDesc = txtDescription.Text;
            prog.ProgLanguageID = int.Parse(dgvProgram.SelectedRows[0].Cells["ProgLanguageID"].Value.ToString());

            int x = bll.UpdateProgLanguage(prog);
            if(x>0)
            {
                MessageBox.Show(x + " Updated!!");
            }
            else
            {
                MessageBox.Show(x + " Updated!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProgLanguage prog = new ProgLanguage();
            prog.ProgLanguageID = int.Parse(dgvProgram.SelectedRows[0].Cells["ProgLanguageID"].Value.ToString());

            int x = bll.DeleteProgLanguage(prog);
            if (x > 0)
            {
                MessageBox.Show(x + " Row Deleted!!");
            }
            else
            {
                MessageBox.Show(x + " Row Deleted!!");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvProgram.DataSource = bll.GetProgLanguage();
        }
    }
}
