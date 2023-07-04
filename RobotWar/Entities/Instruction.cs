namespace RW.Entities;

public class Instruction
{
    public char[] NavigationInput { get; }
    
    public Instruction(char[] navigationInput)
    {
        NavigationInput = navigationInput;
    }
}