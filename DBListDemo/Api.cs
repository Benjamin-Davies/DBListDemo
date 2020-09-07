using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DBListDemo
{
    class Api
    {
        private readonly string TodosUrl = "https://php.mmc.school.nz/201COS/benjamindavies/db-list-demo-api";

        private HttpClient http;
        private string[] todos;

        public Api()
        {
            http = new HttpClient();
        }

        public string[] GetTodos()
        {
            Task.Run(GetTodosAsync).Wait();
            return todos;
        }

        private async Task GetTodosAsync()
        {
            var res = await http.GetAsync(TodosUrl);
            var text = await res.Content.ReadAsStringAsync();
            todos = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
