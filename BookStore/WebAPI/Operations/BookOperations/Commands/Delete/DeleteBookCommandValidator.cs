using FluentValidation;
using WebAPI.Operations.BookOperations.Commands.Delete;
using WebAPI.Operations.BookOperations.Commands.Update;

namespace WebAPI.Operations.BookOperations.Commands.Create
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(p => p.deleteBookModel.Id).GreaterThan(0);
        }
    }
}
