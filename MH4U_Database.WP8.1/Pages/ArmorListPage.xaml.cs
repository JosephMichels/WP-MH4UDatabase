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
    public sealed partial class ArmorListPage : BasePage
    {
        public ArmorListPage()
        {
            this.InitializeComponent();

            DataContext = new ArmorListViewModel();
            navigationHelper.GoBackCommand = mainPagesBackCommand;
        }

        private void ArmorClicked(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem is Armor)
            {
                Armor a = (Armor)e.ClickedItem;
                Frame.Navigate(typeof(ArmorDetailsPage), (int)a._id);
            }
        }
    }
}
