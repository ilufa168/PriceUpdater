using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.Oracle;
using Dapper;
using System.IO;

namespace PriceUpdater
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.TB_PCN_NO.Text.Length == 0)
                return;

            string keyval = this.TB_PCN_NO.Text;
            OracleManager om = new OracleManager("192.168.1.9");

            IDbConnection conn = om.connect();

            List<PCN_D> items = conn.Query<PCN_D>("Select * from PCN_D where PCN_NO ='" + keyval + "'").ToList();

            foreach (PCN_D pc in items)
            {
                string sql = @"
                        update item 
                        set UNIT_RETAIL = " + pc.NEW_RETAIL + "," +
                        "UPDATE_DATE = TO_DATE('" + DateTime.Now.ToString("MM/dd/yyyy")+"','MM/DD/YYYY'),"+
                         "UPDATE_BY = 'AUTO' " +
                         "WHERE ITEM_CODE = '" + pc.ITEM_CODE + "'";
                try
                {
                    conn.Execute(sql);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            MessageBox.Show(items.Count().ToString());
            //Load all the records with a price change
        }

        private void bSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                textBox1.Text = openFileDialog1.FileName;

            }
        }

        private void UpdatePCN(List<ItemPrice> ip_list)
        {
            OracleManager om = new OracleManager("192.168.1.9");

            IDbConnection conn = om.connect();
            foreach (ItemPrice ip in ip_list)
            {
                string sql = @"
                        update item
                        set UNIT_RETAIL = " + ip.price + "," +
                        "TXT=''," + 
                        "UPDATE_DATE = TO_DATE('" + DateTime.Now.ToString("MM/dd/yyyy") + "','MM/DD/YYYY')," +
                         "UPDATE_BY = 'AUTO' " +
                         "WHERE ITEM_CODE = '" + ip.item_id + "'";
                try
                {
                    conn.Execute(sql);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;

            //Make sure file exists 
            FileInfo fi = new FileInfo(textBox1.Text);

            if (!fi.Exists)
            {
                MessageBox.Show("Cannot find the file yo.");
                return;
            }
            FileStream fs = fi.OpenRead();
            string buffer;
            using (System.IO.StreamReader rdr = new System.IO.StreamReader(fs))
            {
                buffer = rdr.ReadToEnd();
            }

            List<ItemPrice> price_list = new List<ItemPrice>();
            string[] lines = buffer.Split(
                new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string a_line in lines)
            {
                if (a_line.Length == 0)
                    continue;

                string[] splits = a_line.Split(';');
                ItemPrice an_item = new ItemPrice();
                an_item.item_id = splits[0];
                an_item.price = double.Parse(splits[1]);
                price_list.Add(an_item);
            }

            UpdatePCN(price_list);
        }
    }

    struct ItemPrice
    {
        public string item_id;
        public double price;
    }

    class OracleManager
    {
        //public static IEnumerable<T> Query<T>(this IDbConnection cnn, string sql, object param = null, SqlTransaction transaction = null, bool buffered = true)

        private string HostIP = "192.168.1.9";
        public List<string> error_list = new List<string>();
        public OracleManager(string HIP)
        {
            this.HostIP = HIP;
        }

        public OracleConnection connect()
        {
            OracleConnection oc = null;

            //Build the key
            OracleConnectionStringBuilder oraCSB = new OracleConnectionStringBuilder();
            oraCSB.Direct = true;
            oraCSB.Server = HostIP;
            oraCSB.Port = 1521;
            oraCSB.UserId = "erp";
            oraCSB.Password = "erp";
            oraCSB.ConnectionTimeout = 30;

            oc = new OracleConnection(oraCSB.ConnectionString);


            return oc;
        }
    }

    public class PCN_D
    {
        public String PCN_NO { get; set; }
        public DateTime PCN_DATE { get; set; }
        public String ITEM_CODE { get; set; }
        public Double NEW_COST { get; set; }
        public Double NEW_RETAIL { get; set; }
        public string PCN_REASON { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public String UPDATE_BY { get; set; }
        public string TABLE_NAME = "PCN_D";
    }

}
