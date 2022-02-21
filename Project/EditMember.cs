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
    public partial class EditMember : Form
    {
        private static Int32 TeamId = 0;

        public static Int32 team
        {
            get
            {
                return TeamId;
            }
            set
            {
                TeamId = value;
            }
        }
        public EditMember()
        {
           
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(@"Data Source=LAPTOP-ACP3GLEH\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
                con.Open();
                SqlCommand cm = new SqlCommand("insert into Member (FirstName, LastName,TeamId,RoleId) values (@f, @l,@t,@r)", con);
                cm.Parameters.AddWithValue("@f", textBox1.Text);
                cm.Parameters.AddWithValue("@l", textBox2.Text);
                cm.Parameters.AddWithValue("@t", TeamId);
                cm.Parameters.AddWithValue("@r",comboBox1.Text); 

               

                
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
            AddMember add = new AddMember();
            add.Show();
            this.Hide();

        }

        private void EditMember_Load(object sender, EventArgs e)
        {

        }
    }
}
