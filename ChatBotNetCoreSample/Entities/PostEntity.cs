using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid BlogId { get; set; }
        public virtual BlogEntity Blog { get; set; }
    }
}
