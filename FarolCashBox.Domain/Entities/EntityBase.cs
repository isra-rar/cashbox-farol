using System;

namespace FarolCashBox.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? ModificationDate { get; set; }
    }
}