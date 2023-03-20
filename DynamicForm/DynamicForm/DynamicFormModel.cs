namespace DynamicForm
{
    /// <summary>
    /// From element list
    /// </summary>
    public class DynamicFormModel
    {
        /// <summary>
        /// for elements that accept string datatypes
        /// </summary>
        public List<Element<string>> TextElements { get; set; }
        /// <summary>
        /// for elements that accept numeric datatypes
        /// </summary>
        public List<Element<double>> NumberElements { get; set; }
        /// <summary>
        /// for elements that accepts datatime datatypes
        /// </summary>
        public List<Element<DateTime?>> DateElements { get; set; }

        /* You can create elements that accepts
         * other datatypes e.g for a boolean element
         *  public List<Element<bool>> BooleanElements { get; set; }
         */
    }


    /// <summary>
    /// Form element metadata
    /// </summary>
    /// <typeparam name="T">Binds the Value property to a strong datatype<T> </typeparam>
    public class Element<T>
    {
        public virtual ElementType ElementType { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
        public int Position { get; set; }
        public string PlaceHolder { get; set; }
        public string TextOnLabel { get; set; }
        public bool IsRequired { get; set; }
        public string? ErrorOnRequired { get; set; }
        public Dictionary<string, string>? Options { get; set; }
    }


    /// <summary>
    /// Enum used to determine what kind of control to render
    /// </summary>
    public enum ElementType
    {
        Text,
        Multiline,
        Duration,
        Date,
        DropDown,
        RadioButton,
        Slider
    }

}
