﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class InvoiceImportDto
    {
        [Required]
        [Range(1000000000, 1500000000)]
        public int Number { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Range(0,2)]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}

