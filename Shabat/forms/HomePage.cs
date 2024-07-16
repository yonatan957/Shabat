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
            listView1.Items.Clear();
            foreach (CategotryModel category in categories)
            {
                List<string> values = new List<string>();
                values.Add(category.CategoryName);
                values.Add($"{category.CategoryID}");
                ListViewItem item = new ListViewItem(String.Join(" - ", values));
                listView1.Items.Add(item);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            _categoryRepository.insert(new CategotryModel(textBox_add.Text));
            LoadCategories(_categoryRepository.FindAll());
        }
    }
}
