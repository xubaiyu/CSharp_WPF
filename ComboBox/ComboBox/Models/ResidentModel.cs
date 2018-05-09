using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFloor.Models
{
    public class ResidentModel
    {
        private static readonly Lazy<ResidentModel> lazy = new Lazy<ResidentModel>(() => new ResidentModel());

        public static ResidentModel Instance
        {
            get { return lazy.Value; }
        }

        private ResidentModel()
        {

        }

        public Action<ObservableCollection<Customer>> UpateCustomerInfoEvent;
        public void NotifyGetCustomer(ObservableCollection<Customer> aObj)
        {
            if (UpateCustomerInfoEvent != null)
            {
                UpateCustomerInfoEvent.Invoke(aObj);
            }
        }
    }
}
