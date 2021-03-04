﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebEF.Validaciones
{
    public class ValidarFechaNacimientoAttribute : ValidationAttribute
    {
        #region Metodos
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is string)
            {
                var stringValue = value as string;
                if (DateTime.TryParse(stringValue, out DateTime dateValue))
                    return dateValue < DateTime.Now;
                else
                    return false;
            }

            if (value is DateTime time)
            {
                return time < DateTime.Now;
            }
            return false;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            DateTime fechaNacimiento = (DateTime)value;

            if (fechaNacimiento < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("La fecha debe ser menor a fecha actual.");
            }
        }
        #endregion
    }
}
