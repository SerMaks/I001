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

namespace l001
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "" && txtPassword.Text != "" && txtName.Text != "" && txtRoled.Text != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                {
                    try
                    {

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT Users (Login, Password, Name, isadmin) VALUES ('" + txtLogin.Text + "','" + txtPassword.Text + "','" + txtName.Text + "','" + txtRoled.Text + "')";
                        cmd.ExecuteScalar();
                        con.Close();

                        this.Hide();
                        Users info = new Users();
                        info.Visible = true;
                        info.ShowInTaskbar = true;



                    }
                    catch (Exception ex)
                    {
                  

                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users info = new Users();
            info.Visible = true;
            info.ShowInTaskbar = true;
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
