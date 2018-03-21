using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;

namespace CarRent.Models
{
    public class NHibernateDB
    {
        private List<Customer> _kunden = new List<Customer>();
        private List<Car> _cars = new List<Car>();
        private List<Reservation> _reservations = new List<Reservation>();
        private readonly ISessionFactory _sefact;

        public NHibernateDB()
        {
            string connectionString = "Data Source = localhost;" + "Initial Catalog=CarRent;" +
                                      "Integrated Security = True" + "Password=root;" + "Connect Timeout = 15;" +
                                      "Encrypt = False;" + "TrustServerCertificate = False;" +
                                      "ApplicationIntent = ReadWrite;" + "MultiSubnetFailover = False;";

            var cfg = new Configuration();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MySQLDialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            _sefact = cfg.BuildSessionFactory();

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    //perform database logic 
                    tx.Commit();
                }
            }
        }

        public void getKundenDataFromDb()
        {
            _kunden.Clear();

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var customers = session.CreateCriteria<Customer>().List<Customer>();

                    foreach (var cust in customers)
                    {
                        _kunden.Add(cust);
                        // kunden.Add(new Customer() {Id = cust.Id, Nachname = cust.Nachname, Vorname = cust.Vorname, Kundennummer = cust.Kundennummer, Strasse = cust.Strasse, Telefonnummer = cust.Telefonnummer, Erstellungsdatum = cust.Erstellungsdatum, Email = cust.Email, Ort = cust.Ort});
                    }

                    tx.Commit();
                }
            }
        }

        public void getCarsDataFromDb()
        {
            _cars.Clear();

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var cars = session.CreateCriteria<Car>().List<Car>();

                    foreach (var car in cars)
                    {
                        _cars.Add(car);
                    }

                    tx.Commit();
                }
            }
        }

        public void GetReservationsDataFromDb()
        {
            _reservations.Clear();

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var reservations = session.CreateCriteria<Reservation>().List<Reservation>();

                    foreach (var res in reservations)
                    {
                        _reservations.Add(res);
                    }

                    tx.Commit();
                }
            }
        }

        public List<Customer> getAllCustomers()
        {
            getKundenDataFromDb();
            return _kunden;
        }

        public List<Car> getAllCars()
        {
            getCarsDataFromDb();
            return _cars;
        }

        public List<Reservation> GetAllReservations()
        {
            GetReservationsDataFromDb();
            return _reservations;
        }

        public List<Reservation> GetAllVertrage()
        {
            GetReservationsDataFromDb();
            List<Reservation> ver = new List<Reservation>();

            foreach (Reservation res in _reservations)
            {
                if (res.wurdeZuMietVertrag == 1)
                {
                    ver.Add(res);
                }
            }

            return ver;
        }

        public Customer getCustomer(int Kundennummer)
        {
            return _kunden[Kundennummer - 1];
        }

        public Car getCar(int Id)
        {
            return _cars[Id - 1];
        }

        public Reservation GetReservation(int Id)
        {
            return _reservations[Id - 1];
        }

        public void addCustomer(Customer c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(c);
                    tx.Commit();
                }
            }
        }

        public void addCar(Car c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(c);
                    tx.Commit();
                }
            }
        }

        public void addReservation(Reservation r)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(r);
                    tx.Commit();
                }
            }
        }

        public void addVertrag(Reservation r)
        {
            r.wurdeZuMietVertrag = 1;
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(r);
                    tx.Commit();
                }
            }
        }

        public void updateCustomer(Customer c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var cust = session.Get<Customer>(c.Id);

                    cust = c;
                    session.Update(cust);

                    tx.Commit();
                }
            }
        }

        public void updateCar(Car c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var car = session.Get<Car>(c.Id);

                    car = c;
                    session.Update(car);

                    tx.Commit();
                }
            }
        }

        public void updateReservation(Reservation r)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var res = session.Get<Reservation>(r.Reservationsnummer);

                    res = r;
                    session.Update(res);

                    tx.Commit();
                }
            }
        }

        public void deleteCustomer(Customer c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var cust = session.Get<Customer>(c.Id);
                    session.Delete(cust);

                    tx.Commit();
                }
            }
        }

        public void deleteCar(Car c)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var car = session.Get<Car>(c.Id);
                    session.Delete(car);

                    tx.Commit();
                }
            }
        }

        public void deleteReservation(Reservation r)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var res = session.Get<Reservation>(r.Reservationsnummer);
                    session.Delete(res);

                    tx.Commit();
                }
            }
        }

        public void deleteVertrag(Reservation r)
        {
            r.wurdeZuMietVertrag = 0;
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var res = session.Get<Reservation>(r.Reservationsnummer);
                    session.Delete(res);

                    tx.Commit();
                }
            }
        }
    }
}