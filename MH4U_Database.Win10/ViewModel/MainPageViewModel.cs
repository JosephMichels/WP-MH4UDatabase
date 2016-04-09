using App1.Pages;
using MH4U_Database.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App1.ViewModel
{

    public class NavigationEntry
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public Type Destination { get; set; }
    }

    public class MainPageViewModel : BaseViewModel
    {

        NavigationEntry[] _entries = new[]
        {
            new NavigationEntry() {Name="Monsters",IconPath="/Assets/icons_items/Book-White.png",Destination=typeof(MonsterListPage) },
            new NavigationEntry() {Name="Items",IconPath="/Assets/icons_items/Liquid-White.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Weapons",IconPath="/Assets/icons_items/charge_blade1.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Armor",IconPath="/Assets/icons_items/body1.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Skills",IconPath="/Assets/icons_items/Jewel-White.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Quests",IconPath="/Assets/icons_items/Quest-Icon-White.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Combinations",IconPath="/Assets/icons_items/Herb-White.png",Destination=typeof(MainPage) },
            new NavigationEntry() {Name="Wyporium",IconPath="/Assets/icons_items/Scale-White.png",Destination=typeof(MainPage) },
        };
        public NavigationEntry[] NavigationEntries { get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged(nameof(NavigationEntries));
            }
        }
    }
}
