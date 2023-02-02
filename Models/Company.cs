using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Twoishday.Models
{
    public class Company
    {
        public int Id { get; set; } //primary key

        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Company Description")]
        public string Description { get; set; }
        //Navigation properties
        public virtual ICollection<TDUser> Members { get; set; } = new HashSet<TDUser>();
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        //create relationship to invites
    }
}