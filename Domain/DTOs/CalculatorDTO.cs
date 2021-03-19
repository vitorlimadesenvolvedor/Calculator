using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs
{
    public class CalculatorDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Valor inicial deve ser um decimal positivo")]
        public decimal ValorInicial { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Número de meses deve ser um inteiro positivo")]
        public int Meses { get; set; }
    }
}
