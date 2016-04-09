using MH4U_Database.Common;
using MH4U_Database.Database;
using MH4U_Database.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace MH4U_Database.Pages
{
    public sealed partial class ItemDetailsPage : BasePage
    {

        public ItemDetailsPage()
        {
            InitializeComponent();
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
            DataContext = new ItemDetailsViewModel(id);
            base.OnNavigatedTo(e);
        }

        private void ComponentClicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Component)
            {
                //Navigate to the item details page.
                Component c = (Component)e.ClickedItem;
                if (c.created_item_type.Equals("Weapon"))
                    Frame.Navigate(typeof(WeaponDetailsPage), c.created_item_id);
                else if (c.created_item_type.Equals("Armor"))
                    Frame.Navigate(typeof(ArmorDetailsPage), c.created_item_id);
                else if(c.created_item_type.Equals("Decoration"))
                    Frame.Navigate(typeof(DecorationDetailsPage), c.created_item_id);
                else
                    Frame.Navigate(typeof(ItemDetailsPage), c.created_item_id);
            }
        }

        private void MonsterClicked(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem != null && e.ClickedItem is HuntingReward)
            {
                HuntingReward hr = (HuntingReward)e.ClickedItem;
                Frame.Navigate(typeof(MonsterDetailsPage), (int)hr.monster_id);
            }
        }

        private void QuestClicked(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem != null && e.ClickedItem is QuestRewards)
            {
                QuestRewards qr = (QuestRewards)e.ClickedItem;
                Frame.Navigate(typeof(QuestDetailsPage), (int)qr.quest_id);
            }
        }
    }
}
