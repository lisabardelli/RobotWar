namespace RW.Entities;

public class Instruction
{
    public Instruction(char[] navigationInput)
    {
        NavigationInput = navigationInput;
    }

    public char[] NavigationInput { get; set; }
}