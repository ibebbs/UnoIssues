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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UnoIssues
{
    public class Issue
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> PlatformsAffected { get; set; }

        public IEnumerable<string> PackagesAffected { get; set; }

        public string Page { get; set; }

        public string IssueUri { get; set; }
    }

    public class ViewModel
    {
        private static readonly IEnumerable<Issue> AllItems = new[]
        {
            new Issue 
            { 
                Name = "TappedRoutedEventArgs.GetPosition in WASM", 
                Description = "TappedRoutedEventArgs.GetPosition works on most platforms but fails with a 'Specified method is not supported' on WASM",
                PlatformsAffected = new [] { "WASM" },
                PackagesAffected = new [] { "Uno.UI 1.45.0" },
                Page = nameof(TappedRoutedEventArgsGetPosition),
                IssueUri = "https://github.com/unoplatform/uno/issues/2012"
            },
            new Issue
            {
                Name = "Popup not showing in WASM",
                Description = "Popup works on most platforms but is not shown on WASM",
                PlatformsAffected = new [] { "WASM" },
                PackagesAffected = new [] { "Uno.UI 2.0.512-dev.3670" },
                Page = nameof(PopupNotShowing),
                IssueUri = ""
            },
            new Issue
            {
                Name = "Horizontal Paths incorrectly clipped",
                Description = "Horizontal Path (and Line) instances are incorrectly clipped",
                PlatformsAffected = new [] { "iOS" },
                PackagesAffected = new [] { "Uno.UI 2.2" },
                Page = nameof(StrokeNotVisibleOniOS),
                IssueUri = ""
            }
        };

        public IEnumerable<Issue> Items => AllItems;
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overview : Page
    {

        public Overview()
        {
            this.InitializeComponent();

            DataContext = new ViewModel();
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var issue = args.AddedItems.OfType<Issue>().FirstOrDefault();

            if (issue != null)
            {
                Navigator.Navigate(this, issue.Page);
            }
        }
    }
}
