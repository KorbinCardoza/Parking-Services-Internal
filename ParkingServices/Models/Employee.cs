using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ParkingServices.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Complaints = new HashSet<Complaint>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("EMail")]
        [StringLength(300)]
        public string Email { get; set; }
        public int? Active { get; set; }

        [InverseProperty(nameof(Complaint.Employee))]
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
