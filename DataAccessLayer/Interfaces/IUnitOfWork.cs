
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Client> UserRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Employee> EmployeeRepository { get; }
        GenericRepository<Package> PackageRepository { get; }
        GenericRepository<Invoice> InvoiceRepository { get; }
        GenericRepository<Contains> ContainsRepository { get; }
        GenericRepository<RecipeDrug> RecipeDrugRepository { get; }
        GenericRepository<Manager> ManagerRepository { get; }
        GenericRepository<ManagerStatus> ManagerStatusRepository { get; }
        GenericRepository<PackageStatus> PackageStatusRepository { get; }
        GenericRepository<OrderStatus> OrderStatusRepository { get; }
        GenericRepository<Position> PositionRepository { get; }
        GenericRepository<Ingridient> IngridientRepository { get; }
        GenericRepository<Shipping> ShippingRepository { get; }

        void Save();
    }
}
