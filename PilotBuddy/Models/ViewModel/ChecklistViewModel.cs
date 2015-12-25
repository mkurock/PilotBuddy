using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PilotBuddy.Models.ViewModel
{
    public class ChecklistViewModel : BasicViewModel
    {
        public Aircrafts Checklists { get; set; }
        public AircraftsAircraftChecklist CurrentChecklist { get; set; }

        private int checklistCount;

        public int ChecklistCount
        {
            get { return checklistCount; }
            set {
                checklistCount = value;
                OnPropertyChanged("ChecklistCount");
            }
        }

        public int CurrentChecklistIndex
        {
            get
            {
                return currentChecklistIndex + 1;
            }
        }

        private Dictionary<int, string> aircrafts;

        public Dictionary<int, string> Aircrafts
        {
            get
            {
                return aircrafts;
            }
        }
        private List<String> comboBoxContent;
        public List<String> ComboBoxContent
        {
            get
            {
                return comboBoxContent;
            }
        }

        private int activeAircraft;
        public int ActiveAircraft
        {
            get
            {
                return activeAircraft;
            }
            set
            {
                activeAircraft = value;
                OnPropertyChanged("ActiveAircraft");
            }
        }

        internal void SelectAircraft(string AC)
        {
            var NewAc = Aircrafts.FirstOrDefault(x => x.Value == AC);
            ActiveAircraft = NewAc.Key;
            currentChecklistIndex = 0;
            CurrentChecklist = Checklists.Aircraft[ActiveAircraft].Checklists[currentChecklistIndex];
            ChecklistCount = Checklists.Aircraft[ActiveAircraft].Checklists.Length;
            OnPropertyChanged("CurrentChecklist");
            OnPropertyChanged("CurrentChecklistIndex");
            OnPropertyChanged("ChecklistPosition");
            OnPropertyChanged("ActiveAircraft");

        }

        private int currentChecklistIndex;

        public ChecklistViewModel()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Aircrafts));
            XmlReader xr = XmlReader.Create("Assets/Data/Checklists.xml");
            var checklists = (Aircrafts)xs.Deserialize(xr);
            Checklists = checklists;
            currentChecklistIndex = 0;
            aircrafts = new Dictionary<int, string>();
            comboBoxContent = new List<string>();

            for (int i = 0; i < Checklists.Aircraft.Length; i++)
            {
                aircrafts.Add(i, Checklists.Aircraft[i].Title);
                comboBoxContent.Add(Checklists.Aircraft[i].Title);
            }
            ActiveAircraft = 0;


            CurrentChecklist = checklists.Aircraft[ActiveAircraft].Checklists[currentChecklistIndex];
            ChecklistCount = checklists.Aircraft[ActiveAircraft].Checklists.Length;
        }

        public string ChecklistPosition
        {
            get
            {
                return String.Format("{0}/{1}", CurrentChecklistIndex, ChecklistCount);
            }
        }

        internal void NextChecklist()
        {
            if(currentChecklistIndex < Checklists.Aircraft[0].Checklists.Length - 1)
                currentChecklistIndex++;
            CurrentChecklist = Checklists.Aircraft[0].Checklists[currentChecklistIndex];
            OnPropertyChanged("CurrentChecklist");
            OnPropertyChanged("CurrentChecklistIndex");
            OnPropertyChanged("ChecklistPosition");
        }

        internal void PreviousChecklist()
        {
            if (currentChecklistIndex > 0)
                currentChecklistIndex--;
            CurrentChecklist = Checklists.Aircraft[0].Checklists[currentChecklistIndex];
            OnPropertyChanged("CurrentChecklist");
            OnPropertyChanged("CurrentChecklistIndex");
            OnPropertyChanged("ChecklistPosition");
        }
    }
}
