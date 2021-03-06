﻿using CoreTax.Application.Commons;
using CoreTax.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Application.Messages
{
    public class ListarImpuestosResponse : ResponseBase
    {
        public IEnumerable<ImpuestoView> ListImpuestos { get; set; }
    }
}
