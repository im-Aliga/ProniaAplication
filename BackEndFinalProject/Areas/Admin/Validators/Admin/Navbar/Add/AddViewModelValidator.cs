using BackEndFinalProject.Areas.Admin.ViewModels.Navbar;
using FluentValidation;

namespace DemoApplication.Areas.Admin.Validators.Admin.Book.Add
{
    public class AddViewModelValidator : AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {
            RuleFor(avm => avm.Title)
                .NotNull()
                .WithMessage("Title can't be empty")
                .NotEmpty()
                .WithMessage("Title can't be empty")
                .MinimumLength(1)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(20)
                .WithMessage("Maximum length should be 20");

            RuleFor(avm => avm.Url)
           .NotNull()
           .WithMessage("ToURL can't be empty")
           .NotEmpty()
           .WithMessage("ToURL can't be empty")
           .MinimumLength(10)
           .WithMessage("Minimum length should be 10")
           .MaximumLength(100)
           .WithMessage("Maximum length should be 35");
        }
    }
}
