using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductCustomVariantDto
    {
        public int ProductCustomVariantId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }

    }
}
