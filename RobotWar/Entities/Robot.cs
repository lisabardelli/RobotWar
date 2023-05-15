using RW.Entities.Spot;

namespace RW.Entities;

public class Robot : IRobot
{
    public Spot.Spot Spot { get; set; }
    private Arena InitializedArena { get; set; } 
   
    public Robot(Arena arena, Spot.Spot spot)
    {
        InitializedArena = arena;
        Spot = spot;
    }

    
    public Spot.Spot ChangeSpot(Instruction instruction, Spot.Spot spot, Arena arena)
    {
        foreach (var navigationInput in instruction.NavigationInput)
        {
            switch (navigationInput.ToUpper())
            {
                case "M":
                    if (!TryMove(spot, arena))
                    {
                        return spot;
                    }
                    break;
                case "L":
                    spot.Direction = spot.RotateLeft();
                    break;
                case "R":
                    spot.Direction = spot.RotateRight();
                    break;
            }
        }

        ConsoleManager.Print(null, spot);
        MarkSpotAsTaken(spot, arena);

        return spot;
    }

    private static bool TryMove(Spot.Spot spot, Arena arena)
    {
        var initialCoordinates = new Coordinates(spot.Coordinates.X, spot.Coordinates.Y);
        spot.Move();
        var finalCoordinates = spot.Coordinates;

        if (!arena.IsSpotInsideArena(finalCoordinates))
        {
            UndoMove(spot, initialCoordinates);
            ConsoleManager.Print("Robot cannot move further because it will move outside the arena. \n", spot);
          
            return false;
        }
        
        if (arena.IsSpotAlreadyTaken(finalCoordinates))
        {
            UndoMove(spot, initialCoordinates);
            ConsoleManager.Print("Robot cannot move further because the next spot is taken. \n", spot);
            
            return false;
        }

        arena.SquaresTaken.Remove(initialCoordinates);
        return true;
    }

    private static void UndoMove(Spot.Spot spot, Coordinates initialCoordinates)
    {
        spot.Coordinates = initialCoordinates;
    }

    private static void MarkSpotAsTaken(Spot.Spot spot, Arena arena)
    {
        arena.SquaresTaken.Add(spot.Coordinates);
    }
}








