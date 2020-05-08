using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Wpf
{
    public class LocationVM : ObservableObject
    {
        private decimal id;
        private string country;
        private string street;
        private decimal house_Number;
        private decimal zip_Code;

        public decimal Zip_Code
        {
            get { return zip_Code; }
            set { Set(ref zip_Code, value); }
        }
        public decimal House_Number
        {
            get { return house_Number; }
            set { Set(ref house_Number, value); }
        }
        public string Street
        {
            get { return street; }
            set { Set(ref street, value); }
        }

        public string Country
        {
            get { return country; }
            set { Set(ref country, value); }
        }
        public decimal ID
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        public void CopyFrom(LocationVM other)
        {
            if (other == null) return;
            this.ID = other.ID;
            this.Country = other.Country;
            this.Street = other.Street;
            this.House_Number = other.House_Number;
            this.Zip_Code = other.Zip_Code;
        }
    }
}
