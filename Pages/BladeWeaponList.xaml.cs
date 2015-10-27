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
    public sealed partial class BladeWeaponList : BasePage
    {

        int _visibleIndex;
        WeaponListViewModel viewModel;

        public BladeWeaponList()
        {
            this.InitializeComponent();
            
        }

        protected override void SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["position"] = _visibleIndex;
            base.SaveState(sender, e);
        }

        protected override void LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState == null) return;

            if (e.PageState.ContainsKey("position"))
            {
                _visibleIndex = (int)e.PageState["position"];
                //ScrollToIndex(_visibleIndex);
            }

            base.LoadState(sender, e);
        }

        void ScrollToIndex(int index) {
            var container = listView.ContainerFromIndex(index);
            if (container != null)
            {
                var item = (WeaponTreeEntry)listView.ItemFromContainer(container);
                listView.ScrollIntoView(item);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = new WeaponListViewModel((string)e.Parameter);
            DataContext = viewModel;
            //viewModel.PropertyChanged += ViewModel_PropertyChanged;
            base.OnNavigatedTo(e);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("WeaponTree"))
            {
                ScrollToIndex(_visibleIndex);
            }
        }

        private void WeaponClicked(object sender, ItemClickEventArgs e)
        {
            ListView lv = (ListView)sender;
            var isp = (ItemsStackPanel)lv.ItemsPanelRoot;
            _visibleIndex = isp.FirstVisibleIndex;
            WeaponTreeEntry entry = (WeaponTreeEntry)e.ClickedItem;
            Frame.Navigate(typeof(WeaponDetailsPage), entry.Weapon._id);
        }
    }
}
