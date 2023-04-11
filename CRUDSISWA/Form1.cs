using System.Data;
using System.Data.SqlClient;

namespace CRUDSISWA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=CrudForm;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("insert into ut values (@id,@name,@age)", con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.Parameters.AddWithValue("@name", textBox2.Text);
            CMD.Parameters.AddWithValue("@age",double.Parse(textBox3.Text));
            CMD.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=CrudForm;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("update ut set name=@name, age=@age where id=@id",con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.Parameters.AddWithValue("@name", textBox2.Text);
            CMD.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            CMD.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Edited");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=CrudForm;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("delete ut where id=@id",con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=CrudForm;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("select * from  ut where id = @id", con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=CrudForm;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("select * from  ut", con);
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}