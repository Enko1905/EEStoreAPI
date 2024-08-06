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
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString)
        {
            var requiredFields = GetRequiredProperties(fieldsString);
            return FetchData(entities, requiredFields);
        }

        public ExpandoObject ShapeData(T entity, string fileldsString)
        {
            var requiredProperty  = GetRequiredProperties(fileldsString);
            return FetchDataForEntity(entity, requiredProperty);
        }
        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
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

        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperty)
        {
            var shapedObject = new ExpandoObject();
            foreach (var property in requiredProperty)
            {
                var objectPropertValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertValue);
            }
            return shapedObject;
        }
        
        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities ,  IEnumerable<PropertyInfo> requiredProperty) 
        {
            var shapedData = new List<ExpandoObject>();
            foreach (var entity in entities) 
            {
               var shapedObject = FetchDataForEntity(entity, requiredProperty);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        } 
        
    
    }
}
