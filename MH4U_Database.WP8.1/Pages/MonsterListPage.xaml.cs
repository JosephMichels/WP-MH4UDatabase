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
    public sealed partial class MonsterListPage : BasePage
    {
        public MonsterListPage()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;

            //Setup some custom routing on back button
            navigationHelper.GoBackCommand = mainPagesBackCommand;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(DataContext == null || e.NavigationMode != NavigationMode.Back)
                DataContext = new MonsterListViewModel();
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.NavigationMode == NavigationMode.Back)
                DataContext = null;
        }

        private void MonsterClicked(object sender, ItemClickEventArgs e)
        {
            Monster m = (Monster)e.ClickedItem;
            Frame.Navigate(typeof(MonsterDetailsPage), (int)m._id);
        }
    }
}
