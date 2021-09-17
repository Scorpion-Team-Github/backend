using System;

namespace Neighlink.Entity
{
    public class BaseEntity
    {
        public DateTime? CreatedAt {get;set;}
        public DateTime? DeletedAt {get;set;}

        public int Id {get;set;}
        public bool Status {get;set;}
        public DateTime? UpdatedAt {get;set;}
    }
}