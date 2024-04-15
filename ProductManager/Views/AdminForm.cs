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
    public partial class AdminForm : Form
    {
        public List<UserModel> users = new List<UserModel>();
        public List<ProductModel> products = new List<ProductModel>();
        public AdminForm()
        {
            InitializeComponent();
            loadUsers();
            loadProducts();
            loadRoles();
        }
        public void loadRoles()
        {
            foreach(var role in Enum.GetValues(typeof(Roles.AllRoles)))
            {
                comboBoxRole.Items.Add(role);
            }
            comboBoxRole.SelectedIndex = 0;
        }
        public void loadUsers()
        {
            dataGridViewUsers.Rows.Clear();
            users = DataBaseService.GetUsers();
            foreach (UserModel user in users)
            {
                dataGridViewUsers.Rows.Add(user.Id, user.Login, user.Password, user.Role);
            }
        }
        public void loadProducts()
        {
            dataGridViewProduct.Rows.Clear();
            products = DataBaseService.GetProducts();
            foreach (ProductModel product in products)
            {
                dataGridViewProduct.Rows.Add(product.Id, product.Name, product.Description, product.Count, product.Cost);
            }
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != null)
            {
                ProductModel product = new ProductModel();
                product.Name = textBoxName.Text;
                product.Description = textBoxDescription.Text;
                product.Cost = (int)numericUpDownCost.Value;
                product.Count = (int)numericUpDownCount.Value;
                if (DataBaseService.AddProduct(product))
                {
                    loadProducts();
                    MessageBox.Show($"Продукт {product.Name} успешно добавлен");
                }
                else
                {
                    MessageBox.Show($"Попробуйте позже");
                }
            }
            else
            {
                MessageBox.Show("Введите данный по товару");
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count == 1)
            {
                if (DataBaseService.DeleteUser((int)dataGridViewUsers.SelectedCells[0].Value))
                {
                    MessageBox.Show("Пользователь успешно удалён");
                    loadUsers();
                }
            }
            else
            {
                MessageBox.Show("Веделите одну строку из таблицы");
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count == 1)
            {
                if (DataBaseService.DeleteProduct((int)dataGridViewProduct.SelectedCells[0].Value))
                {
                    MessageBox.Show("Продукт успешно удалён");
                    loadProducts();
                }
            }
            else
            {
                MessageBox.Show("Веделите одну строку из таблицы");
            }
        }

        private void dataGridViewUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            labelIDUSER.Text = dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString();
            textBoxLogin.Text = dataGridViewUsers.SelectedRows[0].Cells[1].Value.ToString();
            textBoxPassword.Text = dataGridViewUsers.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxRole.Text = dataGridViewUsers.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dataGridViewProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID.Text = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewProduct.SelectedRows[0].Cells[1].Value.ToString();
            textBoxDescription.Text = dataGridViewProduct.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDownCount.Value = (int)dataGridViewProduct.SelectedRows[0].Cells[3].Value;
            numericUpDownCost.Value = (int)dataGridViewProduct.SelectedRows[0].Cells[4].Value;
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            if(labelIDUSER.Text != null && textBoxPassword.Text != null && labelIDUSER.Text != "" && textBoxPassword.Text != "" && textBoxLogin.Text != null && textBoxLogin.Text != "")
            {
                UserModel user = new UserModel();
                user.Id = Convert.ToInt32(labelIDUSER.Text.ToString());
                user.Login = textBoxLogin.Text;
                user.Password = textBoxPassword.Text;
                user.Role = comboBoxRole.Text;
                if (DataBaseService.UpdateUser(user))
                {
                    loadUsers();
                    MessageBox.Show($"Пользователь {user.Login} успешно изменён");
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для изменения из таблицы");
            }
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            if (ProductID.Text != null && textBoxName.Text != null && ProductID.Text != "" && textBoxName.Text != "" )
            {
                ProductModel product = new ProductModel();
                product.Id = Convert.ToInt32(ProductID.Text.ToString());
                product.Name = textBoxName.Text;
                product.Description = textBoxDescription.Text;
                product.Cost = (int)numericUpDownCost.Value;
                product.Count = (int)numericUpDownCount.Value;
                if (DataBaseService.UpdateProduct(product))
                {
                    loadProducts();
                    MessageBox.Show($"Продукт {product.Name} успешно изменён");
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для изменения из таблицы");
            }
        }
        public void LoadResultSearch()
        {
            if(textBoxName.Text != null && textBoxName.Text != "")
            {
                dataGridViewProduct.Rows.Clear();
                products = DataBaseService.SearchProductsByName(textBoxName.Text);
                foreach(ProductModel product in products)
                {
                   dataGridViewProduct.Rows.Add(product.Id, product.Name, product.Description, product.Count, product.Cost);
                }
            }
            else
            {
                loadProducts();
                MessageBox.Show("Введите название для поиска");
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadResultSearch();
        }
    }
}
