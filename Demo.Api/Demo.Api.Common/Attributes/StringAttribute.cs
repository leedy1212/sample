namespace Demo.Api.Common.Attributes
{
    public class StringAttribute : System.Attribute
    {
        public StringAttribute(string value)
        {
            Value = value;
        }
        
        public string Value { get; private set; }
    }
}