using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotBuddy.Models
{
    public class MainViewModel : BasicViewModel
    {

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



        public MainViewModel()
        {

        }
    }
}
