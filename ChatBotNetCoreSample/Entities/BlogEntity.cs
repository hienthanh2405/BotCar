using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Entities
{
    public class BlogEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<PostEntity> Posts { get; set; }
    }
}
