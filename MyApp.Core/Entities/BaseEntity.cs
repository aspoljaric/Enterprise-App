using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
