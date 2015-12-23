using PilotBuddy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotBuddy.Models
{
    public class MainViewModel : BasicViewModel
    {
        Windows.System.Display.DisplayRequest req;
        private NavigationViewModel navVM;

        public NavigationViewModel NavigationViewModel
        {
            get
            {
                if (navVM == null)
                    navVM = new NavigationViewModel();
                return navVM;
            }
        }

        private WeatherViewModel weatherVM;

        public WeatherViewModel WeatherViewModel
        {
            get
            {
                if (weatherVM == null)
                    weatherVM = new WeatherViewModel();
                return weatherVM;
            }
        }

        private TimeViewModel timeVM;
        public TimeViewModel TimeViewModel
        {
            get
            {
                if (timeVM == null)
                    timeVM = new TimeViewModel();
                return timeVM;
            }
        }
        public Windows.System.Display.DisplayRequest DisplayRequest
        {
            get
            {
                return req;
            }
        }
        private ChecklistViewModel checklistVM;

        public ChecklistViewModel ChecklistViewModel
        {
            get
            {
                if (checklistVM == null)
                    checklistVM = new ChecklistViewModel();
                return checklistVM;
            }
        }



        public MainViewModel()
        {
            req = new Windows.System.Display.DisplayRequest();
        }
    }
}
