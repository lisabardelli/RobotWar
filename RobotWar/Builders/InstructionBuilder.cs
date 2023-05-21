using FluentValidation;
using RW.Builders.Interfaces;
using RW.Entities;
using RW.Validators;

namespace RW.Builders;

public class InstructionBuilder : IInstructionBuilder
{
    private readonly IValidator<Instruction> _instructionValidator;

    public InstructionBuilder()
    {
        _instructionValidator = new InstructionValidator();
    }

    public Instruction BuildInstruction(string instruction)
    {
        var navigationInstruction = new Instruction
        (
            instruction.Select(char.ToUpper).ToArray()
        );

        var validationResult = _instructionValidator.Validate(navigationInstruction);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(validationResult.Errors.First().ErrorMessage);
        }

        return navigationInstruction;
    }
}