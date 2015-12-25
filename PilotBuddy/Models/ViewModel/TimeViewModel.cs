using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public enum TimeType
        {
            None,
            OffBlock,
            TakeOff,
            Landing,
            OnBlock
        }
    }
}
