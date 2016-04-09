using MH4U_Database.Common;
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
    public sealed partial class HomePage : BasePage
    {

        public HomePage():base()
        {
            this.InitializeComponent();
        }


        private void OptionSelected(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem == monsters)
            {
                Frame.Navigate(typeof(MonsterListPage));
            }
            else if (e.ClickedItem == items)
            {
                Frame.Navigate(typeof(ItemListPage));
            }
            else if (e.ClickedItem == weapons)
            {
                Frame.Navigate(typeof(WeaponTypePage));
            }
            else if (e.ClickedItem == armor)
            {
                Frame.Navigate(typeof(ArmorListPage));
            }
            else if (e.ClickedItem == skills)
            {
                Frame.Navigate(typeof(SkillListPage));
            }
            else if (e.ClickedItem == quests)
                Frame.Navigate(typeof(QuestListPage));
            else if (e.ClickedItem == combinations)
                Frame.Navigate(typeof(CombinationListPage));
            else if (e.ClickedItem == wyporium)
                Frame.Navigate(typeof(WyporiumTradeList));
            else if (e.ClickedItem == felyneSkills)
                Frame.Navigate(typeof(FelyneSkillListPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && e.Parameter is int)
            {
                Frame.BackStack.Clear();
            }
        }

        private void AppBarAboutClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }
    }
}
