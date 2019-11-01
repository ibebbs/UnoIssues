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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoIssues
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private static readonly IReadOnlyDictionary<string, Type> _pages = new Dictionary<string, Type>
        {
            { "Overview", typeof(Overview) },
            { "TappedRoutedEventArgsGetPosition", typeof(TappedRoutedEventArgsGetPosition) },
            { "PopupNotShowing", typeof(PopupNotShowing) },
        };

        public MainPage()
        {
            this.InitializeComponent();

            Navigator.Navigated += Navigator_Navigated;
        }

        private void Navigator_Navigated(object sender, NavigateEventArgs args)
        {
            NavigateTo(args.To, null);
        }

        private void NavigateTo(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            var item = _pages[navItemTag];

            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = contentFrame.CurrentSourcePageType;

            contentFrame.Navigate(item, null, transitionInfo);
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            // Add handler for ContentFrame navigation.
            NavigateTo("Overview", null);
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigateTo(args.SelectedItemContainer.Tag.ToString(), args.RecommendedNavigationTransitionInfo);
        }
    }
}
