using AppSqlite.Entity;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppSqlite.Pages.DemoTrans
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Form : Page
    {
        private DateTime date;
        public Form()
        {
            this.InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {

            Transaction personal = new Transaction();
            personal.Name = txtName.Text;
            personal.Description = txtDescription.Text;
            personal.Detail = txtDetail.Text;
            personal.Amount = Double.Parse(txtMoney.Text);
            personal.Category = int.Parse(txtCategory.Text);
            personal.CreatedDate = date;
            Data.Migrate.SaveTables(personal);
        }
        private void CheckDate(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            date = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            txtDate.Text = date.ToString();
        }
    }
}
