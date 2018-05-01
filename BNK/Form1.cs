using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace BNK
{
    public partial class Form1 : Form
    {
        FormAdd Form2 = null;
        DBF BNKSEEK = DBF.GetInstance();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ToolTip tlt = new ToolTip();
            tlt.SetToolTip(BTN_Add, "Добавить элемент");
            tlt.SetToolTip(BTN_Del, "Удалить элемент");
            tlt.SetToolTip(BTN_RefreshData, "Обновить данные");
            tlt.SetToolTip(BTN_Copy, "Добавить элемент копированием");
            tlt.SetToolTip(BTN_Edit, "Редактировать элемент");
            RefreshDataGrid();
            foreach (string key in BNKSEEK.pzn.Keys)
            {
                CMB_PZN.Items.Add(key);
            }
            CMB_PZN.Sorted = true;
            TB_BIK.Enabled = false;
            TB_RGN.Enabled = false;
            CMB_PZN.Enabled = false;
        }

        private void BTN_Filter_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Visible = ((!CHB_PZN.Checked || dataGridView1[1, i].Value.ToString() == CMB_PZN.SelectedItem.ToString()) && (!CHB_RGN.Checked || (dataGridView1[3, i].Value.ToString().IndexOf(TB_RGN.Text) >= 0)) && (!CHB_BIK.Checked || (dataGridView1[10, i].Value.ToString().IndexOf(TB_BIK.Text) >= 0)));
        }

        public void BTN_RFilter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].Visible = true;
            CHB_BIK.Checked = false;
            TB_BIK.Text = "";
            CHB_RGN.Checked = false;
            TB_RGN.Text = "";
            CHB_PZN.Checked = false;
            CMB_PZN.SelectedItem = null;
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            Form2 = new FormAdd(this);
            Form2.Show();
        }

        public void RefreshDataGrid()
        {
            if (dataGridView1.CurrentRow != null)
                RefreshDataGrid(dataGridView1.CurrentRow.Index);
            else
                RefreshDataGrid(0);
        }
        public void RefreshDataGrid(int index)
        {
            BNKSEEK.Execute(@"select bnkseek.real, (select pzn.name from pzn where bnkseek.pzn=pzn.pzn) as pzn, (select uer.uername from uer where bnkseek.uer=uer.uer) as uer,
                    (select reg.name from reg where bnkseek.rgn=reg.rgn) as rgn, bnkseek.ind, (select tnp.fullname from tnp where bnkseek.tnp=tnp.tnp) as tnp, bnkseek.nnp, bnkseek.adr, bnkseek.rkc,
                    bnkseek.namep, bnkseek.newnum, bnkseek.telef, bnkseek.regn, bnkseek.okpo, bnkseek.dt_izm, bnkseek.ksnp, bnkseek.date_in, bnkseek.date_ch from bnkseek;");
            dataGridView1.DataSource = BNKSEEK.ds.Tables[0];
            if (index < 0) index = 0;
            if (index > dataGridView1.Rows.Count - 1) index = dataGridView1.Rows.Count - 1;
            dataGridView1.CurrentCell=dataGridView1[0,index];
        }

        private void BTN_Edit_Click(object sender, EventArgs e)
        {
            if (Form2 == null || Form2.IsDisposed) { Form2 = new FormAdd(this); }
            Form2.Show(dataGridView1.CurrentRow, dataGridView1.CurrentRow.Index);
        }

        private void BTN_Copy_Click(object sender, EventArgs e)
        {
            if (Form2 == null || Form2.IsDisposed) { Form2 = new FormAdd(this); }
            Form2.Show(dataGridView1.CurrentRow);
        }

        private void BTN_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BNKSEEK.ExecuteNonQ("delete from bnkseek where newnum='" + dataGridView1.CurrentRow.Cells["newnum"].Value.ToString() + "';");
                RefreshDataGrid(dataGridView1.CurrentRow.Index - 1);
            }
        }

        private void BTN_RefreshData_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void CHB_BIK_CheckedChanged(object sender, EventArgs e)
        {
            TB_BIK.Enabled = CHB_BIK.Checked;
            BTN_Filter.Enabled = CHB_BIK.Checked || CHB_PZN.Checked || CHB_RGN.Checked;
        }

        private void CHB_RGN_CheckedChanged(object sender, EventArgs e)
        {
            TB_RGN.Enabled = CHB_RGN.Checked;
            BTN_Filter.Enabled = CHB_BIK.Checked || CHB_PZN.Checked || CHB_RGN.Checked;
        }

        private void CHB_PZN_CheckedChanged(object sender, EventArgs e)
        {
            CMB_PZN.Enabled = CHB_PZN.Checked;
            BTN_Filter.Enabled = CHB_BIK.Checked || CHB_PZN.Checked || CHB_RGN.Checked;
        }


    }
}
