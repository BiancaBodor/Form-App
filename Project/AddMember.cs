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
    public partial class AddMember : Form
    {
        private int teamId;
        public AddMember()
        {
            InitializeComponent();
          
           // teamId = int.Parse(o.ToString());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMember nt = new EditMember();
            nt.Show();
            
         
        }
        public void ReadData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(@"Data Source=LAPTOP-ACP3GLEH\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
                SqlDataAdapter cm = new SqlDataAdapter("SELECT * FROM Member WHERE TeamId=" + EditMember.team, con);
                con.Open();

                DataSet ds = new DataSet();
                cm.Fill(ds, "Team");
                dataGridView1.DataSource = ds.Tables["Team"].DefaultView;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }

            finally
            {
                con.Close();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            ReadData();
        }

        /*public void ReadData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(@"Data Source=LAPTOP-ACP3GLEH\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
                SqlDataAdapter cm = new SqlDataAdapter($"SELECT * FROM Member where TeamId = {teamId}", con);
                //cm.Parameters.Add("@t", SqlDbType.Int).Value = teamId;
                con.Open();

                DataSet ds = new DataSet();
                cm.Fill(ds, "Member");
                dataGridView1.DataSource = ds.Tables["Member"].DefaultView;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }

            finally
            {
                con.Close();
            }
        }*/
    }
}