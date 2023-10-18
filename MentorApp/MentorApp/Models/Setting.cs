using System.ComponentModel.DataAnnotations;

namespace MentorApp.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Key { get; set; }
        [StringLength(10000)]
        public string Value { get; set; }
    }
}
