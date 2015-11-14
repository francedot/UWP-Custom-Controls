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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ConfirmDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {                   
            CustomControls.ConfirmDialog dialog = new CustomControls.ConfirmDialog
            {
                Setting = "SettingSample", //name of the setting to serialize
                Title = "Alert",
                Message = "Do you confirm?",
                ContentCheckBox = "Don't ask me again!",
                MinWidth = Window.Current.Bounds.Width,
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"
            };

            WindowSizeChangedEventHandler handler = (s, args) =>
            {
                dialog.MinWidth = Window.Current.Bounds.Width;
            };
            Window.Current.SizeChanged += handler;

            ContentDialogResult result = await dialog.ShowAsync();

            Window.Current.SizeChanged -= handler;
        }
    }
}
