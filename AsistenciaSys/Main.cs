using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AsistenciaSys
{
    public partial class Main : Form
    {
        public string api = "";
        public string db_credentials = "Server=localhost;Database=comunidadsalsera;User=root;Password=Imagt123*;";
        public Main()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Main_Resize);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int alingX = (this.ClientSize.Width - btnVerificar.Width) / 2;
            btnRegistrar.Left = alingX;
            btnVerificar.Left = alingX;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            int alingX = (this.ClientSize.Width - btnVerificar.Width) / 2;
            btnRegistrar.Left = alingX;
            btnVerificar.Left = alingX;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrar registrar = new frmRegistrar();
            registrar.ShowDialog();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            frmVerificar verificar = new frmVerificar();
            verificar.ShowDialog();
        }
    }
}
