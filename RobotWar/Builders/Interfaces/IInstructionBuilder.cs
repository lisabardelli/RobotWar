using RW.Entities;

namespace RW.Builders.Interfaces;

public interface IInstructionBuilder
{
    Instruction BuildInstruction(string instruction);
}