using System;

namespace DevIO.Bussines.Core.Models
{
    public abstract class Entity
    {

        protected Entity(){ Id = Guid.NewGuid(); }

        public Guid Id { get; set; }
    }
}
