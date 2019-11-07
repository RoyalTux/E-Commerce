using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PagingInfo
    {
        [Required]
        public int TotalItems { get; set; }

        [Required]
        [Range(4, 10, ErrorMessage = "Incorrect amount of elements per page")]
        public int ItemsPerPage { get; set; }

        [Required]
        [RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Invalid page number")]
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)this.TotalItems / this.ItemsPerPage);
    }
}