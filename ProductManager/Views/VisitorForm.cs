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
    public partial class VisitorForm : Form
    {
        public List<ProductModel> products = new List<ProductModel>();
        public void loadProducts()
        {
            dataGridViewProduct.Rows.Clear();
            products = DataBaseService.GetProducts();
            foreach (ProductModel product in products)
            {
                dataGridViewProduct.Rows.Add(product.Id, product.Name, product.Description, product.Count, product.Cost);
            }
        }
        public VisitorForm()
        {
            InitializeComponent();
            loadProducts();
        }

        private void dataGridViewProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID.Text = dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewProduct.SelectedRows[0].Cells[1].Value.ToString();
            textBoxDescription.Text = dataGridViewProduct.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDownCount.Value = (int)dataGridViewProduct.SelectedRows[0].Cells[3].Value;
            numericUpDownCost.Value = (int)dataGridViewProduct.SelectedRows[0].Cells[4].Value;
        }
        public void LoadResultSearch()
        {
            if (textBoxName.Text != null && textBoxName.Text != "")
            {
                dataGridViewProduct.Rows.Clear();
                products = DataBaseService.SearchProductsByName(textBoxName.Text);
                foreach (ProductModel product in products)
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
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ProductID.Text != null && textBoxName.Text != null && ProductID.Text != "" && textBoxName.Text != "")
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadResultSearch();
        }
    }
}
