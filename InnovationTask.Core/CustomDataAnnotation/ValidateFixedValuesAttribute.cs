using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InnovationTask.Core.CustomDataAnnotation
{
    public class ValidateFixedValuesAttribute : ValidationAttribute
    {
        string[] fixedValues;
        public ValidateFixedValuesAttribute(params string[] fixedValues)
        {
            this.fixedValues = fixedValues;

        }

        public override string FormatErrorMessage(string name)
        {
            StringBuilder Message = new StringBuilder();
            
            Message.Append("This field only allow");
            Message.Append((fixedValues.Length == 1) ? " This value(" : " these values(");
            
            foreach(string value in fixedValues)
            {
                Message.Append($"{value}, ");
            }    
            Message.Append(')');
            Message.Replace(", )", ")");
            
            return Message.ToString();
        }

        public override bool IsValid(object? value)
        {
            bool valid = false;
            if(value != null && value is string)
            {
                valid = fixedValues.Contains(((string)value).Trim());
            }
            return valid;
        }
    }
}
