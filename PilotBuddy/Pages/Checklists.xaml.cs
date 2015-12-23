using PilotBuddy.Models.ViewModel;
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

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace PilotBuddy.Pages
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Checklists : Page
    {
        private ChecklistViewModel _vm;
        public Checklists()
        {
            _vm = App.VM.ChecklistViewModel;
            this.DataContext = _vm;
            this.InitializeComponent();
            AC.SelectedItem = _vm.Aircrafts[_vm.ActiveAircraft];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _vm.NextChecklist();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            _vm.PreviousChecklist();
        }

        private void AircraftChanged_Handler(object sender, SelectionChangedEventArgs e)
        {
            _vm.SelectAircraft(((ComboBox)sender).SelectedValue.ToString());
        }
    }
}
