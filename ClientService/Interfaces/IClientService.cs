using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Interfaces
{
    public interface IClientService
    {
        Client Get(int id);

        bool Add(Client entity);

        bool Remove(Client entity);

        bool Edit(Client entity);
    }
}
