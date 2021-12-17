using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.Models
{
    class Test : BindableBase
    {
        private Patient patient;
        public Patient Patient
        {
            get { return patient; }
            set { SetProperty(ref patient, value); }
        }

        private DateTime testDate;
        public DateTime TestDate
        {
            get { return testDate; }
            set { SetProperty(ref testDate, value); }
        }
        private Guid guid;
        public Guid Guid
        {
            get { return guid; }
            set { SetProperty(ref guid, value); }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }
        private DateTime resultDate;
        public DateTime ResultDate
        {
            get { return resultDate; }
            set { SetProperty(ref resultDate, value); }
        }
    }
}
