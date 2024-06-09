using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand:IRequest<bool>
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // Billing Address
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //Payment
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string Expiration { get; set; }
        public string PaymentMethod { get; set; }
    }
}
