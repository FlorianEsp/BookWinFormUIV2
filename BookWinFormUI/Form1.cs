using System;
using System.Windows.Forms;
using BLL;
using BLL.Interfaces;
using BO;
using BO.Interfaces;

namespace BookWinFormUI
{
    public partial class Form1 : Form
    {
        IBllServices bllServices = new BllServices();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            var allCountries = bllServices.GetCountries();
            cmbCountry.DataSource = allCountries;
            dtgData.DataSource = bllServices.GetBooks();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {

            try
            {
             
                IBook newbook = new Book();
                newbook.Title = txtTitle.Text;
                newbook.Author = txtAuthor.Text;
                newbook.Description = txtDescription.Text;
                newbook.Price = Convert.ToDecimal(txtPrice.Text);
                newbook.DatePublished = Convert.ToDateTime(dtpDatePublished.Text);
                newbook.CountryId = cmbCountry.SelectedIndex + 1;

                if (bllServices.AddBook(newbook))
                {
                    MessageBox.Show("Record added to the Database");
                }
                else
                {
                    MessageBox.Show("There was a problem saving the record");
                }
                bllServices.AddBook(newbook);
            }
            catch (Exception ex)
            {
                IBllServices bll = new BllServices();
                bll.AddLog(ex.Message);
                MessageBox.Show(ex.Message);

            }
        }
        private void btnBookPerCountry_Click(object sender, EventArgs e)
        {
       
            var index =cmbCountry.SelectedIndex + 1;    
            var list = bllServices.GetBooksByCountry(index);
            dtgData.DataSource = null;
            dtgData.DataSource = list;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
