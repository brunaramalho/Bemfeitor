﻿using MundiPagg.Benfeitor.BenfeitorApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
{
    public class SearchRequest
    {
        [Required]
        public TypeSearch TypeSearch { get; set; }

        public TypeOrder TypeOrder { get; set; }

        public string Name { get; set; }

        public byte? MininumGrade { get; set; }

        public long? AmountInCents { get; set; }

        public bool? HasBorrowed { get; set; }

        public bool? HasLended { get; set; }
    }
}