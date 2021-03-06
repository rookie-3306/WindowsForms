using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DatabaseHelper.OpenGetSqlConnection();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql = "SELECT * FROM Customer";
            DataSet ds = new DataSet();
            DatabaseHelper.GetSqlDataAdapter(sql).Fill(ds, "temp");
            dataGridView1.DataSource = ds.Tables["temp"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Customer(CustomerID,CustomerSimpleName,CustomerName,Owner,Title,Telephone,MobilePhone,Fax,SalesManId,CustomerAddress,DeliveryAddress,InvoiceAddress,LastDeliveryDate)" +
                         "values(@CustomerID, @CustomerSimpleName, @CustomerName, @Owner, @Title, @Telephone, @MobilePhone, @Fax, @SalesManId, @CustomerAddress, @DeliveryAddress, @InvoiceAddress, @LastDeliveryDate)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", textBox1.Text),
                new SqlParameter("@CustomerSimpleName", textBox2.Text),
                new SqlParameter("@CustomerName", textBox3.Text),
                new SqlParameter("@Owner", textBox4.Text),
                new SqlParameter("@Title", comboBox1.Text),
                new SqlParameter("@SalesManId", comboBox2.Text),
                new SqlParameter("@Telephone", textBox5.Text),
                new SqlParameter("@MobilePhone", textBox6.Text),
                new SqlParameter("@Fax", textBox7.Text),
                new SqlParameter("@CustomerAddress", textBox8.Text),
                new SqlParameter("@DeliveryAddress", textBox9.Text),
                new SqlParameter("@InvoiceAddress", textBox10.Text),
                new SqlParameter("@LastDeliveryDate", DateTime.Now.ToString()),
            };
            if(DatabaseHelper.ExecuteInsert(sql, parameters) > 0)
            {
                MessageBox.Show("插入成功!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("插入失败!客户ID已经存在!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Customer Where CustomerID=@CustomerID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID",textBox1.Text),
            };
            if(DatabaseHelper.ExecuteNonQuery(sql,parameters) > 0)
            {
                MessageBox.Show("删除成功!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("删除失败!客户ID不存在!");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[currentRowIndex].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[currentRowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[currentRowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[currentRowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[currentRowIndex].Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.Rows[currentRowIndex].Cells[10].Value.ToString();
            textBox10.Text = dataGridView1.Rows[currentRowIndex].Cells[11].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Customer SET CustomerSimpleName=@CustomerSimpleName,CustomerName=@CustomerName,Owner=@Owner,Title=@Title,Telephone=@Telephone,MobilePhone=@MobilePhone,Fax=@Fax,SalesManId=@SalesManId,CustomerAddress=@CustomerAddress,DeliveryAddress=@DeliveryAddress,InvoiceAddress=@InvoiceAddress,LastDeliveryDate=@LastDeliveryDate" +
                         " WHERE CustomerId = @CustomerId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", textBox1.Text),
                new SqlParameter("@CustomerSimpleName", textBox2.Text),
                new SqlParameter("@CustomerName", textBox3.Text),
                new SqlParameter("@Owner", textBox4.Text),
                new SqlParameter("@Title", comboBox1.Text),
                new SqlParameter("@SalesManId", comboBox2.Text),
                new SqlParameter("@Telephone", textBox5.Text),
                new SqlParameter("@MobilePhone", textBox6.Text),
                new SqlParameter("@Fax", textBox7.Text),
                new SqlParameter("@CustomerAddress", textBox8.Text),
                new SqlParameter("@DeliveryAddress", textBox9.Text),
                new SqlParameter("@InvoiceAddress", textBox10.Text),
                new SqlParameter("@LastDeliveryDate", DateTime.Now.ToString()),
            };
            if (DatabaseHelper.ExecuteInsert(sql, parameters) > 0)
            {
                MessageBox.Show("修改成功!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("修改失败!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
