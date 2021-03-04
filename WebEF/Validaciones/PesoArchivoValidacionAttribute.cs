using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebEF.Validaciones
{
    public class PesoArchivoValidacionAttribute : ValidationAttribute
    {
        #region Campos
        private readonly int pesoMaximoEnMegaBytes;
        #endregion

        #region Constructor
        public PesoArchivoValidacionAttribute(int PesoMaximoEnMegaBytes)
        {
            pesoMaximoEnMegaBytes = PesoMaximoEnMegaBytes;
        }
        #endregion

        #region Metodos
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is IFormFile formFile))
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximoEnMegaBytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {pesoMaximoEnMegaBytes}mb");
            }

            return ValidationResult.Success;
        } 
        #endregion
    }
}
