using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDataShaper <T> 
    {
        ICollection<ShapedEntity> ShapeData(ICollection<T> entities, string fieldsString);

        ShapedEntity ShapeData(T entity, string fileldsString);

    }

}
