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

namespace UnoIssues
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TappedRoutedEventArgsGetPosition : Page
    {
        public TappedRoutedEventArgsGetPosition()
        {
            this.InitializeComponent();
        }

        private void TappedEventHandler(object sender, TappedRoutedEventArgs args)
        {
            try
            {
                var position = args.GetPosition(args.OriginalSource as UIElement);
                coordinates.Text = $"Clicked: {position.X}, {position.Y}";
            }
            catch (Exception e)
            {
                coordinates.Text = $"Exception while calling TappedRoutedEventArgs: {e.Message}";
            }
        }
    }
}
