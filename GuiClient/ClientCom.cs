using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiClient
{
    public partial class ClientCom : Form
    {
        TCPLib.GuiClient client;

        public ClientCom(TCPLib.GuiClient recclient)
        {
            this.client = recclient;
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            this.responseLabel.Text = client.Communicate(msgbox.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }
    }
}
