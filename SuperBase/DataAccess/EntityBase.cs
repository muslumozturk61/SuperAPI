﻿namespace SuperBase.DataAccess
{
    public abstract class EntityBase<T>
    {
        public T Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
