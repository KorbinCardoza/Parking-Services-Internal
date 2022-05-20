using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ParkingServices.Models
{
    [Table("Complaint")]
    [Index(nameof(ComplaintId), Name = "IX_Complaint")]
    public partial class Complaint
    {
        [Key]
        [Column("ComplaintID")]
        public int ComplaintId { get; set; }
        public DateTime ComplaintDateTime { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(300)]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(10)]
        public string EmailFlag { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public int ComplaintType { get; set; }
        [StringLength(50)]
        public string VehicleModel { get; set; }
        [StringLength(50)]
        public string VehicleMake { get; set; }
        [StringLength(50)]
        public string VehicleColor { get; set; }
        [StringLength(50)]
        public string VehiclePlate { get; set; }
        [StringLength(500)]
        public string VehicleLocation { get; set; }
        [StringLength(100)]
        public string CitationNumber { get; set; }
        [StringLength(50)]
        public string MeterType { get; set; }
        [Column("MeterID")]
        [StringLength(50)]
        public string MeterId { get; set; }
        [StringLength(50)]
        public string MeterStreet { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
        [StringLength(4)]
        public string PaymentLastFour { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? PaymentAmount { get; set; }
        [StringLength(3000)]
        public string ComplaintDetails { get; set; }
        [Required]
        [StringLength(50)]
        public string ComplaintStatus { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [StringLength(3000)]
        public string Response { get; set; }
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        [StringLength(10)]
        public string Zip { get; set; }
        [StringLength(50)]
        public string PermitNumber { get; set; }
        [StringLength(150)]
        public string ParkedLocation { get; set; }

        [ForeignKey(nameof(ComplaintType))]
        [InverseProperty("Complaints")]
        public virtual ComplaintType ComplaintTypeNavigation { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Complaints")]
        public virtual Employee Employee { get; set; }
    }
}
