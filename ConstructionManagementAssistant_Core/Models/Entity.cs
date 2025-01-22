using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant_Core.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }

        protected Entity(T id)
        {
            Id = id;
        }
    }
}
