using EcommerceMultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
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
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _addressRepository.GetByIdAsync(query.Id);

            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                District = values.District,
                Detail = values.Detail,
                UserId = values.UserId,
            };
        }
    }
}
