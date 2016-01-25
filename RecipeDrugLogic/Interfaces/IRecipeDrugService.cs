using RecipeDrugLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDrugLogic.Interfaces
{
    public interface IRecipeDrugService
    {
        RecipeDrugModel Get(int id);

        bool Add(RecipeDrugModel model);

        bool Remove(RecipeDrugModel model);

        bool Edit(RecipeDrugModel model);
    }
}
