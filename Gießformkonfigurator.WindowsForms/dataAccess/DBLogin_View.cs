using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    public partial class DBLogin_View : Form
    {
        public DBLogin_View()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Connection_Click(object sender, EventArgs e)
        {
            DBConnectionConsole database = new DBConnectionConsole();
            database.SetConnectionDetails(this.textBox_Server.ToString(), this.textBox_DB.ToString(), this.textBox_User.ToString(), this.textBox_PW.ToString());
            database.EstablishConnection();
        }
    }
}
