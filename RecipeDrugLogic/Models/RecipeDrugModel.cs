﻿using ClientLogic.Models;
using Common.Enums;
using DAL.Models;
using EmployeeLogic.Models;
using PackageLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDrugLogic.Models
{
    public class RecipeDrugModel
    {

        public int ID { get; set; }

        public int PackageID { get; set; }

        public PackageModel Package { get; set; }

        public int UserID { get; set; }

        public UserModel User { get; set; }

        public int? MadeByID { get; set; }

        public EmployeeModel MadeBy { get; set; }

        public DateTime? EvaluatedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public OrderStatusEnum Status { get; set; }

        public IList<IngridientModel> Ingridients { get; set; }

        public RecipeDrugModel()
        {
            Ingridients = new List<IngridientModel>(5);
        }

        public RecipeDrugModel(RecipeDrug entity)
        {
            ID = entity.ID;
            PackageID = entity.PackageID;
            Package = new PackageModel(entity.Package);
            UserID = entity.ClientID;
            User = new UserModel(entity.Client);
            MadeByID = entity.MadeByID;
            MadeBy = entity.MadeBy == null ? null : new EmployeeModel(entity.MadeBy);
            EvaluatedDate = entity.EvaluatedDate;
            CreatedDate = entity.CreatedDate;
            Status = (OrderStatusEnum)entity.StatusID;
            Ingridients = entity.Ingridients.Select(x => new IngridientModel(x)).ToList() ?? new List<IngridientModel>(5);

        }

        public RecipeDrug ToEntity()
        {
            var entity = new RecipeDrug
            {
                ID = ID,
                PackageID = PackageID,
                Package = Package?.ToEntity(),
                ClientID = UserID,
                Client = User?.ToEntity(),
                MadeByID = MadeByID,
                MadeBy = MadeBy?.ToEntity(),
                EvaluatedDate = EvaluatedDate,
                CreatedDate = CreatedDate,
                StatusID = (int)Status,
                Ingridients = Ingridients.Select(x => { var m = x.ToEntity(); m.RecipeDrugID = ID; return m; }).ToList(),
            };
            return entity;
        }
    }

}
