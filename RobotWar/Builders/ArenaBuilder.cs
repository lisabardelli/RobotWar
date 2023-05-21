using FluentValidation;
using RW.Builders.Interfaces;
using RW.Entities;
using RW.Validators;

namespace RW.Builders;

public class ArenaBuilder : IArenaBuilder
{
    private readonly ArenaValidator _arenaValidator;

    public ArenaBuilder()
    {
        _arenaValidator = new ArenaValidator();
    }
    public Arena BuildArena(string topRightCorner)
    {

        var validationResult = _arenaValidator.Validate(topRightCorner);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(validationResult.Errors.First().ErrorMessage);
        }

        return new Arena(int.Parse(topRightCorner));
    }
}