using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs
{
    public class CalculatorDTO : IValidatableObject
    {
        [Range(0, int.MaxValue, ErrorMessage = "Valor inicial deve ser um decimal positivo")]
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Meses < 0)
                yield return new ValidationResult("Número de meses deve ser um inteiro positivo", new[] { nameof(Meses) });

            if (ValorInicial < 0)
                yield return new ValidationResult("Valor inicial deve ser um decimal positivo", new[] { nameof(ValorInicial) });
        }
    }
}
