using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotBuddy.Models
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class response
    {

        private uint request_indexField;

        private responseData_source data_sourceField;

        private responseRequest requestField;

        private object errorsField;

        private object warningsField;

        private byte time_taken_msField;

        private responseData dataField;

        private string noNamespaceSchemaLocationField;

        private decimal versionField;

        /// <remarks/>
        public uint request_index
        {
            get
            {
                return this.request_indexField;
            }
            set
            {
                this.request_indexField = value;
            }
        }

        /// <remarks/>
        public responseData_source data_source
        {
            get
            {
                return this.data_sourceField;
            }
            set
            {
                this.data_sourceField = value;
            }
        }

        /// <remarks/>
        public responseRequest request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        public object errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public object warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }

        /// <remarks/>
        public byte time_taken_ms
        {
            get
            {
                return this.time_taken_msField;
            }
            set
            {
                this.time_taken_msField = value;
            }
        }

        /// <remarks/>
        public responseData data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2001/XML-Schema-instance")]
        public string noNamespaceSchemaLocation
        {
            get
            {
                return this.noNamespaceSchemaLocationField;
            }
            set
            {
                this.noNamespaceSchemaLocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseData_source
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseRequest
    {

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseData
    {

        private responseDataMETAR[] mETARField;

        private byte num_resultsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("METAR")]
        public responseDataMETAR[] METAR
        {
            get
            {
                return this.mETARField;
            }
            set
            {
                this.mETARField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte num_results
        {
            get
            {
                return this.num_resultsField;
            }
            set
            {
                this.num_resultsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseDataMETAR
    {

        private string raw_textField;

        private string station_idField;

        private System.DateTime observation_timeField;

        private decimal latitudeField;

        private decimal longitudeField;

        private decimal temp_cField;

        private decimal dewpoint_cField;

        private byte wind_dir_degreesField;

        private byte wind_speed_ktField;

        private decimal visibility_statute_miField;

        private decimal altim_in_hgField;

        private decimal sea_level_pressure_mbField;

        private responseDataMETARQuality_control_flags quality_control_flagsField;

        private responseDataMETARSky_condition[] sky_conditionField;

        private string flight_categoryField;

        private decimal precip_inField;

        private bool precip_inFieldSpecified;

        private decimal three_hr_pressure_tendency_mbField;

        private bool three_hr_pressure_tendency_mbFieldSpecified;

        private decimal maxT_cField;

        private bool maxT_cFieldSpecified;

        private decimal minT_cField;

        private bool minT_cFieldSpecified;

        private decimal pcp6hr_inField;

        private bool pcp6hr_inFieldSpecified;

        private string metar_typeField;

        private decimal elevation_mField;

        /// <remarks/>
        public string raw_text
        {
            get
            {
                return this.raw_textField;
            }
            set
            {
                this.raw_textField = value;
            }
        }

        /// <remarks/>
        public string station_id
        {
            get
            {
                return this.station_idField;
            }
            set
            {
                this.station_idField = value;
            }
        }

        /// <remarks/>
        public System.DateTime observation_time
        {
            get
            {
                return this.observation_timeField;
            }
            set
            {
                this.observation_timeField = value;
            }
        }

        /// <remarks/>
        public decimal latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public decimal longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        public decimal temp_c
        {
            get
            {
                return this.temp_cField;
            }
            set
            {
                this.temp_cField = value;
            }
        }

        /// <remarks/>
        public decimal dewpoint_c
        {
            get
            {
                return this.dewpoint_cField;
            }
            set
            {
                this.dewpoint_cField = value;
            }
        }

        /// <remarks/>
        public byte wind_dir_degrees
        {
            get
            {
                return this.wind_dir_degreesField;
            }
            set
            {
                this.wind_dir_degreesField = value;
            }
        }

        /// <remarks/>
        public byte wind_speed_kt
        {
            get
            {
                return this.wind_speed_ktField;
            }
            set
            {
                this.wind_speed_ktField = value;
            }
        }

        /// <remarks/>
        public decimal visibility_statute_mi
        {
            get
            {
                return this.visibility_statute_miField;
            }
            set
            {
                this.visibility_statute_miField = value;
            }
        }

        /// <remarks/>
        public decimal altim_in_hg
        {
            get
            {
                return this.altim_in_hgField;
            }
            set
            {
                this.altim_in_hgField = value;
            }
        }

        /// <remarks/>
        public decimal sea_level_pressure_mb
        {
            get
            {
                return this.sea_level_pressure_mbField;
            }
            set
            {
                this.sea_level_pressure_mbField = value;
            }
        }

        /// <remarks/>
        public responseDataMETARQuality_control_flags quality_control_flags
        {
            get
            {
                return this.quality_control_flagsField;
            }
            set
            {
                this.quality_control_flagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sky_condition")]
        public responseDataMETARSky_condition[] sky_condition
        {
            get
            {
                return this.sky_conditionField;
            }
            set
            {
                this.sky_conditionField = value;
            }
        }

        /// <remarks/>
        public string flight_category
        {
            get
            {
                return this.flight_categoryField;
            }
            set
            {
                this.flight_categoryField = value;
            }
        }

        /// <remarks/>
        public decimal precip_in
        {
            get
            {
                return this.precip_inField;
            }
            set
            {
                this.precip_inField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool precip_inSpecified
        {
            get
            {
                return this.precip_inFieldSpecified;
            }
            set
            {
                this.precip_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal three_hr_pressure_tendency_mb
        {
            get
            {
                return this.three_hr_pressure_tendency_mbField;
            }
            set
            {
                this.three_hr_pressure_tendency_mbField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool three_hr_pressure_tendency_mbSpecified
        {
            get
            {
                return this.three_hr_pressure_tendency_mbFieldSpecified;
            }
            set
            {
                this.three_hr_pressure_tendency_mbFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal maxT_c
        {
            get
            {
                return this.maxT_cField;
            }
            set
            {
                this.maxT_cField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool maxT_cSpecified
        {
            get
            {
                return this.maxT_cFieldSpecified;
            }
            set
            {
                this.maxT_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal minT_c
        {
            get
            {
                return this.minT_cField;
            }
            set
            {
                this.minT_cField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool minT_cSpecified
        {
            get
            {
                return this.minT_cFieldSpecified;
            }
            set
            {
                this.minT_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal pcp6hr_in
        {
            get
            {
                return this.pcp6hr_inField;
            }
            set
            {
                this.pcp6hr_inField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pcp6hr_inSpecified
        {
            get
            {
                return this.pcp6hr_inFieldSpecified;
            }
            set
            {
                this.pcp6hr_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string metar_type
        {
            get
            {
                return this.metar_typeField;
            }
            set
            {
                this.metar_typeField = value;
            }
        }

        /// <remarks/>
        public decimal elevation_m
        {
            get
            {
                return this.elevation_mField;
            }
            set
            {
                this.elevation_mField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseDataMETARQuality_control_flags
    {

        private string auto_stationField;

        /// <remarks/>
        public string auto_station
        {
            get
            {
                return this.auto_stationField;
            }
            set
            {
                this.auto_stationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseDataMETARSky_condition
    {

        private ushort cloud_base_ft_aglField;

        private string sky_coverField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort cloud_base_ft_agl
        {
            get
            {
                return this.cloud_base_ft_aglField;
            }
            set
            {
                this.cloud_base_ft_aglField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sky_cover
        {
            get
            {
                return this.sky_coverField;
            }
            set
            {
                this.sky_coverField = value;
            }
        }
    }



}
