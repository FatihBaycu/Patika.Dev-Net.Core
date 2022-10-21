using FluentValidation;
using WebAPI.Operations.BookOperations.Commands.Update;

namespace WebAPI.Operations.BookOperations.Commands.Create
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(p => p.updateBookModel.Name).MinimumLength(1);
            RuleFor(p => p.updateBookModel.GenreId).GreaterThan(0);
            RuleFor(p => p.updateBookModel.Author).MinimumLength(2);
        }
    }
}
