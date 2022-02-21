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

namespace Project
{
    public partial class AddTeam : Form
    {
        Form1 F1;
        public AddTeam(Form1 form1)
        {
            F1 = form1;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
            // InsertTeam();
            SqlConnection con = null;



            con = new SqlConnection("Data Source=LAPTOP-ACP3GLEH\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
            con.Open();
            SqlCommand cm = new SqlCommand("INSERT INTO Team (TeamName, LeaderName) VALUES (@t, @l)", con);
            cm.Parameters.AddWithValue("@t", textBox1.Text);
            cm.Parameters.AddWithValue("@l", textBox2.Text);


            cm.ExecuteNonQuery();
            F1.ReadData();
            con.Close();
            this.Hide();

        }
    }
}
