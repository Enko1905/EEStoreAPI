<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
=======
﻿using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
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
<<<<<<< HEAD
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString)
=======
        public ICollection<ShapedEntity> ShapeData(ICollection<T> entities, string fieldsString)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        {
            var requiredFields = GetRequiredProperties(fieldsString);
            return FetchData(entities, requiredFields);
        }

<<<<<<< HEAD
        public ExpandoObject ShapeData(T entity, string fileldsString)
=======
        public ShapedEntity ShapeData(T entity, string fileldsString)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
        {
            var requiredProperty  = GetRequiredProperties(fileldsString);
            return FetchDataForEntity(entity, requiredProperty);
        }
<<<<<<< HEAD
        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
=======
        private ICollection<PropertyInfo> GetRequiredProperties(string fieldsString)
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
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

<<<<<<< HEAD
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
=======
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
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
            foreach (var entity in entities) 
            {
               var shapedObject = FetchDataForEntity(entity, requiredProperty);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        } 
        
    
    }
}
