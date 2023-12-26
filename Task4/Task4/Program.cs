using System;
using System.Xml.Linq;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = GetDataFromUser();
            XDocumentParse(person);
            Console.ReadKey();
        }


        /// <summary>
        /// Заполнение структуры Person данными
        /// </summary>
        static Person GetDataFromUser()
        {
            Person person = new Person();
            person.FullName = AddInfo("ФИО персоны");
            person.Street = AddInfo("улицу");
            person.BuildingNumber = IsIntValid("номер дома");
            person.ApartmentNumber = IsIntValid("номер квартиры");
            person.MobileNumber = IsIntValid("номер мобильного телефона");
            person.PhoneNumber = IsIntValid("номер домашнего телефона");
            return person;
        }

        /// <summary>
        /// Метод для считывания введенной информации с заглавием
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        static string AddInfo(string title)
        {
            Console.Write($"Введите {title}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод для проверки корректности Int
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        static int IsIntValid(string title)
        {
            string tempValue = AddInfo(title);
            if (int.TryParse(tempValue, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
                return IsIntValid(title);
            }
        }

        static void XDocumentParse(Person person)
        {
            XElement XA_person = new XElement("Person");
            XElement XA_address = new XElement("Address");
            XElement XA_street = new XElement("Street");
            XElement XA_houseNumber = new XElement("HouseNumber");
            XElement XA_flatNumber = new XElement("FlatNumber");
            XElement XA_phones = new XElement("Phones");
            XElement XA_mobilePhone = new XElement("MobilePhone");
            XElement XA_flatPhone = new XElement("FlatPhone");

            XAttribute xa_person = new XAttribute("name", person.FullName);
            XText xt_street = new XText(person.Street);
            XText xt_houseNumber = new XText(person.BuildingNumber.ToString());
            XText xt_flatNumber = new XText(person.ApartmentNumber.ToString());
            XText xt_mobilePhone = new XText(person.MobileNumber.ToString());
            XText xt_flatPhone = new XText(person.ApartmentNumber.ToString());

            XA_flatPhone.Add(xt_flatPhone);
            XA_mobilePhone.Add(xt_mobilePhone);
            XA_flatNumber.Add(xt_flatNumber);
            XA_houseNumber.Add(xt_houseNumber);
            XA_street.Add(xt_street);

            XA_phones.Add(XA_mobilePhone, XA_flatPhone);
            XA_address.Add(XA_street, XA_houseNumber, XA_flatNumber);

            XA_person.Add(XA_address, XA_phones, xa_person);
            XA_person.Save("NoteBook.xml");
            Console.WriteLine("\nЗапись успешно создана!");
        }
    }
}
