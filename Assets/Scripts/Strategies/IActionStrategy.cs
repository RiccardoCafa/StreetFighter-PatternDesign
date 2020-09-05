public interface IActionStrategy
{
    bool ShouldWalkLeft();
    bool ShouldWalkRight();
    bool ShouldPunch();
    bool ShouldKick();
}
