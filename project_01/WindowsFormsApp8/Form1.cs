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

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.OpenGetSqlConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("exec add_user @UserId='{0}',@UserName='{1}',@UserPwd='{2}',@DepartmentId='{3}'", textBox1.Text,
                textBox2.Text, textBox3.Text, textBox4.Text);
            if (DatabaseHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("插入成功!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox1.Text == null)
            {
                MessageBox.Show("请输入用户ID！");
            }
            else
            {
                string sql = string.Format("exec delete_user_by_id @UserId='{0}'", textBox1.Text);
                if(DatabaseHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("删除成功!");
                }
                else
                {
                    MessageBox.Show("删除失败,此用户ID不存在!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox1.Text == null)
            {
                MessageBox.Show("请输入用户ID！");
            }
            else
            {
                string sql = string.Format("exec update_user_information @UserId='{0}',@NewUserName='{1}',@NewUserPwd='{2}',@NewDepartmentId='{3}'",
                    textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
                if (DatabaseHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    MessageBox.Show("修改失败,此用户ID不存在!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox1.Text == null)
            {
                MessageBox.Show("请输入用户ID！");
            }
            else
            {
                string sql = string.Format("exec find_user_by_id @UserId='{0}'",textBox1.Text);
                SqlDataReader dr = DatabaseHelper.GetSqlDataReader(sql);
                if (dr.HasRows)
                {
                    MessageBox.Show("此用户存在!");
                }
                else
                {
                    MessageBox.Show("此用户不存在!");
                }
                dr.Close();
            }
        }
    }
}
