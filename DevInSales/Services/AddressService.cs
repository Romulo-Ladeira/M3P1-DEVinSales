using DevInSales.Context;
using DevInSales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Services
{

    public class AddressService : IAddressService
    {
        private readonly SqlContext _context;
        public AddressService(SqlContext context)
        {
            _context = context;
            
        }
        public async Task<ActionResult<IEnumerable<Address>>> listarEnderecosAsync()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<ActionResult<Address>> encontrarEnderecosAsync(int id)
        {
            var address = await _context.Address.FindAsync(id);
            
            return address;
        }
    }
}
