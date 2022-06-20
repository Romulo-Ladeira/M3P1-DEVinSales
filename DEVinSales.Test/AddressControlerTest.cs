using DevInSales.Context;
using DevInSales.Controllers;
using DevInSales.Models;
using DevInSales.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DEVinSales.Test
{
    public class AddressControlerTest
    {
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ListarEnderecosAsync()
        {
            var options =  new DbContextOptionsBuilder<SqlContext>();
            var _context = new SqlContext(options);
            City city = new City();
            city.Id = 1;
            city.Name = "Cidade";
             
            Address address = new Address();
            address.Id = 0;
            address.City_Id = city.Id;
            address.City = city;
            address.Street = "rua";
            address.CEP = "0001";
            address.Number = 1;

            List<Address> addresses = new List<Address>();
            addresses.Add(address);

            var ServiceMock = new Mock<IAddressService>();
            ServiceMock.Setup(x => x.listarEnderecosAsync()).ReturnsAsync(addresses);

            AddressController controller = new AddressController(_context, ServiceMock.Object);

            var result = controller.GetAddress();

            ServiceMock.Verify(x => x.listarEnderecosAsync());
            Assert.AreEqual(addresses, result.Result.Value);


        }
        [Test]
        public void encontrarEnderecossAsync()
        {
            var options = new DbContextOptionsBuilder<SqlContext>();
            var _context = new SqlContext(options);
            City city = new City();
            city.Id = 1;
            city.Name = "Cidade";

            Address address = new Address();
            address.Id = 0;
            address.City_Id = city.Id;
            address.City = city;
            address.Street = "rua";
            address.CEP = "0001";
            address.Number = 1;

            List<Address> addresses = new List<Address>();
            addresses.Add(address);

            var ServiceMock = new Mock<IAddressService>();
            ServiceMock.Setup(x => x.encontrarEnderecosAsync(address.Id))
                .ReturnsAsync(address);

            AddressController controller = new AddressController(_context, ServiceMock.Object);

            var result = controller.GetAddress(0);

            ServiceMock.Verify(x => x.encontrarEnderecosAsync(address.Id));
            Assert.AreEqual(address, result.Result.Value);


        }
    }
}