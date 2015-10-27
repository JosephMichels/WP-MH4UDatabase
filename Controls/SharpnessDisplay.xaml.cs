using MH4U_Database.Database;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MH4U_Database.Controls
{
    public sealed partial class SharpnessDisplay : UserControl
    {
        public Sharpness Sharpness
        {
            get { return (Sharpness)GetValue(SharpnessProperty); }
            set
            {
                SetValue(SharpnessProperty, value);
            }
        }

        public int SharpnessHeight
        {
            get { return (int)GetValue(SharpnessHeightProperty); }
            set
            {
                SetValue(SharpnessHeightProperty, value);
            }
        }

        public static readonly DependencyProperty SharpnessProperty = DependencyProperty.Register("Sharpness",typeof(Sharpness),typeof(SharpnessDisplay), null);
        public static readonly DependencyProperty SharpnessHeightProperty = DependencyProperty.Register("SharpnessHeight", typeof(int), typeof(SharpnessDisplay), null);

        public SharpnessDisplay()
        {
            this.InitializeComponent();

            SharpnessHeight = 4;
        }
    }
}
