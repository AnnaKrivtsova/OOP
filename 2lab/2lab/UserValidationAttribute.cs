using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2lab
{
    class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Address address = value as Address;
            var index = address.Index.ToString();
            if (!index.StartsWith("2") && index.Length != 6)
            {
                this.ErrorMessage = "Индекс должен начинаться с 2 и состоять из 6 чисел";
                return false;
            }
            return true;
        }
    }
}
