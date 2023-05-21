namespace RW.Entities;

public interface IRobot
{
    Spot Spot { get; }

    void ChangeSpot(Instruction instruction);
}