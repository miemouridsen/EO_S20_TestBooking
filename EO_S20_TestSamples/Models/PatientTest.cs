using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.Models
{
    public class PatientTest : BindableBase
    {
        //[JsonPropertyName("SSN")]
        private string ssn;
        public string Ssn
        {
            get { return ssn; }
            set { SetProperty(ref ssn, value); }
        }
        //[JsonPropertyName("Name")]
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        //[JsonPropertyName("TestDate")]
        private DateTime testDate;
        public DateTime TestDate
        {
            get { return testDate; }
            set { SetProperty(ref testDate, value); }
        }
        //[JsonPropertyName("Status")]
        private string status;
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
        //[JsonPropertyName("Guid")]
        private Guid guid;
        public Guid Guid
        {
            get { return guid; }
            set { SetProperty(ref guid, value); }
        }
        //[JsonPropertyName("ResultDate")]
        private DateTime resultDate;
        public DateTime ResultDate
        {
            get { return resultDate; }
            set { SetProperty(ref resultDate, value); }
        }
        //[JsonPropertyName("Result")]
        private string result;
        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }
    }
}
