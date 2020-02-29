using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyValidators
{
    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (inputString.Length < this.MinimumLength ||
                   (this.MaximumLength > 0 &&
                    inputString.Length > this.MaximumLength))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }

    }

    public class MaxValueValidationRule : ValidationRule
    {
        private double _maxvalue = -1;
        private string _errorMessage;

        public double MaxValue
        {
            get { return _maxvalue; }
            set { _maxvalue = value; }

        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            try
            {
                double inputValue = Convert.ToDouble(value);
                if (inputValue > this.MaxValue )
                {
                    result = new ValidationResult(false, this.ErrorMessage);
                }
            } catch
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }


    }
}
