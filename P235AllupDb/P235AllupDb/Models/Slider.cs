﻿using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Models
{
    public class Slider : BaseEntity
    {
        [StringLength(255)]
        public string MainTitle { get; set; }
        [StringLength(255)]
        public string SubTitle { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(255)]
        public string Link { get; set; }
    }
}
