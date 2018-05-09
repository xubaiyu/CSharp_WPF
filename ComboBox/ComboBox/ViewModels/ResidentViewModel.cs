using BuildingFloor.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFloor.ViewModels
{
    class ResidentViewModel : ViewModelBase
    {
        public RelayCommand closeCommand { private set; get; }
        private ObservableCollection<Customer> custmers = new ObservableCollection<Customer>();
      
        public ObservableCollection<Customer> Residents
        {
            get { return custmers; }
            set { custmers = value; }

        }
        public ResidentViewModel()
        {
            closeCommand = new RelayCommand(closeCommand_CallBack);
            ResidentModel.Instance.UpateCustomerInfoEvent += UpateCustomerInfoEvent_CallBack;

        }

        private void closeCommand_CallBack()
        {
            ResidentModel.Instance.UpateCustomerInfoEvent -= UpateCustomerInfoEvent_CallBack;
        }

        private void UpateCustomerInfoEvent_CallBack(ObservableCollection<Customer> obj)
        {
            Residents.Clear();
            foreach (Customer a in obj)
            {
                Residents.Add(a);
            }
        }

       
    }
}
