using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MH4U_Database.Controls
{
    public class StrechItemsListView : ListView
    {
        public StrechItemsListView()
        {
            SizeChanged += StrechItemsListView_SizeChanged;
        }

        private void StrechItemsListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ItemsPanelRoot != null)
            {
                ItemsPanelRoot.Width = e.NewSize.Width;
            }
        }
    }
}
