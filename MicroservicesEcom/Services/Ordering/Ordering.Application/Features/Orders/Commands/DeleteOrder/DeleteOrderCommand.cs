using MediatR;


namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
