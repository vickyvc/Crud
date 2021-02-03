using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud_opratio
{
    public partial class Form1 : Form
    {
        public SqlConnection sc = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        SqlDataAdapter adp;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            sc.ConnectionString = "database=crud1;server=DESKTOP-8KEM77V\\SQLEXPRESS;integrated security=true";
            cmd = new SqlCommand("insert into tb_1(txt_pid,txt_pname,txt_cid,txt_cname) Values (@txt_pid,@txt_pname,@txt_cid,@txt_cname)", sc);
            sc.Open();
            cmd.Parameters.AddWithValue("@txt_pid", txt_pid.Text);
            cmd.Parameters.AddWithValue("@txt_pname", txt_pname.Text);
            cmd.Parameters.AddWithValue("@txt_cid", txt_cid.Text);
            cmd.Parameters.AddWithValue("@txt_cname", txt_cname.Text);

            cmd.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("DATA indseted sucessfully");
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            sc.ConnectionString = "database=crud1;server=DESKTOP-8KEM77V\\SQLEXPRESS;integrated security=true";
            sc.Open();

            DataTable dt = new DataTable();
            adp = new SqlDataAdapter("select * from tb_1", sc);
            adp.Fill(dt);
            gridview.DataSource = dt;
            sc.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            sc.ConnectionString = "database=crud1;server=DESKTOP-8KEM77V\\SQLEXPRESS;integrated security=true";
            cmd = new SqlCommand("update tb_1 set txt_pname=@txt_pname,txt_cid=@txt_cid,txt_cname=@txt_cname WHERE txt_pid = @txt_pid", sc);
            sc.Open();
            cmd.Parameters.AddWithValue("@txt_pid", txt_pid.Text);
            cmd.Parameters.AddWithValue("@txt_pname", txt_pname.Text);
            cmd.Parameters.AddWithValue("@txt_cid", txt_cid.Text);
            cmd.Parameters.AddWithValue("@txt_cname", txt_cname.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("DATA UPDATED sucessfully");
            sc.Close();
          

        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            sc.ConnectionString = "database=crud1;server=DESKTOP-8KEM77V\\SQLEXPRESS;integrated security=true";
            cmd = new SqlCommand("delete tb_1 where txt_pid=@txt_pid", sc);
            sc.Open();

            cmd.Parameters.AddWithValue("@txt_pid", txt_pid.Text);
            cmd.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Data deleted successfully");

        }
    }
}
