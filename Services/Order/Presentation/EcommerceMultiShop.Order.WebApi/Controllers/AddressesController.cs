using EcommerceMultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceMultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using EcommerceMultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressByIdQueryHandler _addressByIdQueryHandler;
        private readonly GetAddressQueryHandler _addressQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressByIdQueryHandler addressByIdQueryHandler, GetAddressQueryHandler addressQueryHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, CreateAddressCommandHandler createAddressCommandHandler)
        {
            _addressByIdQueryHandler = addressByIdQueryHandler;
            _addressQueryHandler = addressQueryHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values =await _addressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values =await _addressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres bilgisi silindi.");
        }
    }
}
