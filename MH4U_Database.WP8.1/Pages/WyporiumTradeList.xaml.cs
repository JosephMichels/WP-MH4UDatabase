using MH4U_Database.Database;
using MH4U_Database.ViewModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MH4U_Database.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WyporiumTradeList : BasePage
    {
        public WyporiumTradeList()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            navigationHelper.GoBackCommand = mainPagesBackCommand;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DataContext == null)
                this.DataContext = new WyporiumViewModel();

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.NavigationMode == NavigationMode.Back)
                DataContext = null;
        }

        private void ItemTapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is Grid)
            {
                Grid g = (Grid)sender;
                int id = (int)g.Tag;
                Item i = MHDatabaseHelper.GetItemSync(id);
                if (i.type.Equals("Weapon"))
                    Frame.Navigate(typeof(WeaponDetailsPage), i._id);
                else if (i.type.Equals("Armor"))
                    Frame.Navigate(typeof(ArmorDetailsPage), i._id);
                else if (i.type.Equals("Decoration"))
                    Frame.Navigate(typeof(DecorationDetailsPage), i._id);
                else
                    Frame.Navigate(typeof(ItemDetailsPage), i._id);
            }
        }

        private void toggleUnlockBtn_Click(object sender, RoutedEventArgs e)
        {
            ((WyporiumViewModel)DataContext).ShowUnlock = !((WyporiumViewModel)DataContext).ShowUnlock;
        }
    }
}
