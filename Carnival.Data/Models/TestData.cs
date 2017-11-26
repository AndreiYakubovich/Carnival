using System;
using System.ComponentModel.DataAnnotations;

namespace Carnival.Data.Models

{
    public class TestData
    {
        public TestData()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Display(Description = "Record #")]
        public string Id { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 4)]
        [Display(Description = "Username", Name = "Username", Prompt = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Description = "Text")]
        public string Text { get; set; }

        internal bool IsModelValid()
        {
            throw new NotImplementedException();
        }
    }
}
