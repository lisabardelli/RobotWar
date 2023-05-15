using FluentValidation;
using RW.Entities.Spot;
using RW.Validators;

namespace RW.Builders;

public class SpotBuilder
{
    private readonly IValidator<string> _locationValidator;

    public SpotBuilder()
    {
        _locationValidator = new LocationValidator();
    }

    public Spot BuildSpot(string location)
    {
        
        var validationResult = _locationValidator.Validate(location);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(validationResult.Errors.First().ErrorMessage);
        }
        var coordinates = ParseCoordinates(location);
        var direction = ParseCardinalPoint(location);

        return new Spot { Coordinates = coordinates, Direction = direction };
    }

    private Coordinates ParseCoordinates(string location)
    {
        var split = location.Split(' ');
        var x = int.Parse(split[0]);
        var y = int.Parse(split[1]);

        return new Coordinates(x, y);
    }

    private CardinalPoint ParseCardinalPoint(string location)
    {
        var split = location.Split(' ');
        var direction = split[2];

        return CardinalPointExtensions.FromShortString(direction);
    }
}