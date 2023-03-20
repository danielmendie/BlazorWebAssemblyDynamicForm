using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DynamicForm.Pages
{
    public partial class Index
    {
        [Inject] public HttpClient Http { get; set; }

        DynamicFormModel formModel;
        bool isLoading;
        bool GenerateJsonSample;

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;

            if (GenerateJsonSample)
                Generator.GenerateSampleJson();
            else
                formModel = await Http.GetFromJsonAsync<DynamicFormModel>("sample-data/form.json");

            isLoading = false;
        }

    }
}
