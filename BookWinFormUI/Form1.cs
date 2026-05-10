using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BLL.Interfaces;
using BO;
using BO.Interfaces;

namespace BookWinFormUI
{
    public partial class Form1 : Form
    {
        private readonly IBllServices bllServices = new BllServices();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCountries();
            LoadAllBooks();
        }

        private void LoadCountries()
        {
            cmbFilterCountry.DisplayMember = "Name";
            cmbFilterCountry.ValueMember = "Id";
            cmbFilterCountry.DataSource = bllServices.GetCountries().ToList();

            // Separate list instance so the two combos do not share BindingContext.
            cmbBookCountry.DisplayMember = "Name";
            cmbBookCountry.ValueMember = "Id";
            cmbBookCountry.DataSource = bllServices.GetCountries().ToList();
        }

        private void LoadAllBooks()
        {
            var books = bllServices.GetBooks().ToList();
            dtgData.DataSource = null;
            dtgData.DataSource = books;
            UpdateStatus(string.Format("{0} book(s) loaded.", books.Count));
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateBookForm())
                    return;

                IBook newBook = new Book
                {
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    DatePublished = dtpDatePublished.Value,
                    CountryId = (int)cmbBookCountry.SelectedValue,
                };

                if (bllServices.AddBook(newBook))
                {
                    MessageBox.Show("Book saved.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadAllBooks();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot save: the publication date is in the future.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                bllServices.AddLog(ex.Message);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookPerCountry_Click(object sender, EventArgs e)
        {
            if (cmbFilterCountry.SelectedValue == null)
                return;

            int countryId = (int)cmbFilterCountry.SelectedValue;
            var list = bllServices.GetBooksByCountry(countryId).ToList();
            dtgData.DataSource = null;
            dtgData.DataSource = list;
            UpdateStatus(string.Format("{0} book(s) for selected country.", list.Count));
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateBookForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ShowValidation("Title is required.", txtTitle);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                ShowValidation("Author is required.", txtAuthor);
                return false;
            }
            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                ShowValidation("Price must be a positive number.", txtPrice);
                return false;
            }
            if (cmbBookCountry.SelectedValue == null)
            {
                ShowValidation("Country is required.", cmbBookCountry);
                return false;
            }
            return true;
        }

        private void ShowValidation(string message, Control control)
        {
            MessageBox.Show(message, "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (control != null)
                control.Focus();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            dtpDatePublished.Value = DateTime.Now;
            txtTitle.Focus();
        }

        private void UpdateStatus(string text)
        {
            lblStatus.Text = text;
        }
    }
}
