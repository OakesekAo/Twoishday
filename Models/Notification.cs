﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Twoishday.Models
{
    public class Notification
    {
        public int Id { get; set; } //primary key

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [Required]
        [DisplayName("Recipient")]
        public string RecipientId { get; set; }

        [Required]
        [DisplayName("Sender")]
        public string SenderId { get; set; }

        [DisplayName("Has been viewd")]
        public bool Viewed { get; set; }


        //navigation properties
        public virtual Ticket Ticket { get; set; }
        public virtual TDUser Recipient { get; set; }
        public virtual TDUser Sender { get; set; }




    }
}
