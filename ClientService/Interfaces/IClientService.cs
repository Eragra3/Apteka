using ClientLogic.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic.Interfaces
{
    public interface IClientService
    {
        UserModel Get(int id);

        UserModel Get(string login);

        int? Add(UserModel model);

        bool Remove(UserModel model);

        bool Edit(UserModel model);
    }
}
