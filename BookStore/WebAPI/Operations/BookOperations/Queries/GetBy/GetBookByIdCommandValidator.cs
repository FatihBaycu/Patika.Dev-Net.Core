using FluentValidation;
using WebAPI.Operations.BookOperations.Queries.GetBy;

namespace WebAPI.Operations.BookOperations.Commands.Create
{
    public class GetBookByIdCommandValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdCommandValidator()
        {
            RuleFor(p => p.BookId).GreaterThan(0);

        }
    }
}
