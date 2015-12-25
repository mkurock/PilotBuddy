using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.UI.Xaml;

namespace PilotBuddy.Models.ViewModel
{
    public class TimeViewModel : BasicViewModel
    {
        #region Properties
        private string obt;

        public string OBT
        {
            get { return obt; }
            set {
                obt = value;
                OnPropertyChanged("OBT");
                OnPropertyChanged("OBTEnabled");
                OnPropertyChanged("OBTVisible");
            }
        }
        private string tot;

        public string TOT
        {
            get { return tot; }
            set {
                tot = value;
                OnPropertyChanged("TOT");
                OnPropertyChanged("TOTVisible");
                OnPropertyChanged("TOTEnabled");
            }
        }

        private string lnt;

        public string LNT
        {
            get { return lnt; }
            set {
                lnt = value;
                OnPropertyChanged("LNT");
                OnPropertyChanged("LNTVisible");
                OnPropertyChanged("LNTEnabled");
            }
        }
        private string onbt;

        public string ONBT
        {
            get { return onbt; }
            set {
                onbt = value;
                OnPropertyChanged("ONBT");
                OnPropertyChanged("ONBTVisible");
                OnPropertyChanged("ONBTEnabled");
            }
        }

        public Visibility OBTEnabled
        {
            get
            {
                return OBT == "" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility TOTEnabled
        {
            get
            {
                return TOT == "" ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility LNTEnabled
        {
            get
            {
                return LNT == "" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility ONBTEnabled
        {
            get
            {
                return ONBT == "" ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility OBTVisible
        {
            get
            {
                return OBT == "" ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility TOTVisible
        {
            get
            {
                return TOT == "" ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility LNTVisible
        {
            get
            {
                return LNT == "" ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility ONBTVisible
        {
            get
            {
                return ONBT == "" ? Visibility.Collapsed : Visibility.Visible;
            }
        }


        #endregion

        public TimeViewModel()
        {
            OBT = "";
            TOT = "";
            LNT = "";
            ONBT = "";
            ReadTimes();
        }

        public void SetTime(TimeType type)
        {
            var time = DateTime.UtcNow.ToString("HH:mm");
            switch (type)
            {
                case TimeType.OffBlock:
                    OBT = time;
                    break;
                case TimeType.TakeOff:
                    TOT = time;
                    break;
                case TimeType.Landing:
                    LNT = time;
                    break;
                case TimeType.OnBlock:
                    ONBT = time;
                    break;
                default:
                    break;
            }
            try
            {
                SaveTimes();
            }
            catch
            {

            }
        }

        public void ClearTime(TimeType type)
        {
            switch (type)
            {
                case TimeType.None:
                    break;
                case TimeType.OffBlock:
                    OBT = "";
                    break;
                case TimeType.TakeOff:
                    TOT = "";
                    break;
                case TimeType.Landing:
                    LNT = "";
                    break;
                case TimeType.OnBlock:
                    ONBT = "";
                    break;
                default:
                    break;
            }
            try
            {
                SaveTimes();
            } catch
            {

            }
        }

        public enum TimeType
        {
            None,
            OffBlock,
            TakeOff,
            Landing,
            OnBlock
        }

        private void ReadTimes()
        {
            if (!File.Exists("Assets/Data/Times.xml"))
            {
                CreateNewTimesFile();
            }
            else
            {
                using (var fs = File.OpenRead("Assets/Data/Times.xml"))
                {
                    var sr = new XmlSerializer(typeof(TimesModel));
                    var res = (TimesModel)sr.Deserialize(fs);
                    OBT = res.OBT;
                    TOT = res.TOT;
                    LNT = res.LNT;
                    ONBT = res.ONBT;
                }
            }
        }

        private void CreateNewTimesFile()
        {
            using(var fs = File.Open("Assets/Data/Times.xml", FileMode.OpenOrCreate))
            {
                var newItem = new TimesModel();
                newItem.OBT = "";
                newItem.TOT = "";
                newItem.LNT = "";
                newItem.ONBT = "";
                var sr = new XmlSerializer(newItem.GetType());
                sr.Serialize(fs, newItem);
            }
        }

        private void SaveTimes()
        {
            var toSave = new TimesModel
            {
                OBT = OBT,
                TOT = TOT,
                LNT = LNT,
                ONBT = ONBT
            };
            using (var fs = File.Open("Assets/Data/Times.xml", FileMode.Truncate))
            {
                var sr = new XmlSerializer(toSave.GetType());
                sr.Serialize(fs, toSave);
            }
        }
    }
}
