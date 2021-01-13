using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CoreEntity
{
    public interface IEntity<T>//dışarıdan bir tip alacak.
    {
        T ID { get; set; }
    }
}
