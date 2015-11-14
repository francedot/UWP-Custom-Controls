using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ConfirmDialog.CustomControls
{
    public sealed partial class ConfirmDialog : ContentDialog
    {

        private static DependencyProperty s_messageProperty =
            DependencyProperty.Register("Message", typeof (string), typeof (ConfirmDialog),
                new PropertyMetadata(null));

        public static DependencyProperty MessageProperty
        {
            get { return s_messageProperty; }
        }

        public string Message
        {
            get { return (string) GetValue(s_messageProperty); }
            set { SetValue(s_messageProperty, value); }
        }

        private static DependencyProperty s_contentCheckBoxProperty =
            DependencyProperty.Register("ContentCheckBox", typeof(string), typeof(ConfirmDialog),
                new PropertyMetadata(null));

        public static DependencyProperty ContentCheckBoxProperty
        {
            get { return s_contentCheckBoxProperty; }
        }

        public string ContentCheckBox
        {
            get { return (string)GetValue(s_contentCheckBoxProperty); }
            set { SetValue(s_contentCheckBoxProperty, value); }
        }

        private static DependencyProperty s_settingProperty =
            DependencyProperty.Register("Setting", typeof(string), typeof(ConfirmDialog),
                new PropertyMetadata(null));

        public static DependencyProperty SettingProperty
        {
            get { return s_settingProperty; }
        }

        public string Setting
        {
            get { return (string)GetValue(s_settingProperty); }
            set
            {
                SetValue(s_settingProperty, value);
                if (value == null)
                    this.NeverShowAgain.Visibility = Visibility.Collapsed;
            }
        }

        public ConfirmDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Setting != null)
                CheckedHelper();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Setting != null)
                CheckedHelper();
        }

        private void CheckedHelper()
        {

            if (!ApplicationData.Current.RoamingSettings.Values.ContainsKey(Setting))
            {
                if (NeverShowAgain.IsChecked != null && NeverShowAgain.IsChecked.Value)
                {
                    ApplicationData.Current.RoamingSettings.Values.Add(Setting, true);
                }
                else //not necessary
                {
                    //ApplicationData.Current.RoamingSettings.Values.Add("NeverShowAgainDeleteET", false);
                }
            }
            else
            {
                if (NeverShowAgain.IsChecked != null && NeverShowAgain.IsChecked.Value)
                {
                    ApplicationData.Current.RoamingSettings.Values[Setting] = true;
                }
                else //not necessary
                {
                    //ApplicationData.Current.RoamingSettings.Values["NeverShowAgainDeleteET"] = false;
                }
            }
        }
    }
}
