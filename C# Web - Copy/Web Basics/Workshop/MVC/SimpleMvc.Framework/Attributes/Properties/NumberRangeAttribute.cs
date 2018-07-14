namespace SimpleMvc.Framework.Attributes.Properties
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NumberRangeAttribute : PropertyAttribute
    {
        private readonly double minValue;

        private readonly double maxValue;

        public NumberRangeAttribute(double minValue, double maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return this.minValue <= (double)value && (double)value <= this.maxValue;
        }
    }
}