using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNK
{
    public partial class FormAdd : Form
    {
        private Form1 MainForm;
        private int index=-1;                      //индекс редактируемой записи в DataGrid
        private DataGridViewRow row = null;     //текущая запись в DataGrid
        DBF BNKSEEK = DBF.GetInstance();        

        public FormAdd(Form1 f)
        {
            InitializeComponent();
            MainForm = f;            
        }
        public FormAdd()
        {
            InitializeComponent();
        }

        public void Show(DataGridViewRow row)//---------Показываем форму при добавлении записи копированием
        {
            this.row = row;
            base.Show();
            TB_REAL.Text = row.Cells["real"].Value.ToString();
            TB_IND.Text = row.Cells["ind"].Value.ToString();
            TB_NNP.Text = row.Cells["nnp"].Value.ToString();
            TB_ADR.Text = row.Cells["adr"].Value.ToString();
            TB_RKC.Text = row.Cells["rkc"].Value.ToString();
            TB_NAMEP.Text = row.Cells["namep"].Value.ToString();
            TB_BIK.Text = row.Cells["newnum"].Value.ToString();
            TB_NAMEN.Text = BNKSEEK.GetValue(TB_BIK.Text, "namen");
            TB_SROK.Text = BNKSEEK.GetValue(TB_BIK.Text, "srok");
            TB_TELEF.Text = row.Cells["telef"].Value.ToString();
            TB_REGN.Text = row.Cells["regn"].Value.ToString();
            TB_OKPO.Text = row.Cells["okpo"].Value.ToString();
            TB_KSNP.Text = row.Cells["ksnp"].Value.ToString();


            CMB_PZN.SelectedItem = CMB_PZN.Items[CMB_PZN.FindString(row.Cells["pzn"].Value.ToString())];
            CMB_UER.SelectedItem = CMB_UER.Items[CMB_UER.FindString(row.Cells["uer"].Value.ToString())];
            CMB_RGN.SelectedItem = CMB_RGN.Items[CMB_RGN.FindString(row.Cells["rgn"].Value.ToString())];
            CMB_TNP.SelectedItem = CMB_TNP.Items[CMB_TNP.FindString(row.Cells["tnp"].Value.ToString())];

            if (row.Cells["date_ch"].Value.ToString() != "")
            {
                CHB_DateCh.Checked = true;
                DTP_DateCh.Value = DateTime.Parse(row.Cells["date_ch"].Value.ToString());
            }
            else CHB_DateCh.Checked = false;

            FormAdd.ActiveForm.Text = "Добавление записи";
        }

        internal void Show(DataGridViewRow row, int index)//---------Показываем форму при редактировании записи
        {
            this.Show(row);
            this.index = index;
            FormAdd.ActiveForm.Text = "Редактирование записи";
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, string> Params = new Dictionary<string, string>();
            string date_izm = DateTime.Now.Date.ToString().Substring(0, 10), date_in = DateTime.Now.Date.ToString().Substring(0, 10); 

            if (Validation())
            {
                string cmd,pzn, tnp;
                if (CMB_PZN.SelectedItem == null) pzn = ""; else pzn = BNKSEEK.pzn[CMB_PZN.SelectedItem.ToString()];
                if (CMB_TNP.SelectedItem == null) tnp = ""; else tnp = BNKSEEK.tnp[CMB_TNP.SelectedItem.ToString()];
                Params["real"] = TB_REAL.Text; 
                Params["nnp"] = TB_NNP.Text; 
                Params["srok"] = TB_SROK.Text;
                Params["pzn"] = pzn; 
                Params["adr"] = TB_ADR.Text; 
                Params["telef"] = TB_TELEF.Text;
                Params["uer"] = BNKSEEK.uer[CMB_UER.SelectedItem.ToString()]; 
                Params["rkc"] = TB_RKC.Text; 
                Params["regn"] = TB_REGN.Text;
                Params["rgn"] = BNKSEEK.rgn[CMB_RGN.SelectedItem.ToString()]; 
                Params["namep"] = TB_NAMEP.Text; 
                Params["okpo"] = TB_OKPO.Text;
                Params["ind"] = TB_IND.Text; 
                Params["namen"] = TB_NAMEN.Text; 
                Params["dt_izm"] = date_izm;
                Params["tnp"] = tnp; 
                Params["newnum"] = TB_BIK.Text; 
                Params["ksnp"] = TB_KSNP.Text;
                Params["date_in"] = date_in;
                if (DTP_DateCh.Enabled) 
                {
                    Params["date_ch"] = DTP_DateCh.Value.ToString().Substring(0, 10);
                }

                //if (DTP_DateCh.Enabled)
                //{
                //    if (index == -1)
                //        cmd = String.Format("insert into bnkseek ([real],[pzn],[uer],[rgn],[ind],[tnp],[nnp],[adr],[rkc],[namep],[namen],[newnum],[srok],[telef],[regn],[okpo],[dt_izm],[ksnp],[date_in],[date_ch]) values " +
                //            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}');", TB_REAL.Text, pzn, BNKSEEK.uer[CMB_UER.SelectedItem.ToString()],
                //            BNKSEEK.rgn[CMB_RGN.SelectedItem.ToString()], TB_IND.Text, tnp, TB_NNP.Text, TB_ADR.Text, TB_RKC.Text, TB_NAMEP.Text, TB_NAMEN.Text,
                //            TB_BIK.Text, TB_SROK.Text, TB_TELEF.Text, TB_REGN.Text, TB_OKPO.Text, date_izm, TB_KSNP.Text, date_in, DTP_DateCh.Value.ToString().Substring(0, 10));
                //    else
                //        cmd = String.Format("update bnkseek set [real]='{0}',[pzn]='{1}',[uer]='{2}',[rgn]='{3}',[ind]='{4}',[tnp]='{5}',[nnp]='{6}',[adr]='{7}',[rkc]='{8}',[namep]='{9}',[namen]='{10}',[newnum]='{11}',[srok]='{12}',[telef]='{13}',[regn]='{14}',[okpo]='{15}'," +
                //            "[dt_izm]='{16}',[ksnp]='{17}',[date_ch]='{18}' where [newnum]='{19}';", TB_REAL.Text, BNKSEEK.pzn[CMB_PZN.SelectedItem.ToString()], BNKSEEK.uer[CMB_UER.SelectedItem.ToString()],
                //            BNKSEEK.rgn[CMB_RGN.SelectedItem.ToString()], TB_IND.Text, BNKSEEK.tnp[CMB_TNP.SelectedItem.ToString()], TB_NNP.Text, TB_ADR.Text, TB_RKC.Text, TB_NAMEP.Text, TB_NAMEN.Text,
                //            TB_BIK.Text, TB_SROK.Text, TB_TELEF.Text, TB_REGN.Text, TB_OKPO.Text, date_izm, TB_KSNP.Text, DTP_DateCh.Value.ToString().Substring(0, 10), row.Cells["newnum"].Value.ToString());
                //}
                //else
                //{
                //    if (index == -1)
                //        cmd = String.Format("insert into bnkseek ([real],[pzn],[uer],[rgn],[ind],[tnp],[nnp],[adr],[rkc],[namep],[namen],[newnum],[srok],[telef],[regn],[okpo],[dt_izm],[ksnp],[date_in]) values " +
                //            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}');", TB_REAL.Text, pzn, BNKSEEK.uer[CMB_UER.SelectedItem.ToString()],
                //            BNKSEEK.rgn[CMB_RGN.SelectedItem.ToString()], TB_IND.Text, tnp, TB_NNP.Text, TB_ADR.Text, TB_RKC.Text, TB_NAMEP.Text, TB_NAMEN.Text,
                //            TB_BIK.Text, TB_SROK.Text, TB_TELEF.Text, TB_REGN.Text, TB_OKPO.Text, date_izm, TB_KSNP.Text, date_in);
                //    else
                //        cmd = String.Format("update bnkseek set [real]='{0}',[pzn]='{1}',[uer]='{2}',[rgn]='{3}',[ind]='{4}',[tnp]='{5}',[nnp]='{6}',[adr]='{7}',[rkc]='{8}',[namep]='{9}',[namen]='{10}',[newnum]='{11}',[srok]='{12}',[telef]='{13}',[regn]='{14}',[okpo]='{15}'," +
                //            "[dt_izm]='{16}',[ksnp]='{17}' where [newnum]='{18}';", TB_REAL.Text, BNKSEEK.pzn[CMB_PZN.SelectedItem.ToString()], BNKSEEK.uer[CMB_UER.SelectedItem.ToString()],
                //            BNKSEEK.rgn[CMB_RGN.SelectedItem.ToString()], TB_IND.Text, BNKSEEK.tnp[CMB_TNP.SelectedItem.ToString()], TB_NNP.Text, TB_ADR.Text, TB_RKC.Text, TB_NAMEP.Text, TB_NAMEN.Text,
                //            TB_BIK.Text, TB_SROK.Text, TB_TELEF.Text, TB_REGN.Text, TB_OKPO.Text, date_izm, TB_KSNP.Text, row.Cells["newnum"].Value.ToString());
                //}
                try
                {
                    BNKSEEK.ExecuteNonQ(fillcmd(Params, index));
                    //BNKSEEK.ExecuteNonQ(cmd);
                    BNKSEEK.refresh();
                    MainForm.RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                FormAdd.ActiveForm.Hide();
            }
        }

        public string fillcmd (Dictionary<string, string> values, int ind)
        {
            string str1 = "", str2 = "", str3 = "";
                    foreach (var p in values)
                    {
                        str1 += "["+ p.Key + "],";
                        str2 += "'"+ p.Value + "',";
                        if (p.Key != "newnum")
                            str3 += "[" + p.Key + "]='" + p.Value + "',";
                    }
                    if (ind == -1)
                    {
                        return "insert into bnkseek (" + str1.Remove(str1.Length - 1) + ") values (" + str2.Remove(str2.Length - 1) + ");";
                    }
                    else
                    {
                        if (values.ContainsKey("newnum"))
                        {
                            return "update bnkseek set " + str3.Remove(str3.Length - 1) + " where [newnum]='" + values["newnum"] + "';";
                        }
                        else
                        {
                            MessageBox.Show("Не выбрана запись");
                            return "";
                        }
                    }
        }
        

        private void FormAdd_Load(object sender, EventArgs e)
        {
            //---------заполняем выпадающие списки значениями из BNKSEEK
            foreach (string key in BNKSEEK.pzn.Keys)
            {
                CMB_PZN.Items.Add(key);
            }
            CMB_PZN.Sorted = true;
            foreach (string key in BNKSEEK.uer.Keys)
            {
                CMB_UER.Items.Add(key);
            }
            CMB_UER.Sorted = true;
            foreach (string key in BNKSEEK.rgn.Keys)
            {
                CMB_RGN.Items.Add(key);
            }
            CMB_RGN.Sorted = true;
            foreach (string key in BNKSEEK.tnp.Keys)
            {
                CMB_TNP.Items.Add(key);
            }
            CMB_TNP.Sorted = true;

            DTP_DateCh.Enabled = false;
        }

        private bool Validation()
        {
            if (TB_NAMEN.Text == "" || TB_NAMEP.Text == "" || TB_BIK.Text == "" || TB_SROK.Text == "" || CMB_RGN.SelectedItem == null || CMB_UER.SelectedItem == null)
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return false;
            }
            if (BNKSEEK.bik.Contains(TB_BIK.Text) && (index==-1 || TB_BIK.Text != row.Cells["newnum"].Value.ToString()))
            {
                MessageBox.Show("Организация с таким БИК уже присутствует в системе!");
                return false;
            }
            return true;
        }

        private void CHB_DateCh_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DateCh.Enabled = CHB_DateCh.Checked;
        }

    }
}
