using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngridientLogic.Models
{
    public class IngridientModel
    {
        public int ID { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int RecipeDrugID { get; set; }

        public virtual RecipeDrugModel RecipeDrug { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
        public EmployeeModel()
        {

        }

        public EmployeeModel(Employee model)
        {
            ID = model.ID;
            FirstName = model.FirstName;
            LastName = model.LastName;
            JoinDate = model.JoinDate;
            Index = model.Index;
            Position = (PositionEnum)model.PositionID;
        }

        public Employee ToEntity()
        {
            var entity = new Employee()
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
                JoinDate = JoinDate,
                Index = Index,
                PositionID = (int)Position
            };
            return entity;
        }
    }
}
