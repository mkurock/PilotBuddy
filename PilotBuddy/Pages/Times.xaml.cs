using PilotBuddy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace PilotBuddy.Pages
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Times : Page
    {
        private TimeViewModel _vm;
        public Times()
        {
            _vm = App.VM.TimeViewModel;
            this.DataContext = _vm;
            this.InitializeComponent();
        }

        private void Set_click(object sender, RoutedEventArgs e)
        {
            var btnClicked = (Button)sender;
            TimeViewModel.TimeType type = TimeViewModel.TimeType.None;
            switch (btnClicked.Name)
            {
                case "OBT":
                    type = TimeViewModel.TimeType.OffBlock;
                    break;
                case "TOT":
                    type = TimeViewModel.TimeType.TakeOff;
                    break;
                case "LNT":
                    type = TimeViewModel.TimeType.Landing;
                    break;
                case "ONBT":
                    type = TimeViewModel.TimeType.OnBlock;
                    break;
                default:
                    break;
            }
            _vm.SetTime(type);
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            MessageDialog dia = new MessageDialog("Do you want to clear this time?", "Confirm");
            dia.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.YesCommandHandler), sender));
            dia.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.YesCommandHandler)));
            dia.CancelCommandIndex = 1;
            dia.DefaultCommandIndex = 1;
            dia.ShowAsync();
        }

        private void YesCommandHandler (IUICommand cmd)
        {
            if(cmd.Label == "Yes")
            {
                var btn = (Button)cmd.Id;
                TimeViewModel.TimeType type = TimeViewModel.TimeType.None;
                switch (btn.Name)
                {
                    case "OBTClear":
                        type = TimeViewModel.TimeType.OffBlock;
                        break;
                    case "TOTClear":
                        type = TimeViewModel.TimeType.TakeOff;
                        break;
                    case "LNTClear":
                        type = TimeViewModel.TimeType.Landing;
                        break;
                    case "ONBTClear":
                        type = TimeViewModel.TimeType.OnBlock;
                        break;
                    default:
                        break;
                }
                _vm.ClearTime(type);
            }
        }

    }
}
