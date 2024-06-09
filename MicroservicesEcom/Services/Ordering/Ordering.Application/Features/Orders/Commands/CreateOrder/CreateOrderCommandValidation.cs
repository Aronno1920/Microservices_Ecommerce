using FluentValidation;


namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Please enter user name.")
                .EmailAddress().WithMessage("User name should be valid email.");

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please enter first name.");

            RuleFor(c => c.TotalPrice)
                .GreaterThan(0).WithMessage("Total amount should be greater then zero.");

            RuleFor(c => c.EmailAddress)
                .NotEmpty().WithMessage("Please enter email.")
                .EmailAddress().WithMessage("Email should be valid email.");

        }
    }
}
