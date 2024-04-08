using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication18
{
    public partial class Form3 : Form
    {
        int number=1;

        public Form3()
        {
            InitializeComponent();
            this.Text = "Оновлення пацієнта";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Hvorii temp = new Hvorii();
            BD db = new BD();
            db.openCon();

            MySqlCommand com = new MySqlCommand("SELECT * FROM `hv` WHERE `id` = @num", db.getCon());
            com.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            MySqlDataReader reader = com.ExecuteReader();

  
            while (reader.Read())
            {

                
                temp.id = Convert.ToInt32(reader.GetString(reader.GetOrdinal("id")));
                temp.fname = Convert.ToString(reader.GetString(reader.GetOrdinal("fname")));
                temp.name = reader.GetString(reader.GetOrdinal("name"));
                temp.pname = reader.GetString(reader.GetOrdinal("pname"));


            }
            db.closeCon();

            textBox1.Text = temp.id.ToString();
            textBox2.Text = temp.fname.ToString();
            textBox3.Text = temp.name.ToString();
            textBox4.Text = temp.pname.ToString();
           
        }

        internal void data(int chis)
        {
            number = chis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BD bd = new BD();

            bd.openCon();
            MySqlCommand com = new MySqlCommand("UPDATE `hv`SET  `fname` =@n,`name`=@m,`pname`=@d WHERE `id`= @num ", bd.getCon());
           
            com.Parameters.Add("@n", MySqlDbType.VarChar).Value = textBox2.Text;
            com.Parameters.Add("@m", MySqlDbType.VarChar).Value = textBox3.Text;
            com.Parameters.Add("@d", MySqlDbType.VarChar).Value = textBox4.Text;
            com.Parameters.Add("@num", MySqlDbType.VarChar).Value = textBox1.Text;
            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успіх", "Пацієнт успішно оновлений ;)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Помилка", "Здається щось пішло не так" +
               "спробуйте пізніше", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bd.closeCon();
        }
    }
}
