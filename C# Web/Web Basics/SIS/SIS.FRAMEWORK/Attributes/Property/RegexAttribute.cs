namespace SIS.FRAMEWORK.Attributes.Property
{
    using System.Text.RegularExpressions;

    public class RegexAttribute : ValidationAttributes
    {
        private readonly string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = $"^{pattern}$";
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), this.pattern);
        }
    }
}