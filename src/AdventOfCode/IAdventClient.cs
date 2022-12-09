namespace AdventOfCode
{
    public interface IAdventClient
    {
        Task<string> GetInputForDay(int day);
    }
}