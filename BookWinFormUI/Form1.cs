using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BO;

namespace BookWinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BllServices bllServices = new BllServices();
            var allCountries = bllServices.GetCountries();
            cmbCountry.DataSource = allCountries;
       
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BllServices bllServices = new BllServices();
            try
            {
             

                Book newbook = new Book();
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
               BllServices bll = new BllServices();
                bll.AddLog(ex.Message);
                MessageBox.Show(ex.Message);
         
            }

            dtgData.DataSource = bllServices.GetBooks();
        }

        private void btnBookPerCountry_Click(object sender, EventArgs e)
        {
            BllServices bll = new BllServices();
           var list =  bll.GetBooksByCountry(cmbCountry.SelectedIndex+1);
            dtgData.DataSource = null;
           dtgData.DataSource = list;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
