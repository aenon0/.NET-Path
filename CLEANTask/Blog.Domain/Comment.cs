using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Common;

namespace Blog.Domain
{
    public class Comment : BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
