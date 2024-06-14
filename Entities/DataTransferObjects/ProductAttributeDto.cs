using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductAttributeDto
    {
        public int ProductAttributeId { get; init; }
        public int ProductId { get; init; }
        public string Type { get; init; }
        public string Value { get; init; }
    }
}
