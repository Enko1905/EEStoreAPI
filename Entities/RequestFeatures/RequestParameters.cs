using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 30;
        public int PageNumber { get; set; }

        private int _pageSize = 24;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }

        public String? OrderBy { get; set; }

<<<<<<< HEAD
        public String? Fields {  get; set; }
=======
        public String? Fields { get; set; }
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c

    }
}
