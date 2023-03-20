using Newtonsoft.Json;

namespace DynamicForm
{
    public class Generator
    {

        #region JsonSampleGenerator
        /// <summary>
        /// Genarates a sample json data to the browsers output console
        /// copy the output data and update the form.json file in the wwwroot.sample-data folder
        /// </summary>
        public static void GenerateSampleJson()
        {
            var form = new DynamicFormModel
            {
                TextElements = new List<Element<string>>
                {
                    new Element<string>
                    {
                        Name = "txtName",  TextOnLabel = "Your Full Name", PlaceHolder="Enter your full name", IsRequired=true, ErrorOnRequired = "Full name is required", ElementType = ElementType.Text, Value = "", Position =1
                    },
                    new Element<string>
                    {
                        Name = "radGender", TextOnLabel = "Gender",IsRequired=false, ElementType = ElementType.RadioButton, Value = "",
                        Options = new Dictionary<string, string> { { "M", "Male" }, {"F", "Female"} }, Position =4
                    }
                },
                NumberElements = new List<Element<double>>
                {
                    new Element<double>
                    {
                        Name = "txtAge",  TextOnLabel = "Age in Numbers", PlaceHolder="Enter your age number",IsRequired=true, ErrorOnRequired = "Age is required", ElementType = ElementType.Duration, Value = 18, Position = 3
                    }
                },
                DateElements = new List<Element<DateTime?>>
                {
                    new Element<DateTime?>
                    {
                        Name = "DateofBirth", TextOnLabel = "Date of Birth", IsRequired = true, ElementType = ElementType.Date, ErrorOnRequired= "Your date of birth is required", PlaceHolder = "your date of birth", Position = 2
                    }
                }
            };

            var json = JsonConvert.SerializeObject(form);
            Console.WriteLine(json);
        }

        #endregion






        //protected override void OnParametersSet()
        //{
        //    var formElements = DynamicData.Elements;
        //    if (formElements != null)
        //    {
        //        string[] fields = Array.Empty<string>(); Type[] dataTypes = Array.Empty<Type>();
        //        foreach (var element in formElements)
        //        {
        //            Type elementDt = element.Value == nameof(Boolean) ? typeof(bool) : element.Value == nameof(Double) ? typeof(double) : typeof(string);
        //            fields = fields.Append(element.Name).ToArray();
        //            dataTypes = dataTypes.Append(elementDt).ToArray();
        //        }

        //        GenerateModel(fields, dataTypes);
        //    }
        //}

        //void GenerateModel(string[] fields, Type[] dataTypes)
        //{

        //    DynamicClassBuilder classBuilder = new("FormModel");
        //    var myclass = classBuilder.CreateObject(fields, dataTypes);
        //    FormModel = myclass.GetType();

        //    foreach (PropertyInfo PI in FormModel.GetProperties())
        //    {
        //        Console.WriteLine(PI.Name);
        //    }
        //}


        //public RenderFragment CreateComponent(PropertyInfo property) => builder =>
        //{
        //    Type T = property.GetType();

        //    var propInfoValue = FormModel.GetProperty(property.Name);
        //    // Create an expression to set the ValueExpression-attribute.
        //    var constant = System.Linq.Expressions.Expression.Constant(FormModel);
        //    var exp = System.Linq.Expressions.MemberExpression.Property(constant, property.Name);

        //    builder.OpenComponent(0, typeof(MudTextField<string>));
        //    builder.AddAttribute(2, "Label", "Custom Name");
        //    builder.AddAttribute(3, "Required", true);
        //    builder.AddAttribute(4, "RequiredError", "Provide the missing field");

        //    var defaultValue = propInfoValue.GetValue(FormModel);
        //    builder.AddAttribute(1, "Value", defaultValue);

        //    builder.CloseComponent();


        //builder.AddAttribute(5, "ValueChanged", RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.EventCallback.Factory.CreateInferred(this, __value => propInfoValue.SetValue( , __value), (string)propInfoValue.GetValue(DataContext)))));
        //builder.AddAttribute(6, "ValueExpression", System.Linq.Expressions.Expression.Lambda<Func<string>>(exp));




        //if (property.GetCustomAttributes(typeof(DataTypeAttribute), false).Length != 0)
        //    {
        //        var attrList = (DataTypeAttribute)prp.GetCustomAttributes(typeof(DataTypeAttribute), false).First();
        //        var displayLabel = (DisplayAttribute)prp.GetCustomAttributes(typeof(DisplayAttribute), false).First();
        //        // Get the initial property value.
        //        var propInfoValue = FormModel.GetProperty(prp.Name);
        //        // Create an expression to set the ValueExpression-attribute.
        //        var constant = System.Linq.Expressions.Expression.Constant(FormModel);
        //        var exp = System.Linq.Expressions.MemberExpression.Property(constant, prp.Name);
        //        switch (attrList.DataType)
        //        {
        //            case DataType.Text:
        //            case DataType.EmailAddress:
        //            case DataType.PhoneNumber:
        //            case DataType.MultilineText:
        //                {
        //                    builder.OpenComponent(0, typeof(SfTextBox));
        //                    // Create the handler for ValueChanged.
        //                    builder.AddAttribute(3, "ValueChanged", RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.EventCallback.Factory.CreateInferred(this, __value => propInfoValue.SetValue(DataContext, __value), (string)propInfoValue.GetValue(DataContext)))));
        //                    builder.AddAttribute(4, "ValueExpression", System.Linq.Expressions.Expression.Lambda<Func<string>>(exp));
        //                    if (attrList.DataType == DataType.MultilineText)
        //                        builder.AddAttribute(5, "Multiline", true);
        //                    break;
        //                }
        //            case DataType.Date:
        //                builder.OpenComponent(0, typeof(SfDatePicker<DateTime?>));
        //                builder.AddAttribute(3, "ValueChanged", RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<DateTime?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<DateTime?>(this, Microsoft.AspNetCore.Components.EventCallback.Factory.CreateInferred(this, __value => propInfoValue.SetValue(DataContext, __value), (DateTime?)propInfoValue.GetValue(DataContext)))));
        //                builder.AddAttribute(4, "ValueExpression", System.Linq.Expressions.Expression.Lambda<Func<DateTime?>>(exp));
        //                break;
        //            case DataType.Duration:
        //                builder.OpenComponent(0, typeof(SfNumericTextBox<decimal?>));
        //                builder.AddAttribute(3, "ValueChanged", RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<decimal?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<decimal?>(this, Microsoft.AspNetCore.Components.EventCallback.Factory.CreateInferred(this, __value => propInfoValue.SetValue(DataContext, __value), (decimal?)propInfoValue.GetValue(DataContext)))));
        //                builder.AddAttribute(4, "ValueExpression", System.Linq.Expressions.Expression.Lambda<Func<decimal?>>(exp));
        //                break;
        //            case DataType.Custom:
        //                if (attrList.CustomDataType == "DropdownList")
        //                {
        //                    builder.OpenComponent(0, typeof(Syncfusion.Blazor.DropDowns.SfDropDownList<string, Countries>));
        //                    builder.AddAttribute(1, "DataSource", countries.GetCountries());
        //                    builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((builder2) =>
        //                    {
        //                        builder2.AddMarkupContent(5, "\r\n    ");
        //                        builder2.OpenComponent<Syncfusion.Blazor.DropDowns.DropDownListFieldSettings>
        //                      (6);

        //                        builder2.AddAttribute(7, "Value", "Code");
        //                        builder2.AddAttribute(8, "Text", "Name");
        //                        builder2.CloseComponent();
        //                        builder2.AddMarkupContent(9, "\r\n");
        //                    }));

        //                }
        //                else if (attrList.CustomDataType == "ComboBox")
        //                {
        //                    builder.OpenComponent(0, typeof(Syncfusion.Blazor.DropDowns.SfComboBox<string, Cities>));
        //                    builder.AddAttribute(1, "DataSource", cities.GetCities());
        //                    builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((builder2) =>
        //                    {
        //                        builder2.AddMarkupContent(5, "\r\n    ");
        //                        builder2.OpenComponent<Syncfusion.Blazor.DropDowns.ComboBoxFieldSettings>
        //                      (6);

        //                        builder2.AddAttribute(7, "Value", "Code");
        //                        builder2.AddAttribute(8, "Text", "Name");
        //                        builder2.CloseComponent();
        //                        builder2.AddMarkupContent(9, "\r\n");
        //                    }));
        //                }
        //                builder.AddAttribute(3, "ValueChanged", RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.EventCallback.Factory.CreateInferred(this, __value => propInfoValue.SetValue(DataContext, __value), (string)propInfoValue.GetValue(DataContext)))));
        //                builder.AddAttribute(4, "ValueExpression", System.Linq.Expressions.Expression.Lambda<Func<string>>(exp));
        //                break;
        //            default:
        //                break;
        //        }

        //        var defaultValue = propInfoValue.GetValue(employeeDetails);
        //        builder.AddAttribute(1, "Value", defaultValue);
        //        builder.AddAttribute(6, "PlaceHolder", displayLabel.Name);
        //        builder.AddAttribute(6, "FloatLabelType", FloatLabelType.Auto);

        //        builder.CloseComponent();
        //    }

        // };
    }
}
