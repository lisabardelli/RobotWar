namespace RW.Entities;

public class Instruction
{
    public char[] NavigationInput { get; set; }
    
    public Instruction(char[] navigationInput)
    {
        NavigationInput = navigationInput;
    }
}