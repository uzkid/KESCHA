using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBookApp
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PhoneBookService
    {
        private readonly List<Contact> contacts = new List<Contact>();
        private readonly LoggingBroker loggingBroker;
        private readonly FileBroker fileBroker;

        public PhoneBookService(LoggingBroker loggingBroker, FileBroker fileBroker)
        {
            this.loggingBroker = loggingBroker;
            this.fileBroker = fileBroker;
        }

        public void AddContact(string name, string phoneNumber)
        {
            try
            {
                contacts.Add(new Contact { Name = name, PhoneNumber = phoneNumber });
                fileBroker.SaveContacts(contacts);
                Console.WriteLine("Kontakt muvaffaqiyatli qo'shildi.");
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }

        public void DeleteContact(string name)
        {
            try
            {
                var contact = contacts.Find(c => c.Name == name);
                if (contact != null)
                {
                    contacts.Remove(contact);
                    fileBroker.SaveContacts(contacts);
                    Console.WriteLine("Kontakt muvaffaqiyatli o'chirildi.");
                }
                else
                {
                    Console.WriteLine("Kontakt topilmadi.");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }

        public void EditContact(string name, string newPhoneNumber)
        {
            try
            {
                var contact = contacts.Find(c => c.Name == name);
                if (contact != null)
                {
                    contact.PhoneNumber = newPhoneNumber;
                    fileBroker.SaveContacts(contacts);
                    Console.WriteLine("Kontakt muvaffaqiyatli tahrirlandi.");
                }
                else
                {
                    Console.WriteLine("Kontakt topilmadi.");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }

        public void ViewAllContacts()
        {
            try
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }

        public void ViewContact(string name)
        {
            try
            {
                var contact = contacts.Find(c => c.Name == name);
                if (contact != null)
                {
                    Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}");
                }
                else
                {
                    Console.WriteLine("Kontakt topilmadi.");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }

        public void LoadContacts()
        {
            try
            {
                var loadedContacts = fileBroker.LoadContacts();
                if (loadedContacts != null)
                {
                    contacts.AddRange(loadedContacts);
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogError(ex.Message);
            }
        }
    }

    public class LoggingBroker
    {
        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR]: {message}");
        }
    }

    public class FileBroker
    {
        private const string FilePath = "contacts.txt";

        public void SaveContacts(List<Contact> contacts)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"{contact.Name},{contact.PhoneNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Faylni saqlashda xatolik yuz berdi: " + ex.Message);
            }
        }

        public List<Contact> LoadContacts()
        {
            var contacts = new List<Contact>();

            try
            {
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var data = line.Split(',');
                            if (data.Length == 2)
                            {
                                contacts.Add(new Contact { Name = data[0], PhoneNumber = data[1] });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Faylni o'qishda xatolik yuz berdi: " + ex.Message);
            }

            return contacts;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var loggingBroker = new LoggingBroker();
            var fileBroker = new FileBroker();
            var phoneBookService = new PhoneBookService(loggingBroker, fileBroker);

            phoneBookService.LoadContacts();

            while (true)
            {
                Console.WriteLine("\n1. Kontakt qo'shish\n2. Kontaktni o'chirish\n3. Kontaktni tahrirlash\n4. Barcha kontaktlarni ko'rish\n5. Kontaktni nomi bo'yicha ko'rish\n6. Chiqish");
                Console.Write("Tanlovingiz: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ismi: ");
                        var name = Console.ReadLine();
                        Console.Write("Telefon raqami: ");
                        var phone = Console.ReadLine();
                        phoneBookService.AddContact(name, phone);
                        break;

                    case "2":
                        Console.Write("O'chiriladigan kontakt ismi: ");
                        name = Console.ReadLine();
                        phoneBookService.DeleteContact(name);
                        break;

                    case "3":
                        Console.Write("Tahrirlanadigan kontakt ismi: ");
                        name = Console.ReadLine();
                        Console.Write("Yangi telefon raqami: ");
                        phone = Console.ReadLine();
                        phoneBookService.EditContact(name, phone);
                        break;

                    case "4":
                        phoneBookService.ViewAllContacts();
                        break;

                    case "5":
                        Console.Write("Ko'rmoqchi bo'lgan kontakt ismi: ");
                        name = Console.ReadLine();
                        phoneBookService.ViewContact(name);
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov. Qayta urinib ko'ring.");
                        break;
                }
            }
        }
    }
}

