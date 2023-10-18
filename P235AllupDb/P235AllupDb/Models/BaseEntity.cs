﻿using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; } = "System";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [StringLength(255)]
        public string? UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        [StringLength(255)]
        public string? DeletedBy { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
