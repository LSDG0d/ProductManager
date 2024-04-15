using ProductManager.Data;
using ProductManager.Models;
using ProductManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class FormAuthorize : Form
    {
        public FormAuthorize()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void buttonAuthorize_Click(object sender, EventArgs e)
        {
            string Login = textBoxLogin.Text.ToString();
            string Password = textBoxPassword.Text.ToString();
            string role = ValidSevice.ValidThis(Login, Password);
            if (role == "Admin")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else if (role == "Visitor")
            {
                VisitorForm visitorForm = new VisitorForm();
                visitorForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show($"Ошибка: {role}");
            }
        }
    }
}
