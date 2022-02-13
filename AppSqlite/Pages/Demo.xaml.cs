using SQLitePCL;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppSqlite.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Demo : Page
    {
        public Demo()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(Pages.DemoTrans.List));
        }

        private void DemoTransaction_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Pages.DemoTrans.List));
        }        

        private void DemoTransaction_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //contentFrame.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = args.SelectedItem as NavigationViewItem;
                switch (selectedItem.Tag.ToString())
                {
                    case "History":
                        contentFrame.Navigate(typeof(Pages.DemoTrans.List));
                        break;
                    case "Form":
                        contentFrame.Navigate(typeof(Pages.DemoTrans.Form));
                        break;
                }
            }
        }

        private void contentFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {

        }
    }
}
