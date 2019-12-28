using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace PhoneBookTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                /* create person objects and put them in the PhoneBook and database
               * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
               * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
               */
                var newPersonList = new List<Person>()
                {
                    new Person()
                    {
                        name        = "John Smith",
                        address     = "1234 Sand Hill Dr, Royal Oak, MI",
                        phoneNumber = "(248) 123-4567"
                    },
                    new Person()
                    {
                        name        = "Cynthia Smith",
                        address     = "875 Main St, Ann Arbor, MI",
                        phoneNumber = "(824) 128-8758"
                    }
                };

                var phoneBook = new PhoneBook();

                foreach (var person in newPersonList)
                {
                    phoneBook.addPerson(person);
                }

                // print the phone book out to System.out
                phoneBook.printPhoneBook(); //from class
                phoneBook.printPhoneBookAtFile("system.txt"); //from db in file

                // find Cynthia Smith and print out just her entry
                // Maria: based is the first person found
                var searchPerson = phoneBook.findPerson("Cynthia Smith");

                // insert the new person objects into the database
                var newPerson = new Person()
                {
                    name = "NewPerson",
                    address = "newAddress",
                    phoneNumber = "00000000"
                };

                phoneBook.addPersonDB(newPerson);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}