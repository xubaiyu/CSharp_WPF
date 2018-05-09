using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        // 楼层-户
        public Dictionary<int, DataTable> floorRoomsDict = new Dictionary<int, DataTable>();

        Dictionary<string, ObservableCollection<Customer>> RoomResidents = new Dictionary<string, ObservableCollection<Customer>>();
        public MyModel()
        {
            alist.Add(new BuildingFloorNo { FloorNo = -1 });
            alist.Add(new BuildingFloorNo { FloorNo = 1 });
            alist.Add(new BuildingFloorNo { FloorNo = 2});
            alist.Add(new BuildingFloorNo { FloorNo = 3 });
            alist.Add(new BuildingFloorNo { FloorNo = 4 });

            // 
            for (int i = -1; i < 5; i++)
            {
                DataTable pic0 = new DataTable();
                pic0.Columns.Add("FullPath");
                pic0.Columns.Add("Tips");
                pic0.Rows.Add(i + @"层01室", "1");
                pic0.Rows.Add(i + @"层02室", "2");
                floorRoomsDict.Add(i, pic0);

                ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();
                int itemcount0 = 10;
                for (int j = 0; j < itemcount0; j++)
                {
                    customers0.Add(new Customer()
                    {
                        ID = j,
                        Name = i + @"层01室:" + "姓名item" + j.ToString(),
                        Age = 10 + j
                    });
                }

                RoomResidents.Add(i + @"层01室", customers0);
            }
        }
    }
}
