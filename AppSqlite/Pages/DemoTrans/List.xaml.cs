using AppSqlite.Entity;
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
        private List<Transaction> listTrans;
        public List()
        {
            this.InitializeComponent();
            listTrans = Data.Migrate.FindAll();
            this.Loaded += List_Loaded;
        }

        private void List_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            listTrans = Data.Migrate.FindAll();
           
        }

        private void MigrateData_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Data.MigrateCategory.CreatedCategory();
            Data.Migrate.MigrationData();
        }
    }
}
