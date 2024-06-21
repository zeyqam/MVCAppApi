﻿namespace MVCAppApi.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public bool SoftDeleted { get; set; }= false;
    }
}
