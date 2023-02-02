using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Twoishday.Models
{
    public class Invite
    {
        public int Id { get; set; } //primary key

        [DisplayName("Date Sent")]
        public DateTimeOffset  InviteDate { get; set; }

        [DisplayName("Join Date")]
        public DateTimeOffset JoinDate { get; set; }

        [DisplayName("Code")]
        public Guid CompanyToken { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [DisplayName("Invitor")]
        public string InvitorId { get; set; } //Id of a TDUser

        [DisplayName("Invitee")]
        public string InviteeId { get; set; } //Id of a TDUser

        [DisplayName("Invitee Email")]
        public string InviteeEmail { get; set; } 

        [DisplayName("Invitee First Name")]
        public string InviteeFirstName { get; set; } 

        [DisplayName("Invitee Last Name")]
        public string InviteeLastName { get; set; }

        public bool IsValid { get; set; }

        //navigation properties
        public virtual Company Company { get; set; }
        public virtual TDUser Invitor { get; set; }
        public virtual TDUser Invitee { get; set; }
        public virtual Project Project { get; set; }





    }
}
