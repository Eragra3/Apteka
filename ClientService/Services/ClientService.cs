using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using ClientLogic.Interfaces;
using DAL.Interfaces;
using DAL.Factory;
using Logging.Interfaces;
using Logging;
using ClientLogic.Models;

namespace ClientLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
        private readonly ILogger _logger = new Logger();

        public int? Add(UserModel model)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = model.ToEntity();

                    uow.UserRepository.Insert(entity);

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

        public bool Edit(UserModel model)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = model.ToEntity();

                    uow.UserRepository.Update(entity);

                    uow.Save();

                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                    return false;
                }
            }
        }

        public UserModel Get(string login)
        {
            UserModel model = null;
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = uow.UserRepository.Get(e => e.Email.Equals(login));

                    if (entity == null || entity.Count() < 1) return null;

                    model = new UserModel(entity.FirstOrDefault());

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                }
            }
            return model;
        }

        public UserModel Get(int id)
        {
            UserModel model = null;
            using (var uow = _factory.Create())
            {
                try
                {
                    var entity = uow.UserRepository.GetByID(id);

                    model = new UserModel(entity);

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                }
            }
            return model;
        }

        public bool Remove(UserModel entity)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    uow.UserRepository.Delete(entity.ToEntity());

                    uow.Save();

                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                    return false;
                }
            }
        }
    }
}
