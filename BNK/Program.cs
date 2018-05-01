using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace BNK
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  
        }
    }

    public class DBF
    {
        private static DBF Instance;
        public string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Application.StartupPath+"\\DBF\\;Extended Properties=dBASE IV";
        public OleDbConnection conn;
        public DataSet ds;
        public Dictionary<string, string> rgn = new Dictionary<string, string>();
        public Dictionary<string, string> pzn = new Dictionary<string, string>();
        public Dictionary<string, string> tnp = new Dictionary<string, string>();
        public Dictionary<string, string> uer = new Dictionary<string, string>();
        public List<string> bik = new List<string>();
        public DataSet Execute(string Command)
        {
            conn = new OleDbConnection(ConnectionString);
            OleDbDataAdapter oledbAdapter;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = Command;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                ds = new DataSet();
                oledbAdapter.Fill(ds);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }

        public void ExecuteNonQ(string Command)
        {
            conn = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = Command;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public void refresh()
        {
            conn = new OleDbConnection(ConnectionString);
            DataSet d = new DataSet();
            OleDbDataAdapter oledbAdapter;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select newnum from bnkseek;";
            try
            {
                conn.Open();
                cmd.Connection = conn;
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    bik.Add(item.ItemArray[0].ToString());
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetValue(string bik, string field)
        {
            conn = new OleDbConnection(ConnectionString);
            DataSet d = new DataSet();
            OleDbDataAdapter oledbAdapter;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select " + field + " from bnkseek where newnum='" + bik + "';";
            try
            {
                conn.Open();
                cmd.Connection = conn;
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                oledbAdapter.Fill(d);
                return d.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        protected DBF()
        {
            conn = new OleDbConnection(ConnectionString);
            DataSet d = new DataSet();
            OleDbDataAdapter oledbAdapter;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select rgn,name from reg;";
            try
            {
                conn.Open();
                cmd.Connection = conn;
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    rgn.Add(item.ItemArray[1].ToString(), item.ItemArray[0].ToString());
                }
                cmd.CommandText = "select newnum from bnkseek;";
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                d = new DataSet();
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    bik.Add(item.ItemArray[0].ToString());
                }
                cmd.CommandText = "select pzn,name from pzn;";
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                d = new DataSet();
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    pzn.Add(item.ItemArray[1].ToString(), item.ItemArray[0].ToString());
                }
                cmd.CommandText = "select uer,uername from uer;";
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                d = new DataSet();
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    uer.Add(item.ItemArray[1].ToString(), item.ItemArray[0].ToString());
                }
                cmd.CommandText = "select tnp,fullname from tnp;";
                oledbAdapter = new OleDbDataAdapter(cmd.CommandText, conn);
                d = new DataSet();
                oledbAdapter.Fill(d);
                foreach (DataRow item in d.Tables[0].Rows)
                {
                    tnp.Add(item.ItemArray[1].ToString(), item.ItemArray[0].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

        }
       
       public static DBF GetInstance() 
        {
            if (Instance == null)
                Instance = new DBF();
            return Instance;
        }
    }
}

