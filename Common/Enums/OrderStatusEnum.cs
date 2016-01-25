using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum OrderStatusEnum
    {
        NotPaid = 1,
        Canceled = 2,
        Paid = 3,
        OnDelivery = 4,
        Finished = 5,
        PackageReady = 6
    }
}
