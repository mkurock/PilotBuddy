using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PilotBuddy.Models
{


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Aircrafts
    {

        private AircraftsAircraft[] aircraftField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Aircraft")]
        public AircraftsAircraft[] Aircraft
        {
            get
            {
                return this.aircraftField;
            }
            set
            {
                this.aircraftField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AircraftsAircraft
    {

        private string titleField;

        private AircraftsAircraftChecklist[] checklistsField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Checklist", IsNullable = false)]
        public AircraftsAircraftChecklist[] Checklists
        {
            get
            {
                return this.checklistsField;
            }
            set
            {
                this.checklistsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AircraftsAircraftChecklist
    {

        private string titleField;

        private AircraftsAircraftChecklistItem[] itemsField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public AircraftsAircraftChecklistItem[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AircraftsAircraftChecklistItem
    {

        private string titleField;

        private string resultField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }


}