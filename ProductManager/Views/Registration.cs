using ProductManager.Data;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManager.Views
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void linkLabelAuthorization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAuthorize formAuthorize = new FormAuthorize();
            formAuthorize.Show();
            this.Hide();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if(textBoxLoginRegistration.Text != null && textBoxPasswordRegistration.Text != null) 
            {
                UserModel user = new UserModel();
                user.Login = textBoxLoginRegistration.Text;
                user.Password = textBoxPasswordRegistration.Text;
                user.Role = "Visitor";
                if (DataBaseService.AddUser(user))
                {
                    MessageBox.Show("Успешно!");
                    this.Close();
                    FormAuthorize formAuthorize = new FormAuthorize();
                    formAuthorize.Show();
                }
                else
                {
                    MessageBox.Show("Попробуйте позже.");
                }
            }
            else
            {
                MessageBox.Show("Введите поля.");
            }
        }
    }
}
