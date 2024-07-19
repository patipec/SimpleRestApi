
using SimpleRestApi.Entities;

namespace SimpleRestApi.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly List<Customer> _customers = new List<Customer>();




        readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {   _logger = logger; }


        public void CreateNewCustomer(Customer customer)
        {
            _customers.Add(customer);
            _logger.LogInformation("Customer added");
        }

        public void DeleteCustomer(int id)
        {
            var searched = _customers.Find(x => x.Id == id);

            if (searched != null)
            {
                _customers.Remove(searched);
            }

            _logger.LogError("No customer");
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            // _logger.LogInformation("showing list of customers");

            return _customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id);
        }
    }
}