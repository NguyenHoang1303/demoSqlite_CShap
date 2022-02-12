using Sqlite_demo.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sqlite_demo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormTransaction : Page
    {
        private DateTime date;

        public FormTransaction()
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
            Data.MigrateData.SaveTables(personal);
        }
        private void CheckDate(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            date = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            txtDate.Text = date.ToString();
        }
    }
}
