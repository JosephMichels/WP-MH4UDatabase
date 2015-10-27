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
    public sealed partial class QuestDetailsPage : BasePage
    {
        public QuestDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState != null)
            {
                if (e.PageState.ContainsKey(PageValues.SELECTED_PIVOT_INDEX))
                    pivot.SelectedIndex = (int)e.PageState[PageValues.SELECTED_PIVOT_INDEX];
            }

        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState.Add(PageValues.SELECTED_PIVOT_INDEX, pivot.SelectedIndex);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = (int)e.Parameter;
            DataContext = new QuestDetailsViewModel(id);
            base.OnNavigatedTo(e);
        }

        private void MonsterClicked(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem != null && e.ClickedItem is Monster)
            {
                Monster m = (Monster)e.ClickedItem;
                Frame.Navigate(typeof(MonsterDetailsPage), (int)m._id);
            }
        }

        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null && e.ClickedItem is QuestRewards)
            {
                QuestRewards qr = (QuestRewards)e.ClickedItem;
                Frame.Navigate(typeof(ItemDetailsPage), (int)qr.item_id);
            }
        }
    }
}
