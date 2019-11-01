using System;

namespace UnoIssues
{
    public class NavigateEventArgs : EventArgs
    {
        public string To { get; set; }
    }

    public delegate void NavigateHandler(object sender, NavigateEventArgs args);

    public static class Navigator
    {
        public static event NavigateHandler Navigated;

        public static void Navigate(object sender, string to)
        {
            Navigated?.Invoke(sender, new NavigateEventArgs { To = to });
        }
    }
}
