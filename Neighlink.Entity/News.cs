using System;

namespace Neighlink.Entity
{
    public class News:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual int CondominiumId {get;set;}
    }
}