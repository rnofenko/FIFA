﻿using System.ComponentModel.DataAnnotations;

namespace Fifa.Models
{
    public class Tournament : BaseEntity
    {
        [StringLength(LengthName)]
        public string Name { get; set; }
    }
}