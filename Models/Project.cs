using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace Twoishday.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTimeOffset EndDate { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        public byte[] FileDate { get; set; }

        [DisplayName("File Extension")]
        public string FileContentType { get; set; }


        [DisplayName("Archived")]
        public bool Archived { get; set; }


        //navigation properties
        public virtual Company Company { get; set; }
        public virtual ProjectPriority ProjectPriority { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual TDUser User { get; set; }
    }
}
