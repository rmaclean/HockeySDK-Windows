﻿using HockeyApp.Tools;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace HockeyApp.Views
{
    public partial class AppUpdateControl : UserControl
    {
        public IAppVersion NewestVersion { get; set; }

        public AppUpdateControl(IEnumerable<IAppVersion> appVersions, Action<IAppVersion> updateAction)
        {
            this.NewestVersion = appVersions.First();
            InitializeComponent();

            this.AppIconImage.ImageFailed += (sender, e) => { this.AppIconImage.Source = new BitmapImage(new Uri("/Assets/windows_phone.png", UriKind.RelativeOrAbsolute)); };
            this.AppIconImage.Source = new BitmapImage(new Uri(Constants.ApiBase + "apps/" + NewestVersion.PublicIdentifier + ".png"));

            this.ReleaseNotesBrowser.Opacity = 0;
            this.ReleaseNotesBrowser.Navigated += (sender, e) => { (this.ReleaseNotesBrowser.Resources["fadeIn"] as Storyboard).Begin(); };
            this.ReleaseNotesBrowser.NavigateToString(WebBrowserHelper.WrapContent(NewestVersion.Notes));

            this.InstallAETX.Click += (sender, e) =>
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri(Constants.ApiBase + "apps/" + NewestVersion.PublicIdentifier + ".aetx", UriKind.Absolute);
                webBrowserTask.Show();
            };
            this.InstallOverApi.Click += (sender, e) => {
                this.Overlay.Visibility = Visibility.Visible;
                updateAction.Invoke(NewestVersion); 
            };
            
        }

    }
}