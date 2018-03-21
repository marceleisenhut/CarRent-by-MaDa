using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Verzeichnis
    {
        List<Customer> custs = new List<Customer>();
        List<Car> cars = new List<Car>();
        List<Reservation> res = new List<Reservation>();

        public Verzeichnis()
        {
            custs.Add(new Customer { Kundennummer = 1, Nachname= "Alpha", Ort="Altstätten", Strasse="A", Vorname="M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            custs.Add(new Customer { Kundennummer = 2, Nachname = "Beta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            custs.Add(new Customer { Kundennummer = 3, Nachname = "Gamma", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            custs.Add(new Customer { Kundennummer = 4, Nachname = "Delta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            custs.Add(new Customer { Kundennummer = 5, Nachname = "Epsilon", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            custs.Add(new Customer { Kundennummer = 6, Nachname = "Zeta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });

            Tagesgebuehr t100 = new Tagesgebuehr() {TagesgebuehrID = 1, AnsatzProTagInCHF = 100};
            Tagesgebuehr t200 = new Tagesgebuehr() {TagesgebuehrID = 2, AnsatzProTagInCHF = 200};

            Klasse k1 = new Klasse() {KlasseID = 1, Bezeichnung = "Klasse budget", Ansatz = t100};
            Klasse k2 = new Klasse() {KlasseID = 2, Bezeichnung = "Klasse komfort", Ansatz = t200};

            cars.Add(new Car { Id = 1, Kennzeichen = "SG333838", Marke = "Opel", Modell = "Corsa", Baujahr = 2011, Klasse = k1 });
            cars.Add(new Car { Id = 2, Kennzeichen = "SG333839", Marke = "VW", Modell = "Polo", Baujahr = 2011, Klasse = k1 });
            cars.Add(new Car { Id = 3, Kennzeichen = "SG333840", Marke = "Audi", Modell = "S3", Baujahr = 2011, Klasse = k2 });

            res.Add(new Reservation() { Reservationsnummer = 1, Kunde = custs[0], Auto = cars[0], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            res.Add(new Reservation() { Reservationsnummer = 2, Kunde = custs[1], Auto = cars[1], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            res.Add(new Reservation() { Reservationsnummer = 3, Kunde = custs[2], Auto = cars[2], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            res.Add(new Reservation() { Reservationsnummer = 2, Kunde = custs[1], Auto = cars[1], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 1} );
        }

        public IEnumerable<Reservation> GetAllVertrage()
        {
            List<Reservation> ver = new List<Reservation>();

            foreach (Reservation reservation in res)
            {
                if (reservation.wurdeZuMietVertrag == 1)
                {
                    ver.Add(reservation);
                }
            }

            return ver;
        }

        public IEnumerable<Reservation> GetAllReservationen()
        {
            List<Reservation> onlyRes = new List<Reservation>();

            foreach (Reservation r in res)
            {
                if (r.wurdeZuMietVertrag == 0)
                {
                    onlyRes.Add(r);
                }
            }

            return onlyRes;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return custs;
        }

        public Reservation getReservation(int Reservationsnummer)
        {
            return res[0];
        }

        public Car getCar(String Kennzeichen)
        {
            return cars[0];
        }

        public Customer getCustomer(int Kundennummer)
        {
            System.Console.WriteLine("Test getCustomer: " + custs[Kundennummer - 1].Nachname);
            return custs[Kundennummer - 1];
        }

        public void addVertrag(Reservation v)
        {
            v.wurdeZuMietVertrag = 1;
        }

        public void addReservation(Reservation r)
        {
            res.Add(r);
        }

        public void addCar(Car c)
        {
            cars.Add(c);
        }

        public void addKunde(Customer e)
        {
            custs.Add(e);
        }

        public void updateReservation(Reservation r)
        {
            res.Add(r);
        }

        public void updateCar(Car c)
        {
            cars.Add(c);
        }

        public void updateKunde(Customer e)
        {
            custs.Add(e);
        }

        public void deleteReservation(int Reservationsnummer)
        {

        }

        public void deleteCar(String Kennzeichen)
        {

        }

        public void deleteKunde(int Kundennummer)
        {
            
        }

    }
}
