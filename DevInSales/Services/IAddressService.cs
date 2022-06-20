using DevInSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Services
{
    public interface IAddressService
    {
        public Task<ActionResult<IEnumerable<Address>>> listarEnderecosAsync();
        public Task<ActionResult<Address>> encontrarEnderecosAsync(int id);
    }
}
