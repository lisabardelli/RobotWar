using FluentValidation;
using RW.Entities;

namespace RW.Validators;

public class InstructionValidator : AbstractValidator<Instruction>
{
    public InstructionValidator()
    {
        var conditions = new List<string>() { "L", "M", "R" };

        RuleForEach(x => x.NavigationInput)
            .Must(x => conditions.Any(y => y.Equals(x, StringComparison.OrdinalIgnoreCase)))
            .WithMessage("Please only use: " + string.Join(",", conditions));
    }
}