using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PilotBuddy.Models
{
    public class WeatherViewModel : BasicViewModel
    {

        private const string weatherUrl = "https://aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString={station}&hoursBeforeNow={hours}";



        private string input;
        public string Input
        {
            get { return input; }
            set { input = value; OnPropertyChanged("Input"); OnPropertyChanged("canClick"); }
        }

        public bool canClick { get
            {
                if (Input == "" || Input == null)
                    return false;
                else
                    return true;
            }
        }

        public List<String> MetarAirports { get; set; }

        private ObservableCollection<SimpleMetarResult> results;
        public ObservableCollection<SimpleMetarResult> Results
        {
            get { return results; }
            set { results = value; }
        }

        public WeatherViewModel()
        {
            results = new ObservableCollection<SimpleMetarResult>();
            MetarAirports = new List<string>();
            MetarAirports.Add("EDLP");
            MetarAirports.Add("EDDG");
            MetarAirports.Add("EDDK");
            MetarAirports.Add("EDDV");
            MetarAirports.Add("EDDL");
            MetarAirports.Add("EDDH");
            MetarAirports.Add("EDDM");
            MetarAirports.Add("EDDS");
        }

        public async void GetWeatherStations(string input)
        {
            Results.Clear();
            HttpClient client = new HttpClient();
            var result = await client.GetStreamAsync(weatherUrl.Replace("{station}", input).Replace("{hours}", "1"));
            XmlSerializer xs = new XmlSerializer(typeof(response));
            var m = (response)xs.Deserialize(result);
            
            result.Dispose();
            //Results.Clear();
            if (m.data.METAR == null)
                return;
            foreach (var item in m.data.METAR)
            {
                Results.Add(new SimpleMetarResult() { StationId = item.station_id, RawMetar = item.raw_text });
            }
            Input = "";
        }
    }
}
