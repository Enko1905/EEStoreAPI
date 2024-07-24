using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Properties { get; set; }
        public DataShaper()
        {
            Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        public ICollection<ShapedEntity> ShapeData(ICollection<T> entities, string fieldsString)
        {
            var requiredFields = GetRequiredProperties(fieldsString);
            return FetchData(entities, requiredFields);
        }

        public ShapedEntity ShapeData(T entity, string fileldsString)
        {
            var requiredProperty  = GetRequiredProperties(fileldsString);
            return FetchDataForEntity(entity, requiredProperty);
        }
        private ICollection<PropertyInfo> GetRequiredProperties(string fieldsString)
        {
            var requiredFiles = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                var fileds = fieldsString.Split(',',
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var field in fileds)
                {
                    var property = Properties.FirstOrDefault(p => p.Name.Equals(field.Trim(),
                        StringComparison.InvariantCultureIgnoreCase));
                    if (property is null)
                        continue;
                    requiredFiles.Add(property);
                }
            }
            else
            {
                requiredFiles = Properties.ToList();
            }
            return requiredFiles;
        }

        private ShapedEntity FetchDataForEntity(T entity, ICollection<PropertyInfo> requiredProperty)
        {
            var shapedObject = new ShapedEntity();
            foreach (var property in requiredProperty)
            {
                var objectPropertValue = property.GetValue(entity);
                shapedObject.Entity.TryAdd(property.Name, objectPropertValue);
            }

            var objectProperty = entity.GetType().GetProperty("Id");
            shapedObject.Id = (int)objectProperty.GetValue(entity);

            return shapedObject;
        }
        
        private ICollection<ShapedEntity> FetchData(ICollection<T> entities , ICollection<PropertyInfo> requiredProperty) 
        {
            var shapedData = new List<ShapedEntity>();
            foreach (var entity in entities) 
            {
               var shapedObject = FetchDataForEntity(entity, requiredProperty);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        } 
        
    
    }
}
