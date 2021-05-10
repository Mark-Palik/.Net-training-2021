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

namespace Simple_CRUD_App
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-1G4CN2S\\SQLEXPRESS;Initial Catalog=Employees_db;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            GetEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int EmpID = int.Parse(textBox2.Text);
            string EmpName = textBox3.Text;
            string EmpLastName = textBox4.Text;
            string EmpPosition = comboBox2.Text;
            string City = comboBox1.Text;
            string Gender;
            if (radioButton1.Checked)
            {
                Gender = "Male";
            }
            else 
            {
                Gender = "Female";
            }
            con.Open();
            SqlCommand command = new SqlCommand("exec InsertEmp_SP '"+ EmpID + "','" + EmpName + "','" + EmpLastName + "','" + EmpPosition + "','" + City + "','" + Gender + "'",con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted...");
            con.Close();
            GetEmployees();
        }
        void GetEmployees()
        {
            SqlCommand command = new SqlCommand("exec GetEmployees_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int EmpID = int.Parse(textBox2.Text);
            string EmpName = textBox3.Text;
            string EmpLastName = textBox4.Text;
            string EmpPosition = comboBox2.Text;
            string City = comboBox1.Text;
            string Gender;
            if (radioButton1.Checked)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            con.Open();
            SqlCommand command = new SqlCommand("exec UpdateEmp_SP '" + EmpID + "','" + EmpName + "','" + EmpLastName + "','" + EmpPosition + "','" + City + "','" + Gender + "'", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully updated...");
            con.Close();
            GetEmployees();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int EmpID = int.Parse(textBox2.Text);
            con.Open();
            SqlCommand command = new SqlCommand($"exec DeleteEmp_SP  {EmpID} ", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted...");
            con.Close();
            GetEmployees();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int EmpID = int.Parse(textBox2.Text);
            con.Open();
            SqlCommand command = new SqlCommand($"exec LoadEmp_SP  {EmpID} ", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
