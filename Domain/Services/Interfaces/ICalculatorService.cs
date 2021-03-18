﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICalculatorService
    {
        Task<decimal> GetTotalCompoundInterestGain(decimal initialValue, int months);
    }
}
