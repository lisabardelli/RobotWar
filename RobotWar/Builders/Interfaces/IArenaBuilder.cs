using RW.Entities;

namespace RW.Builders.Interfaces;

public interface IArenaBuilder
{
    Arena BuildArena(string topRightCorner);
}