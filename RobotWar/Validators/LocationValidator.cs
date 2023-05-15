using FluentValidation;

namespace RW.Validators;

public class LocationValidator : AbstractValidator<string>
{
    public LocationValidator()
    {
        RuleFor(x => x)
            .Must(x =>
                !string.IsNullOrEmpty(x) &&
                x.Split(' ').Length == 3)
            .WithMessage("Input must contain three elements");

        RuleFor(x => x)
            .Must(x => int.TryParse(x?.Split(' ')[0], out int result) && result > 0)
            .WithMessage("The first element of location must be an integer greater than 0.")
            .When(x=> !string.IsNullOrEmpty(x) && x.Split(' ').Length >=3);

        RuleFor(x => x)
            .Must(x => int.TryParse(x?.Split(' ')[1], out int result) && result > 0)
            .WithMessage("The second element of location must be an integer greater than 0.")
            .When(x=> !string.IsNullOrEmpty(x) && x.Split(' ').Length >=3);;
        
        RuleFor(x => x)
            .Must(x => {
                var split = x.Split(' ');
                return string.Equals(split[2], "N", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(split[2], "S", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(split[2], "E", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(split[2], "W", StringComparison.OrdinalIgnoreCase);
            })
            .WithMessage("The third element of location must be a cardinal point (N, S, E or W).")
            .When(x=> !string.IsNullOrEmpty(x) && x.Split(' ').Length >=3);;
    }
}