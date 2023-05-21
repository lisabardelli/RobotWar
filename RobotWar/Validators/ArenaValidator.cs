using FluentValidation;

namespace RW.Validators;

public class ArenaValidator : AbstractValidator<string>
{
    public ArenaValidator()
    {
        RuleFor(input => input)
            .NotNull().WithMessage("Input cannot be null.")
            .NotEmpty().WithMessage("Input cannot be empty.")
            .Must(BeValidInteger).WithMessage("Input must be a valid integer and greater than 0.");
    }

    private bool BeValidInteger(string input)
    {
        if (int.TryParse(input, out int value))
        {
            return value > 0;
        }
        return false;
    }
}