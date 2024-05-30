using BE_ABC.Models.CommonModels;
using FluentValidation;

namespace BE_ABC.Middlewares
{
    public class PaginationValidator : AbstractValidator<Pagination>
    {
        public PaginationValidator()
        {
            RuleFor(p => p.page).GreaterThanOrEqualTo(1).WithMessage("Page must be greater than or equal to 1.");
            RuleFor(p => p.limit).GreaterThanOrEqualTo(1).WithMessage("Limit must be greater than or equal to 1.");
        }
    }
}
