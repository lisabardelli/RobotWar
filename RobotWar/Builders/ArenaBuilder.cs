using RW.Builders.Interfaces;
using RW.Entities;

namespace RW.Builders;

public class ArenaBuilder : IArenaBuilder
{
    public Arena BuildArena(string topRightCorner)
    {
        return new Arena(topRightCorner);
    }
}