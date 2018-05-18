
using System.ComponentModel;
namespace BuildingFloor
{
    public class Customer
    {
        [DisplayName("身份证")]
        public int ID { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }

        [DisplayName("年龄")]
        public int Age { get; set; }
    }


    public class BuildingFloorNo
    {
        public int FloorNo
        {
            get;
            set;

        }

    }
}
