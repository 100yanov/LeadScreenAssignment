using LeadScreenAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileDatabase
{
    public abstract class FileContext 
    {
        private Dictionary<Type, object> sets;

        private string connectionString;

        public FileContext(string connectionString)
        {
            connectionString = connectionString;
            this.sets = new Dictionary<Type, object>();
            if (!Directory.Exists(connectionString))
            {
                Directory.CreateDirectory(connectionString);
            };
            var type = this.GetType();
            var sets = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.PropertyType.IsAssignableTo(typeof(IDbSet)));

            foreach (var set in sets)
            {
                string path = Path.Combine(connectionString, set.Name);
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "[]");
                }
                var genericSetType = set.PropertyType
                    .GetGenericArguments()
                    .First();
                var elementsString = File.ReadAllText(path);

                Type listType = typeof(List<>).MakeGenericType(genericSetType);
                var dbsetType = typeof(FileDbSet<>).MakeGenericType(genericSetType);

                var result = JsonSerializer.Deserialize(elementsString, listType);
                var dbset = Activator.CreateInstance(dbsetType, new object[] { result });

                if (!this.sets.ContainsKey(genericSetType))
                {
                    this.sets[genericSetType] = dbset;
                }
            }

        }
        public IDbSet<T> Set<T>() where T : class
        {

            if (sets.ContainsKey(typeof(T)))
            {
                var set = this.sets[typeof(T)];
                return set as IDbSet<T>;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public int Save()
        {
            int counter = 0;
            foreach (var item in this.sets)
            {
                var str = JsonSerializer.Serialize(item);
                File.WriteAllText(Path.Combine(this.connectionString, item.Value.ToString()), str);
            }
            return counter;
        }
    }

}
