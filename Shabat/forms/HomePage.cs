using Shabat.DAL;
using Shabat.DAL.Models;
using Shabat.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shabat.forms
{
    internal partial class HomePage : Form
    {
        private CategoryRepository _categoryRepository;
        public HomePage(CategoryRepository categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            LoadCategories(_categoryRepository.FindAll());
        }
        public void LoadCategories(List<CategotryModel> categories)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryName");
            foreach (CategotryModel category in categories)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["CategoryName"] = category.CategoryName;
                dt.Rows.Add(dataRow);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool ressult =  _categoryRepository.insert(new CategotryModel(textBox_add.Text));
            if (!ressult)
            {
                MessageBox.Show("its allready exist");
            }
            LoadCategories(_categoryRepository.FindAll());
            textBox_add.Clear();
        }
    }
}
