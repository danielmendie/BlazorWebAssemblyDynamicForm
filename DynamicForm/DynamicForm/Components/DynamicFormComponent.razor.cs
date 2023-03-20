using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicForm.Components
{
    public partial class DynamicFormComponent
    {
        [Parameter] public DynamicFormModel DynamicData { get; set; }
        Dictionary<string, int> ElementPosition = new();
        string[] errors = Array.Empty<string>();
        private MudForm form;
        bool success;


        /// <summary>
        /// Get the positions of each element and store it in a dictionary
        /// </summary>
        protected override void OnParametersSet()
        {
            foreach (var item in DynamicData?.TextElements)
                ElementPosition.Add($"TextElements_{item.Name}", item.Position);

            foreach (var item in DynamicData?.NumberElements)
                ElementPosition.Add($"NumberElements_{item.Name}", item.Position);

            foreach (var item in DynamicData?.DateElements)
                ElementPosition.Add($"DateElements_{item.Name}", item.Position);

        }

        void Submit()
        {
            /* 
             * form submission task
             */
        }
    }
}
