using SimpleRestApi.Entities;

namespace SimpleRestApi.Service
{
    public class CustomerService : ICustomerService
    {
        readonly List<Customer> _customers = new List<Customer>
        {
            new() {Id=1, Firstname="Patr", Surname = "Pecz" },
            new() {Id=2, Firstname="Anna", Surname = "Brock" },
            new() {Id=3, Firstname="Adam", Surname = "Alan" },
            new() {Id=4, Firstname="Lola", Surname = "Noir" }
        };

        readonly ILogger<CustomerService> _logger;


        public CustomerService(ILogger<CustomerService> logger) => _logger = logger;

        public void CreateNewCustomer(Customer customer) => _customers.Add(customer);

        public void DeleteCustomer(int id)
        {
            var searched = _customers.Find(x => x.Id == id);

            if (searched != null)
            {
                _customers.Remove(searched);
            }
        }

        public IEnumerable<Customer> GetAllCustomers() => _customers;

        public Customer GetCustomerById(int id) => _customers.FirstOrDefault(x => x.Id == id);
    }
}