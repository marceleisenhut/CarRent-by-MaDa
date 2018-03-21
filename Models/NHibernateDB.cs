using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CarRent.Models
{
    public class NHibernateDB
    {
        List<Customer> kunden = new List<Customer>();

        public NHibernateDB()
        {

            string connectionString = "Data Source = localhost;" + "Initial Catalog=CarRent;" + "Integrated Security = True" + "Password=root;" + "Connect Timeout = 15;" + "Encrypt = False;" + "TrustServerCertificate = False;" + "ApplicationIntent = ReadWrite;" + "MultiSubnetFailover = False;";

            var cfg = new Configuration();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MySQLDialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    //perform database logic 
                    tx.Commit();
                }

                Console.ReadLine();
            }
        }

        public void getDataFromDB()
        {
            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    var customers = session.CreateCriteria<Customer>().List<Customer>();

                    foreach (var cust in customers)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}",
                            cust.ID, cust.Nachname, cust.Vorname);
                    }

                    tx.Commit();
                }
            }
        }

        public List<Customer> getAllCustomers()
        {
            getDataFromDB();
            return kunden;
        }

        public Customer getCustomer(int Kundennummer)
        {
            return kunden[0];
        }

        public void addCustomer(Customer e)
        {
            /* using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(k);
                    tx.Commit();
                }

                Console.ReadLine();
            } */
        }

        public void updateCustomer(Customer e)
        {

        }

        public void deleteCustomer(int Kundennummer)
        {

        }
    }
}