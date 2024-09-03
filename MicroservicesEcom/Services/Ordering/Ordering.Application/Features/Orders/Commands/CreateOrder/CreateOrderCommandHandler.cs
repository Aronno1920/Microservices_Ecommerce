using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        IEmailService _emailService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //var order = _mapper.Map<Order>(request);
            //bool isOrderPlaced = await _orderRepository.AddAsync(order);

            //if (isOrderPlaced)
            //{
            //    await _emailService.SendEmailAsync();
            //    return true;
            //}

         return true;
        }
    }
}
