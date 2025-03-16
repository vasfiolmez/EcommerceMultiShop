using EcommerceMultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceMultiShop.Order.Application.Interfaces;
using EcommerceMultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values=await _addressRepository.GetByIdAsync(command.AddressId);
            values.Detail=command.Detail;
            values.District=command.District;
            values.City=command.City;
            values.UserId=command.UserId;
            await _addressRepository.UpdateAsync(values);
        }
    }
}
