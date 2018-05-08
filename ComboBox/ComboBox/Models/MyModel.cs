using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFloor.Models
{
    public class MyModel
    {
         private static readonly Lazy<MyModel> lazy = new Lazy<MyModel>(() => new MyModel());

        public static MyModel Instance
        {
            get { return lazy.Value; }
        }

        public Action<ObservableCollection<BuildingFloorNo>> UpateFloorsInfoEvent;
        public void NotifyGetFloor()
        {
            if(UpateFloorsInfoEvent != null)
            {
                UpateFloorsInfoEvent.Invoke(alist);
            }
        }
        private ObservableCollection<BuildingFloorNo> alist = new ObservableCollection<BuildingFloorNo>();
        public MyModel()
        {
            alist.Add(new BuildingFloorNo { FloorNo = -10 });
            alist.Add(new BuildingFloorNo { FloorNo = 10 });
            alist.Add(new BuildingFloorNo { FloorNo = 20});
            alist.Add(new BuildingFloorNo { FloorNo = 30 });
            alist.Add(new BuildingFloorNo { FloorNo = 40 });
        }
    }
}
