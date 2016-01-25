using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using ClientService.Interfaces;
using DAL.Interfaces;
using DAL.Factory;
using Logging.Interfaces;
using Logging;

namespace ClientService.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
        private readonly ILogger _logger = new Logger();

        public bool Add(Client entity)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    uow.UserRepository.Insert(entity);

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

        public bool Edit(Client entity)
        {
            using (var uow = _factory.Create())
            {
                try
                {
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

        public Client Get(int id)
        {
            Client entity = null;
            using (var uow = _factory.Create())
            {
                try
                {
                    entity = uow.UserRepository.GetByID(id);

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                }
            }
            return entity;
        }

        public bool Remove(Client entity)
        {
            using (var uow = _factory.Create())
            {
                try
                {
                    uow.UserRepository.Delete(entity);

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
