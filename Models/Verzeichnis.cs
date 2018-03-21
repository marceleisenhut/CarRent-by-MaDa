using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Verzeichnis
    {
        List<Customer> _kunden = new List<Customer>();
        List<Car> _cars = new List<Car>();
        List<Reservation> _res = new List<Reservation>();

        public Verzeichnis()
        {
            _kunden.Add(new Customer { Kundennummer = 1, Nachname= "Alpha", Ort="Altstätten", Strasse="A", Vorname="M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            _kunden.Add(new Customer { Kundennummer = 2, Nachname = "Beta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            _kunden.Add(new Customer { Kundennummer = 3, Nachname = "Gamma", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            _kunden.Add(new Customer { Kundennummer = 4, Nachname = "Delta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            _kunden.Add(new Customer { Kundennummer = 5, Nachname = "Epsilon", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });
            _kunden.Add(new Customer { Kundennummer = 6, Nachname = "Zeta", Ort = "Altstätten", Strasse = "A", Vorname = "M", Erstellungsdatum = DateTime.Now, Email = "info@me.com" });

            Tagesgebuehr t100 = new Tagesgebuehr() {TagesgebuehrID = 1, AnsatzProTagInCHF = 100};
            Tagesgebuehr t200 = new Tagesgebuehr() {TagesgebuehrID = 2, AnsatzProTagInCHF = 200};

            Klasse k1 = new Klasse() {KlasseID = 1, Bezeichnung = "Klasse budget", Ansatz = t100};
            Klasse k2 = new Klasse() {KlasseID = 2, Bezeichnung = "Klasse komfort", Ansatz = t200};

            _cars.Add(new Car { Id = 1, Kennzeichen = "SG333838", Marke = "Opel", Modell = "Corsa", Baujahr = 2011, Klasse = k1 });
            _cars.Add(new Car { Id = 2, Kennzeichen = "SG333839", Marke = "VW", Modell = "Polo", Baujahr = 2011, Klasse = k1 });
            _cars.Add(new Car { Id = 3, Kennzeichen = "SG333840", Marke = "Audi", Modell = "S3", Baujahr = 2011, Klasse = k2 });

            _res.Add(new Reservation() { Reservationsnummer = 1, Kunde = _kunden[0], Auto = _cars[0], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            _res.Add(new Reservation() { Reservationsnummer = 2, Kunde = _kunden[1], Auto = _cars[1], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            _res.Add(new Reservation() { Reservationsnummer = 3, Kunde = _kunden[2], Auto = _cars[2], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 0} );
            _res.Add(new Reservation() { Reservationsnummer = 2, Kunde = _kunden[1], Auto = _cars[1], Beginn = DateTime.Now, Ende = DateTime.Now, wurdeZuMietVertrag = 1} );
        }

        public IEnumerable<Reservation> GetAllVertrage()
        {
            List<Reservation> ver = new List<Reservation>();

            foreach (Reservation Reservation in _res)
            {
                if (Reservation.wurdeZuMietVertrag == 1)
                {
                    ver.Add(Reservation);
                }
            }

            return ver;
        }

        public IEnumerable<Reservation> GetAllReservationen()
        {
            List<Reservation> only_res = new List<Reservation>();

            foreach (Reservation r in _res)
            {
                if (r.wurdeZuMietVertrag == 0)
                {
                    only_res.Add(r);
                }
            }

            return only_res;
        }

        public IEnumerable<Car> GetAll_cars()
        {
            return _cars;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _kunden;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _cars;
        }

        public Reservation getReservation(Reservation r)
        {
            return _res[r.Reservationsnummer-1];
        }

        public Car getCar(Car c)
        {
            return _cars[c.Id - 1];
        }

        public Customer getCustomer(Customer c)
        {
            System.Console.WriteLine("Test getCustomer: " + _kunden[c.Id - 1].Nachname);
            return _kunden[c.Id - 1];
        }

        public Customer getCustomerByID(int id)
        {
            foreach (Customer c in _kunden)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }

            return null;
        }

        public void addVertrag(Reservation v)
        {
            v.wurdeZuMietVertrag = 1;
        }

        public void addReservation(Reservation r)
        {
            _res.Add(r);
        }

        public void addCar(Car c)
        {
            _cars.Add(c);
        }

        public void addKunde(Customer e)
        {
            _kunden.Add(e);
        }

        public void updateReservation(Reservation r)
        {
            _res.Add(r);
        }

        public void updateCar(Car c)
        {
            _cars.Add(c);
        }

        public void updateKunde(Customer e)
        {
            _kunden.Add(e);
        }

        public void deleteVertrag(Reservation v)
        {
            v.wurdeZuMietVertrag = 0;
        }

        public void deleteReservation(Reservation r)
        {
            _res.Remove(r);
        }

        public void deleteCar(Car c)
        {
            _cars.Remove(c);
        }

        public void deleteKunde(Customer c)
        {
            _kunden.Remove(c);
        }

    }
}