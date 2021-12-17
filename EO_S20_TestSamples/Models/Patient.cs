using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.Models
{
    class Patient : BindableBase
    {
        private string ssn;
        public string Ssn
        {
            get { return ssn; }
            set { SetProperty(ref ssn, value); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}
