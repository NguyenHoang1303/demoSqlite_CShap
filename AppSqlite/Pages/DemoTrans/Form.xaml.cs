using AppSqlite.Entity;
using System;
using System.Collections.Generic;
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
        private List<Category> categories;
        public Form()
        {
            this.InitializeComponent();
            this.Loaded += Form_Loaded;
        }

        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            categories = Data.MigrateCategory.findAll();
            listCategory.ItemsSource = categories;
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
         
            Transaction personal = new Transaction();
            personal.Name = txtName.Text;
            personal.Description = txtDescription.Text;
            personal.Detail = txtDetail.Text;
            personal.Amount = Double.Parse(txtMoney.Text);
            personal.Category = Convert.ToInt32(searchCategory.Tag);
            personal.CreatedDate = date;

            ContentDialog contentDialog = new ContentDialog();
            if (Data.Migrate.SaveTables(personal))
            {
                contentDialog.Title = "Success";
                contentDialog.Content = "Tao thanh cong";
            }
            else
            {
                contentDialog.Title = "Fail";
                contentDialog.Content = "Them that bai";
            }
            contentDialog.CloseButtonText = "OK";
            await contentDialog.ShowAsync();
        }
        private void CheckDate(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            date = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            txtDate.Date = date;
        }
        private void listViewCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category categorySelection = listCategory.SelectedItem as Category;
            searchCategory.Content = categorySelection.Name;
            searchCategory.Tag = categorySelection.Id;
            searchCategory.Flyout.Hide();
        }
    }
}
