namespace AdventOfCode
{
    public class Day1 : IPuzzle
    {
        private readonly IAdventClient _client;

        public Day1(IAdventClient client)
        {
            _client = client;
        }

        public async Task<string> ExecuteAsync()
        {
            var input = await _client.GetInputForDay(day: 1);

            var rawElfData = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

            var elfLoads = rawElfData
                .Select((data, index) => 
                    new {
                        ElfIndex = index, 
                        Sum = data
                            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Sum()
                        }
                )
                .OrderByDescending(x => x.Sum);

            return $"Top 1 Elf Is Carrying: {elfLoads.FirstOrDefault()?.Sum}, Top 3 Elves Are Carrying: {elfLoads.Take(3).Sum(x => x.Sum)}";
        }
    }
}