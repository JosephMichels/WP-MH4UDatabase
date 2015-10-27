using MH4U_Database.Common;
using MH4U_Database.Database;
using MH4U_Database.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MH4U_Database.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemListPage : BasePage
    {
        public ItemListPage()
        {
            NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();
            navigationHelper.GoBackCommand = mainPagesBackCommand;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(DataContext == null)
                DataContext = new ItemListViewModel();
            base.OnNavigatedTo(e);
        }

        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                TextBox tb = (TextBox)sender;
                tb.IsEnabled = false;
                tb.IsEnabled = true;
            }
        }

        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            Item i = (Item)e.ClickedItem;
            //Item i = MHDatabaseHelper.GetItemSync(j._id);
            if (i.type.Equals("Weapon"))
                Frame.Navigate(typeof(WeaponDetailsPage), i._id);
            else if (i.type.Equals("Armor"))
                Frame.Navigate(typeof(ArmorDetailsPage), i._id);
            else
                Frame.Navigate(typeof(ItemDetailsPage), i._id);
        }
    }
}
