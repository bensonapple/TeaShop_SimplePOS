using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using test0118_自己寫class;

namespace test0125_TeaShop
{
    public partial class Form1 : Form
    {
        private DataTable dt_origin;
        private DataTable dtCopy;
        private bool CopyOrnot;
        private string slogan; //跑馬燈的字
        //dt1 = ((DataTable)dataGridView1.DataSource).Clone();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
            dt_origin = new DataTable();
            dtCopy = new DataTable();
            CopyOrnot = true;
            label1.Text = "";
            label2.Text = "";
            label5.Text = "";
            timer1_Tick(sender, e);
            slogan = " 賀!本店開店5周年，即日起至4月19號止，青草茶系列買一送一        珍珠蒟蒻等加料只需5元!     沒錯!加料只需5元!    這麼大的優惠，還不趕快跟風一波!?     ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dt= new DataTable();/// 這是用LINQ to SQL的方式拉資料  但沒辦法拿到實體資料表
            //TeaShopDataContext db = new TeaShopDataContext();
            //string btnName = ((Button)sender).Name;
            //var result = from apple in db.Product_Tea
            //             where apple.ProductCategory == Convert.ToInt32(btnName.Substring(btnName.Length - 1))
            //             select apple;
            //List<Product_Tea> t = result.ToList();

            //dataGridView1.DataSource = t;






            string btnName = ((Button)sender).Name;

            using (SqlConnection road = new SqlConnection(@"Data Source=DESKTOP-N1LVP75\SQLEXPRESS;Initial Catalog=Lab;Integrated Security=True"))
            {
                using (SqlDataAdapter person = new SqlDataAdapter())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = $"select * from Product_Tea where ProductCategory ={Convert.ToInt32(btnName.Substring(btnName.Length - 1))}";
                        cmd.Connection = road;
                        road.Open();
                        person.SelectCommand = cmd;

                        if (dt_origin.Rows.Count != 0)
                        {
                            dt_origin.Clear();
                        }
                        person.Fill(dt_origin);
                        dataGridView1.DataSource = dt_origin;

                    }

                }

            }



            if (CopyOrnot == true)
            {
                dtCopy = ((DataTable)dataGridView1.DataSource).Clone(); //創一個新資料表dtCopy  他擁有和dt_origin一模一樣的結構
                                                                        //只有結構 沒有rows
            }

            CopyOrnot = false;



        }

        private void button10_Click(object sender, EventArgs e)
        {//確認按鈕

            label5.Text = "";


            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dtCopy.ImportRow(((DataTable)dataGridView1.DataSource).Rows[row.Index]);
            }
            dtCopy.AcceptChanges();

            dataGridView2.DataSource = dtCopy;

           
            if (dtCopy.Rows.Count != 0) {
                //dgv反白且下滑至最後一行的資料列
                dataGridView2.CurrentCell = dataGridView2.Rows[dtCopy.Rows.Count - 1].Cells[0];
                dataGridView2.FirstDisplayedScrollingRowIndex = dtCopy.Rows.Count - 1;




                ////計算總金額
                int temp = 0;
                foreach (DataRow item in dtCopy.Rows)
                {
                    temp += Convert.ToInt32(item.ItemArray[2]);// item["ProductPrice"];
                }
                label1.Text = "總計:";
                label2.Text = temp.ToString() + "元";
            }
           



        }

        private void button11_Click(object sender, EventArgs e)
        {//刪除按鈕
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dtCopy.Rows.Remove(dtCopy.Rows[row.Index]);
            }
            dtCopy.AcceptChanges();
            dataGridView2.DataSource = dtCopy;
            // dtCopy.Rows.Remove(dtCopy.Rows[]    )


            if (dtCopy.Rows.Count!=0) {

                ////計算總金額

                int temp = 0;
                foreach (DataRow item in dtCopy.Rows)
                {
                    temp += Convert.ToInt32(item.ItemArray[2]);// item["ProductPrice"];
                }
                label1.Text = "總計:";
                label2.Text = temp.ToString() + "元";


            }


        }

        private void button13_Click(object sender, EventArgs e)
        {//結帳

            if ( textBox1.Text !="") 
            {

                int CustomerPay = Convert.ToInt32(textBox1.Text);
                int ProductCost = Convert.ToInt32(label2.Text.Substring(0, label2.Text.Length - 1));
                if (CustomerPay - ProductCost < 0)
                {
                    MessageBox.Show("請確認金額!!","金額異常警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 
                }
                else {
                    label5.ForeColor = Color.Black;
                    label5.Text = $"找您{(CustomerPay - ProductCost).ToString()}元!";
                    //---------------------------------------------結完帳 要清除購物車裡的項目
                    dtCopy.Clear();
                }
               
            }

          

         
            
            //把購買項目寫入資料庫好印發票?

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label4.Text = DateTime.Now.ToString();

           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string firstword = slogan.Substring(0, 1);

            slogan = slogan.Substring(1, slogan.Length - 1) + firstword;

            label6.Text = slogan;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
