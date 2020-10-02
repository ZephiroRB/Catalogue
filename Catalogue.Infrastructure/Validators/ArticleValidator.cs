using Catalogue.Core.DTOs;
using FluentValidation;


namespace Catalogue.Infrastructure.Validators
{
    public class ArticleValidator: AbstractValidator<ArticleDTO>
    {
        public ArticleValidator()
        {
            RuleFor(article => article.UserId)
                    .NotNull()
                    .NotEmpty();

            RuleFor(article => article.Title)
               .NotNull();

            RuleFor(article => article.Description)
               .NotNull();
        }
       
    }
}
