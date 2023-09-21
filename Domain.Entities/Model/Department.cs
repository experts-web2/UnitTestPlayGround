﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Entities.Model
{
    public class Department : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
