using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record SizeDto
    {
        public int SizeId { get; init; }
        public string SizeName { get; init; }
    }
}
