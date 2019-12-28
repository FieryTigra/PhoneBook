namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        /// <summary>
        /// Searching person from PhoneBook
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        Person findPerson(string name);

        /// <summary>
        /// Add person in current PhoneBook and Database
        /// </summary>
        /// <param name="newPerson"></param>
        void addPerson(Person newPerson);

        /// <summary>
        /// Add person only in Database
        /// </summary>
        /// <param name="person"></param>
        void addPersonDB(Person person);

        /// <summary>
        /// Print data from Database in file
        /// </summary>
        /// <param name="address"></param>
        void printPhoneBookAtFile(string address);

        /// <summary>
        /// Print current PhoneBook at console
        /// </summary>
        void printPhoneBook();
    }
}