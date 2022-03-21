using MusicTime.Data;
using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MusicTime.Service
{
  public class CustomerService
  {
    private ModelStateDictionary _modelState;
    private CustomerRepository _customerRepository;
    private MusicTimeContext _db;

    public CustomerService(ModelStateDictionary modelState, CustomerRepository repository)
    {
      _modelState = modelState;
      _customerRepository = repository;
      _db = new MusicTimeContext();
    }

    protected bool ValidateDuplicateCustomer(Customer customer)
    {
      //var nameCount = _db.Customers.Where(c => )s
      return false;
    }
  }
}
