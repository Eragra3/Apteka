using RecipeDrugLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeDrugLogic.Models;
using DAL.Interfaces;
using DAL.Factory;
using Logging;
using Logging.Interfaces;

namespace RecipeDrugLogic.Services
{
    public class RecipeDrugService : IRecipeDrugService
    {
        private readonly IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
        private readonly ILogger _logger = new Logger();

        public int? Add(RecipeDrugModel model)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = model.ToEntity();

                    uow.RecipeDrugRepository.Insert(entity);

                    uow.Save();

                    return entity.ID;
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                    return null;
                }
            }
        }

        public bool Edit(RecipeDrugModel model)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    uow.RecipeDrugRepository.Update(model.ToEntity());

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                    return false;
                }
            }
            return true;
        }

        public RecipeDrugModel Get(int id)
        {
            RecipeDrugModel model = null;
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = uow.RecipeDrugRepository.GetByID(id);

                    if (entity == null) return null;

                    model = new RecipeDrugModel(entity);

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                }
            }
            return model;
        }

        public bool Remove(RecipeDrugModel model)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    uow.RecipeDrugRepository.Delete(model.ToEntity());

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                    return false;
                }
            }
            return true;
        }
    }
}
