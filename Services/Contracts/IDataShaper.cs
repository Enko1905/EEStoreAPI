<<<<<<< HEAD
﻿using System;
=======
﻿using Entities.Models;
using System;
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDataShaper <T> 
    {
<<<<<<< HEAD
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);

        ExpandoObject ShapeData(T entity, string fileldsString);
=======
        ICollection<ShapedEntity> ShapeData(ICollection<T> entities, string fieldsString);

        ShapedEntity ShapeData(T entity, string fileldsString);
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c

    }

}
