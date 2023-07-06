using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace bazadanych
{
    public partial class Form1 : Form
    {
        string joined = "SELECT imie,nazwisko,rodzaj,kiedy,zboze_id,ile FROM `zboze` JOIN op on op.zboze_id =id_zboze JOIN klient on klient.id_klient  = op.klient_id where id_op<20 ";
        string connstr = "DataBase=skup_rolny;Data source=localhost;User id=root;Password=";
        MySqlConnection conn;
        //string 
        Dictionary<string, int> klienci;

        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection(connstr);
            getandsetklienci();
            listView1.Items.Add(new ListViewItem(new string[]{"a" ,"b"}));
        }
        void getandsetklienci()
        {
            klienci = new Dictionary<string, int>();
            foreach (var item in getdata("select imie,nazwisko,id_klient from klient"))
            {
                checkedListBox1.Items.Add(item.GetValue(0)+""+item.GetValue(1)+ "(" + item.GetValue(2)+")");
                klienci.Add(item.GetValue(0) + "" + item.GetValue(1) + "(" + item.GetValue(2) + ")", (int)item.GetValue(2));

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            string cs = "DataBase=skup_rolny;Data source=localhost;User id=root;Password=";
            string query = "select *  from  zboze ";

            MySqlConnection x = new MySqlConnection(cs);
            

            MySqlCommand xd = new MySqlCommand(query,x);
            xd.Connection.Open();
            xd.ExecuteNonQuery();
            MySqlDataReader reader =  xd.ExecuteReader();
            Text = x.ServerVersion;
           


            x.Close();
        }
        IEnumerable<IDataRecord> getdata(string query,bool  returns =true )
        {
            List<IDataRecord> arr=new List<IDataRecord>();
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            if (returns)
            {
                foreach (IDataRecord item in command.ExecuteReader())
                {
                    arr.Add(item);
                }
            }
            else
            {
                arr = null; 
                 command.ExecuteNonQuery();
            }
            conn.Close();
            return arr;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = "";
            List<ListViewItem> lista = new List<ListViewItem>();
            string dododania = "and rodzaj like \""+ (string)comboBox1.SelectedItem+"\"";
            string query = joined + dododania;
            listView1.Items.Clear();

            //Console.WriteLine(query);
            foreach (IDataRecord item in getdata(query))
            {                
                x += $"{ item.GetValue(0),-10}";
                x += $"{ item.GetValue(1),-15}";
                x += $"{ item.GetValue(2),-10}";
                x += $"{ item.GetValue(3),-10}";
                x += $"{ item.GetValue(4),-10}";
                x += $"{ item.GetValue(5),-10}";
                List<string> tab = new List<string>();


                for (int i = 0; i < 6; i++)
                {
                    tab.Add(item.GetValue(i).ToString());
                }
                //lista.Add(new ListViewItem(tab.ToArray()));
                listView1.Items.Add(new ListViewItem(tab.ToArray()));
                x += "\r\n";
            }
            //listView1.Items.Clear();
            //listView1.Items.AddRange(lista.ToArray());
            textBox1.Text = x;            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ListViewItem> lista = new List<ListViewItem>();
            string dododania = " and ( ";
            string query = joined ;
            if(checkedListBox1.CheckedItems.Count != 0)
            {
               
                dododania += " klient_id = " + klienci[checkedListBox1.CheckedItems[0].ToString()];
                if(checkedListBox1.CheckedItems.Count > 1)
                {
                    for (int i = 1; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        dododania += " or " + " klient_id = " + klienci[checkedListBox1.CheckedItems[i].ToString()];
                    }
                }
                
                query += dododania +")";
            }

            listView1.Items.Clear();

            //Console.WriteLine(query);
            foreach (IDataRecord item in getdata(query))
            {
              
                List<string> tab = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    tab.Add(item.GetValue(i).ToString());
                }
            
                listView1.Items.Add(new ListViewItem(tab.ToArray()));
               
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 tmp = new Form2();
            if(tmp.ShowDialog()== DialogResult.OK)
            {
                string query = $"insert into klient values(null,{tmp.textBox1.Text},{tmp.textBox2.Text},{tmp.textBox3.Text},{tmp.radioButton1.Checked})";
                getdata(query,false);



            }
        }
    }
}
