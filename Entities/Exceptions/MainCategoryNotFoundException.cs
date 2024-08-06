using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MainCategoryNotFoundException : NotFoundException
    {
        public MainCategoryNotFoundException(int id) : base($"Not Found MainCategory id {id}")
        {
        }
    }
}
