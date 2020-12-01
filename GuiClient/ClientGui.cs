using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiClient
{
    public partial class ClientGui : Form
    {
        TCPLib.GuiClient client = new TCPLib.GuiClient(IPAddress.Parse("127.0.0.1"), 40000);
        public ClientGui()
        {
            InitializeComponent();
            try
            {
                client.Start();
            }
            catch (Exception e)
            {

            }
            
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            if(userBox.Text.Length!=0 || passwdBox.Text.Length != 0)
            {
                if (client.LoginUser(userBox.Text, passwdBox.Text))
                {
                    this.responseLabel.ForeColor = Color.Green;
                    this.responseLabel.Text = "HEY";
                }
                else
                {
                    this.responseLabel.ForeColor = Color.Red;
                    this.responseLabel.Text = "Invalid Credentials";
                }
            }
            else
            {
                this.responseLabel.ForeColor = Color.Red;
                this.responseLabel.Text = "Write something";
            }
       

        }

        private void ClientGui_Load(object sender, EventArgs e)
        {

        }
    }
}
