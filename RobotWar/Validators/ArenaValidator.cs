using FluentValidation;

namespace RW.Validators;

public class ArenaValidator : AbstractValidator<string>
{
    public ArenaValidator()
    {
        RuleFor(x => x)
            .Must(x =>
                !string.IsNullOrEmpty(x) &&
                x.Split(' ').Length == 2)
            .WithMessage("Input must contain two elements.");

        RuleFor(x => x)
            .Must(x => int.TryParse(x?.Split(' ')[0], out int result) && result > 0)
            .WithMessage("The right coordinate of the top corner of the Arena must be an integer greater than 0.")
            .When(x => !string.IsNullOrEmpty(x) && x.Split(' ').Length >= 2);

        RuleFor(x => x)
            .Must(x => int.TryParse(x?.Split(' ')[1], out int result) && result > 0)
            .WithMessage("The left coordinate of the top corner of the Arena must be an integer greater than 0.")
            .When(x => !string.IsNullOrEmpty(x) && x.Split(' ').Length >= 2);
    }
}