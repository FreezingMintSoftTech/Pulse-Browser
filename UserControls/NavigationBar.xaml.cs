﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Pulse_Browser.UserControls
{
    public sealed partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            this.InitializeComponent();
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.QueryText))
            {
                bool isUri = Uri.TryCreate(args.QueryText, UriKind.Absolute, out Uri destination)
                    && (destination.Scheme == Uri.UriSchemeHttp || destination.Scheme == Uri.UriSchemeHttps);

                if (isUri)
                {
                    Services.WebNavigationService.Navigate(destination);
                }
                else
                {
                    Uri searchAddress = new Uri($"https://www.google.com/search?q={HttpUtility.UrlEncode(args.QueryText)}");
                    Services.WebNavigationService.Navigate(searchAddress);
                }
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Services.WebNavigationService.Navigate(new Uri("about:home"));
        }

        private void SettingsMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HistoryMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
