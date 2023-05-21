using FluentValidation;
using RW.Entities;

namespace RW.Validators;

public class InstructionValidator : AbstractValidator<Instruction>
{
    public InstructionValidator()
    {
        var validInstructions = new HashSet<char>(new[] { 'L', 'M', 'R' }, CharComparer.IgnoreCase);

        RuleFor(x => x.NavigationInput)
            .NotEmpty()
            .WithMessage("Navigation input cannot be empty")
            .Must(input => input.All(c => validInstructions.Contains(c)))
            .WithMessage($"Please only use: {string.Join(", ", validInstructions)}");
    }
    public class CharComparer : EqualityComparer<char>
    {
        public static CharComparer IgnoreCase { get; } = new CharComparer();

        public override bool Equals(char x, char y)
        {
            return char.ToUpperInvariant(x) == char.ToUpperInvariant(y);
        }

        public override int GetHashCode(char obj)
        {
            return char.ToUpperInvariant(obj).GetHashCode();
        }
    }
}