using EcommerceMultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using EcommerceMultiShop.Order.Application.Interfaces;
using EcommerceMultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values=await _addressRepository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                District = x.District,
                Detail = x.Detail,
                UserId = x.UserId
            }).ToList();
        }
    }
}
