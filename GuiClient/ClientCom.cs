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
            /*
            if(this.predBox.Text=="")
            {
                this.responseLabel.Text = client.Communicate(msgbox.Text);
            }
            else

            Show all users
            Delete user
            Add user
            Modify user
            Random number

            {
                 if(this.predBox.Text
            }*/
            string msg = "";
            switch (this.predBox.Text)
            {
                case "Show all users":
                    
                    this.responseLabel.Text = client.Communicate("getall");
                    break;
                case "Delete user":
                    
                    if (userBox.Text.Length != 0)
                    {
                        msg = "userdel";
                        msg = msg + " " + userBox.Text;
                        this.responseLabel.Text = client.Communicate(msg);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username");
                    }
                    break;

                case "Add user":
                    msg = "useradd";      
                    if(userBox.Text.Length!=0&&passBox.Text.Length!=0)
                    {   
                        if(this.checkBox1.Checked)
                        {
                            msg = msg + " " + userBox.Text + " " + passBox.Text + " True";
                        }
                        else
                        {
                            msg = msg + " " + userBox.Text +" "+ passBox.Text + " False";
                        }

                       
                        this.responseLabel.Text = client.Communicate(msg);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                    break;

                case "Modify user":
                    msg = "usermod";
                    if (userBox.Text.Length != 0 && passBox.Text.Length != 0)
                    {
                        msg = msg + " " + userBox.Text + " " + passBox.Text;
                        this.responseLabel.Text = client.Communicate(msg);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    } 
                    break;

                case "Random number":
                    msg = "random";
                   
                    if (userBox.Text.Length != 0 && passBox.Text.Length != 0)
                    {  
                        msg = msg + " " + userBox.Text + " " + passBox.Text;
                        this.responseLabel.Text = client.Communicate(msg);
                    }
                    else
                    {
                        MessageBox.Show("Invalid values");
                    }
                    break;

                default:
                    this.responseLabel.Text = client.Communicate(msgbox.Text);
                    break;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void predBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.predBox.Text)
            {
                case "Show all users":    
                    this.userBox.Enabled = false;
                    this.passBox.Enabled = false;
                    this.checkBox1.Enabled = false;
                    break;

                case "Delete user":
                    this.userBox.Enabled = true;
                    this.passBox.Enabled = false;
                    this.checkBox1.Enabled = false;
                    break;

                case "Add user":
                    this.userBox.Enabled = true;
                    this.passBox.Enabled = true;
                    this.checkBox1.Enabled = true;
                    break;

                case "Modify user":
                    this.userBox.Enabled = true;
                    this.passBox.Enabled = true;
                    this.checkBox1.Enabled = false;                
                    break;

                case "Random number":
                    this.userBox.Enabled = true;
                    this.passBox.Enabled = true;
                    this.checkBox1.Enabled = false;
                    break;

                default:
                    this.userBox.Enabled = false;
                    this.passBox.Enabled = false;
                    this.checkBox1.Enabled = false;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void userBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
