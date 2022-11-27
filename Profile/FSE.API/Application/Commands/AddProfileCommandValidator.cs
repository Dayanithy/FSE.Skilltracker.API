namespace FSE.API.Application.Commands
{
      public class AddProfileCommandValidator : AbstractValidator<AddProfileCommand>
    {
        public AddProfileCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("Name is required.")
               .Length(5, 30).WithMessage("Name must be min 5 and max 30 characters.");

            RuleFor(p => p.AssociateId)
               .Matches(@"(?i)^CTS[0-9]{2,27}$").WithMessage($"AssociateId must be min 5 and max 30 characters and must start with 'CTS'.");

            RuleFor(p => p.Mobile)
              .NotEmpty().WithMessage("Mobile is required.")
              .Length(10).WithMessage("Enter valid 10 digit mobile number"); 

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Enter valid email address.");

            RuleFor(p => p.Skills!.Count(s => s.IsTechnical))
                .GreaterThanOrEqualTo(3).WithMessage("Minimum 3 Technical skills are required.");

            RuleFor(p => p.Skills!.Count(s => !s.IsTechnical))
                .GreaterThanOrEqualTo(2).WithMessage("Minimum 2 Non-technical skills are required.");

            //RuleFor(p => p.Skills).Must(s => s.Where(t => t.Proficiency < 0 || t.Proficiency > 20).Count() >= 1)
            //    .WithMessage("Skill Proficiency must be between 0 - 20");
        }
    }
}
