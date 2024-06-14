using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductCustomAttributeDto
    {
        public int ProductCustomId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
    }
}
