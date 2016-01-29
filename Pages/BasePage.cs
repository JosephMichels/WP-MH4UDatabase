using MH4U_Database.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MH4U_Database.Pages
{
    public class BasePage : Page
    {
        protected NavigationHelper navigationHelper;

        protected RelayCommand mainPagesBackCommand;

        public BasePage()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.LoadState;
            this.navigationHelper.SaveState += this.SaveState;

            mainPagesBackCommand = new RelayCommand(() =>
            {
                if (Frame.CanGoBack)
                    Frame.GoBack();
                else
                    Frame.Navigate(typeof(HomePage), 0);
            }, () =>
            {
                return true;
            });

        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }





        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        protected virtual void LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        protected virtual void SaveState(object sender, SaveStateEventArgs e)
        {
        }


        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }


        #region Handle App Bar Button Presses

        protected void AppBarHomeClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage), 0);
        }

        protected void AppBarMonstersClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MonsterListPage));
            Frame.BackStack.Clear();
        }

        protected void AppBarItemsClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ItemListPage));
            Frame.BackStack.Clear();
        }

        protected void AppBarWeaponsClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WeaponTypePage));
            Frame.BackStack.Clear();
        }

        protected void AppBarArmorClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ArmorListPage));
            Frame.BackStack.Clear();
        }

        protected void AppBarSkillsClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SkillListPage));
            Frame.BackStack.Clear();
        }

        protected void AppBarQuestsClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuestListPage));
            Frame.BackStack.Clear();
        }

        protected void AppBarCombinationsClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CombinationListPage));
            Frame.BackStack.Clear();
        }

        #endregion

    }
}
