using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public class DepartmentDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
