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
                Page = nameof(TappedRoutedEventArgsGetPosition) }
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
