using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication18
{
    public partial class Form1 : Form
    {
        List<Hvorii> list = new List<Hvorii>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD db = new BD();
            db.openCon();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `hv`", db.getCon());

            MySqlDataReader reader = com.ExecuteReader();
            list.Clear();
            while (reader.Read())
            {
                Hvorii temp = new Hvorii();
                temp.id = Convert.ToInt32(reader.GetString(reader.GetOrdinal("id")));
                temp.fname = Convert.ToString(reader.GetString(reader.GetOrdinal("fname")));
                temp.name = reader.GetString(reader.GetOrdinal("name"));
                temp.pname = reader.GetString(reader.GetOrdinal("pname"));
                list.Add(temp);
                
            }

            db.closeCon();

            dataGridView1.Rows.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
                int rowNum = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowNum].Cells[0].Value = list[i].id;
                dataGridView1.Rows[rowNum].Cells[1].Value = list[i].fname;
                dataGridView1.Rows[rowNum].Cells[2].Value = list[i].name;
                dataGridView1.Rows[rowNum].Cells[3].Value = list[i].pname;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 newFrom = new Form3();
                newFrom.data(Convert.ToInt32(textBox1.Text));
                newFrom.Show();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int j = Convert.ToInt32(textBox2.Text);
            BD db = new BD();
            db.openCon();
            MySqlCommand com = new MySqlCommand("DELETE FROM `hv` WHERE `id` = @n", db.getCon());
            com.Parameters.Add("@n", MySqlDbType.Int32).Value = j;
            com.ExecuteNonQuery();

            db.closeCon();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
