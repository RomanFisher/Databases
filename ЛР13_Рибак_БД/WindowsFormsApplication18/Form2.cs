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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Додання пацієнта";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();

            bd.openCon();
            MySqlCommand com = new MySqlCommand("INSERT INTO `hv` (`id`,`fname`,`name`,`pname`) VALUES (NULL,@fn,@n,@pn)", bd.getCon());
           
            com.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBox2.Text;
            com.Parameters.Add("@n", MySqlDbType.VarChar).Value = textBox3.Text;
            com.Parameters.Add("@pn", MySqlDbType.VarChar).Value = textBox4.Text;

            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успіх", "Пацієнт успішно доданий ;)",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else MessageBox.Show("Помилка", "Здається щось пішло не так" +
                "спробуйте пізніше", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bd.closeCon();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
