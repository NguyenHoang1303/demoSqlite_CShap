using AppSqlite.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppSqlite.Pages.DemoTrans
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List : Page
    {
        private List<Transaction> listTransactions;
        private List<Category> categories;
        public List()
        {
            this.InitializeComponent();
            this.Loaded += List_Loaded;
        }

        private void List_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            listTransactions = Data.Migrate.FindAll();
            dataTransaction.ItemsSource = listTransactions;

            categories = Data.MigrateCategory.findAll();
            Debug.WriteLine(categories);
            listCategory.ItemsSource = categories;


        }

        private void MigrateData_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Data.MigrateCategory.CreatedCategory();
            Data.Migrate.MigrationData();
            dataTransaction.ItemsSource = Data.Migrate.FindAll();
        }

        private void listViewCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = listCategory.SelectedItem as Category;
            searchCategory.Content = category.Name;
            searchCategory.Tag = category.Id;
            searchCategory.Flyout.Hide();
            List<Transaction> listTransactionByCategory = Data.Migrate.getTransactionByCategory(Convert.ToInt32(searchCategory.Tag));
            dataTransaction.ItemsSource = listTransactionByCategory;
        }

        private void Search_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            List<Transaction> transactions = new List<Transaction>();
            var checkedStartDate = start.Date.ToString("yyyy-dd-MM");
            var checkedEndDate = end.Date.ToString("yyyy-dd-MM");
            dataTransaction.ItemsSource = Data.Migrate.ListTransactionByStartDateAndEndDate(checkedStartDate, checkedEndDate);

        }

        private void Reset_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            dataTransaction.ItemsSource = Data.Migrate.FindAll();
            searchCategory.Tag = 0;
        }

    }
}
