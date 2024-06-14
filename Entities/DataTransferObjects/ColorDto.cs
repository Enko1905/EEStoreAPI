using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ColorDto
    {
        public int ColorId { get; init; }
        public string ColorName { get; init; }
        public string? ColorCode { get; init; }

    }
}
