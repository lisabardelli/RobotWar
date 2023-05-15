namespace RW.Entities;

public interface IRobot
{
    Spot.Spot Spot { get; set; }
    Spot.Spot ChangeSpot(Instruction direction, Spot.Spot spot, Arena arena);

}