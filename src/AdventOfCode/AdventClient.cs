using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AdventClient : IAdventClient
    {
        private readonly HttpClient _client;

        public AdventClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://adventofcode.com");
            _client = client;
        }

        public async Task<string> GetInputForDay(int day)
        {
            var sessionCookie = Environment.GetEnvironmentVariable("SESSION_COOKIE");

            _client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");
            var response = await _client.GetAsync($"/2022/day/{day}/input");

            return await response.Content.ReadAsStringAsync();
        }
    }
}