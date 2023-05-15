namespace RW.Entities;

public class Instruction
{
    public Instruction(string[] navigationInput)
    {
        NavigationInput = navigationInput;
    }

    public string[] NavigationInput { get; set; }
}