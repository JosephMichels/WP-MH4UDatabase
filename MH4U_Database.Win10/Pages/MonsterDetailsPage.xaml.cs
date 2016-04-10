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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MH4U_Database.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MonsterDetailsPage : Page
    {
        public MonsterDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new MonsterDetailsViewModel((int)e.Parameter);
            base.OnNavigatedTo(e);
        }

        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Monster)
            {
                //NavigationEntry entry = (NavigationEntry)e.ClickedItem;
                Frame.Navigate(typeof(MonsterDetailsPage), ((Monster)e.ClickedItem)._id);
            }
        }

        private void QuestClicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Monster)
            {
                //NavigationEntry entry = (NavigationEntry)e.ClickedItem;
                Frame.Navigate(typeof(MonsterDetailsPage), ((Monster)e.ClickedItem)._id);
            }
        }

    }
}
