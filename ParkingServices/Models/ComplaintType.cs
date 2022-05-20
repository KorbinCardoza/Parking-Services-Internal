using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ParkingServices.Models
{
    [Table("ComplaintType")]
    public partial class ComplaintType
    {
        public ComplaintType()
        {
            Complaints = new HashSet<Complaint>();
        }

        [Key]
        [Column("ComplaintType")]
        public int ComplaintType1 { get; set; }
        [StringLength(100)]
        public string ComplaintTypeDescription { get; set; }

        [InverseProperty(nameof(Complaint.ComplaintTypeNavigation))]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
