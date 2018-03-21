using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public int Kundennummer { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public DateTime Erstellungsdatum { get; set; }
    }

    public class Reservation
    {
        public int Reservationsnummer { get; set; }
        [Required]
        public Car Auto { get; set; }
        public Customer Kunde { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public int wurdeZuMietVertrag { get; set; }
        public DateTime Erstellungsdatum { get; set; }
    }
}
