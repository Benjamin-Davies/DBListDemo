using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DBListDemo
{
    class Api
    {
        private readonly string TodosUrl = "https://php.mmc.school.nz/201COS/benjamindavies/db-list-demo-api/";

        private HttpClient http;
        private string[] todos;
        private string todo;

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
            await HandleErrors(res);
            var text = await res.Content.ReadAsStringAsync();
            todos = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        public void CreateTodo(string todo)
        {
            this.todo = todo;
            Task.Run(CreateTodoAsync).Wait();
        }

        private async Task CreateTodoAsync()
        {
            var fields = new Dictionary<string, string>
            {
                { "title", todo },
            };
            var content = new FormUrlEncodedContent(fields);
            var res = await http.PostAsync(TodosUrl, content);
            await HandleErrors(res);
        }

        private async Task HandleErrors(HttpResponseMessage res)
        {
            if (!res.IsSuccessStatusCode)
            {
                var text = await res.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Api returned {res.StatusCode}: {text}");
            }
        }
    }
}
