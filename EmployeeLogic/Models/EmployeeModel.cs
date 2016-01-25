using Common.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogic.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }

        public string Index { get; set; }

        public PositionEnum Position { get; set; }

        public EmployeeModel()
        {

        }

        public EmployeeModel(Employee model)
        {
            if (model != null)
            {
                ID = model.ID;
                FirstName = model.FirstName;
                LastName = model.LastName;
                JoinDate = model.JoinDate;
                Index = model.Index;
                Position = (PositionEnum)model.PositionID;
            }
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
