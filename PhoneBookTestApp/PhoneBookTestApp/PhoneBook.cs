using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public List<Person> phoneBook { get; set; }

        private SQLiteConnection connection;

        public PhoneBook()
        {
            connection = DatabaseUtil.GetConnection();
            phoneBook = new List<Person>();
        }

        public void addPerson(Person person)
        {
            phoneBook.Add(person);
            addPersonDB(person);
        }

        public void addPersonDB(Person person)
        {
            var stm = $"INSERT INTO PHONEBOOK(NAME, PHONENUMBER, ADDRESS) VALUES('{person?.name}', '{person?.phoneNumber}', '{person?.address}')";
            var cmd = new SQLiteCommand(stm, connection);
            cmd.ExecuteNonQuery();
        }

        public Person findPerson(string name)
        {
            var stm = $"SELECT * FROM PHONEBOOK WHERE NAME LIKE '%{name}%' LIMIT 1";
            var cmd = new SQLiteCommand(stm, connection);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            var resultPerson = new Person();
            while (rdr.Read())
            {
                resultPerson.name = rdr.GetString(0);
                resultPerson.phoneNumber = rdr.GetString(1);
                resultPerson.address = rdr.GetString(2);
            }
            return resultPerson;
        }

        public void printPhoneBookAtFile(string address)
        {
            var stm = "SELECT * FROM PHONEBOOK";
            var cmd = new SQLiteCommand(stm, connection);
            var rdr = cmd.ExecuteReader();
            using (StreamWriter sfile = new StreamWriter(address, true))
            {
                sfile.WriteLine($"{rdr.GetName(0)}  {rdr.GetName(1)}    {rdr.GetName(2)}");

                while (rdr.Read())
                {
                    sfile.WriteLine($"{rdr.GetString(0)}    {rdr.GetString(1)}  {rdr.GetString(2)}");
                }
            }
        }

        public void printPhoneBook()
        {
            foreach (var person in phoneBook)
            {
                Console.WriteLine($"Name: {person.name}, Address: {person.address}, Phone: {person.phoneNumber}");
            }
        }
    }
}