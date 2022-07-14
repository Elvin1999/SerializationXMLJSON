using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationXMLJSON
{

    public class Car
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }

        public override string ToString()
        {
            return $"{Model.PadRight(15)} - {Vendor} - {Year}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            var cars = new List<Car>
            {
                new Car
                {
                    Model="Mustang",
                    Vendor="Ford",
                    Year=1964
                },
                new Car
                {
                    Model="Charger",
                    Vendor="Dodge",
                    Year=2000
                },
                new Car
                {
                    Model="Veyron",
                    Vendor="Bugatti",
                    Year=2010
                },
                new Car
                {
                    Model="F10",
                    Vendor="BMW",
                    Year=2020
                },
            };

            #region XmlWriter Write

            //using (var writer=new XmlTextWriter("cars.xml",Encoding.UTF8))
            //{
            //    writer.Formatting = Formatting.Indented;
            //    writer.WriteStartDocument();

            //    writer.WriteStartElement("Cars");

            //    foreach (var car in cars)
            //    {
            //        writer.WriteStartElement("Car");

            //        /////like tag
            //        ////writer.WriteElementString(nameof(car.Model), car.Model);
            //        ////writer.WriteElementString(nameof(car.Vendor), car.Vendor);
            //        ////writer.WriteElementString(nameof(car.Year), car.Year.ToString());


            //        //// like attribute
            //        writer.WriteAttributeString(nameof(car.Model), car.Model);
            //        writer.WriteAttributeString(nameof(car.Vendor), car.Vendor);
            //        writer.WriteAttributeString(nameof(car.Year), car.Year.ToString());


            //        writer.WriteEndElement();
            //    }

            //    writer.WriteEndElement();

            //    writer.WriteEndDocument();
            //}

            #endregion

            #region Xml Reading

            //XmlDocument xml = new XmlDocument();
            //xml.Load("cars.xml");

            //var root = xml.DocumentElement;
            //if (root.HasChildNodes)
            //{
            //    foreach (XmlNode car_node in root.ChildNodes)
            //    {
            //        var car = new Car
            //        {
            //            Model = car_node.Attributes[0].Value,
            //            Vendor = car_node.Attributes[1].Value,
            //            Year = int.Parse(car_node.Attributes[2].Value)
            //        };
            //        Console.WriteLine(car);
            //    }
            //}


            #endregion


            DateTime dateTime = new DateTime(1, 1, 1, 13, 30, 0);
            Console.WriteLine(dateTime.ToLongTimeString());
            //var army = new TranslatorArmy
            //{
            //    Name = "Step IT Academy",
            //    Location = "Koroglu Rehimov 71",
            //    Translators = new List<Translator>
            //    {
            //        new Translator("Tural", "Eliyev", 1)
            //        {
            //            Subjects=new List<Subject>
            //            {
            //                new Subject
            //                {
            //                    Name="C++",
            //                    Degree=42,
            //                    Lessons=30
            //                },
            //                new Subject
            //                {
            //                    Name="C#",
            //                    Degree=42,
            //                    Lessons=30
            //                }
            //            }
            //        },
            //        new Translator("Eli", "Mammadov", 1)
            //        {
            //            Subjects=new List<Subject>
            //            {
            //                new Subject
            //                {
            //                    Name="Adobe Photoshop",
            //                    Degree=42,
            //                    Lessons=30
            //                },
            //                new Subject
            //                {
            //                    Name="PHP",
            //                    Degree=42,
            //                    Lessons=30
            //                }
            //            }
            //        },
            //         new Translator("Leyla", "Axmedova", 1)
            //        {
            //            Subjects=new List<Subject>
            //            {
            //                new Subject
            //                {
            //                    Name="HTML/CSS",
            //                    Degree=42,
            //                    Lessons=30
            //                },
            //                new Subject
            //                {
            //                    Name="Angular 9",
            //                    Degree=42,
            //                    Lessons=30
            //                }
            //            }
            //        }
            //    }
            //};

            //Serialize
            #region XML Serialize

            //var xml = new XmlSerializer(typeof(TranslatorArmy));
            //using (var fs = new FileStream("Translator.xml", FileMode.OpenOrCreate))
            //{
            //    xml.Serialize(fs, army);
            //}
            //Console.WriteLine("Ready");

            #endregion


            //Deserialize
            #region XML Deserealize
            //TranslatorArmy army = null;
            //var xml = new XmlSerializer(typeof(TranslatorArmy));
            //using (var fs = new FileStream("Translator.xml", FileMode.OpenOrCreate))
            //{
            //    army = xml.Deserialize(fs) as TranslatorArmy;

            //}

            //Hospital  id[ignore],address , name , Doctors[HospitalDoctors]
            //Doctor  no[ignore],name[NameOfDoctor],surname,age,WorkTimes
            //WorkTime startTime endTime

            //Console.WriteLine(army);
            #endregion



            #region Binary Serialize

            //var database = new Translator[]
            //{
            //    new Translator("Akif","Akifli",1),
            //    new Translator("Akif","Akifli",1),
            //    new Translator("Akif","Akifli",1),
            //};

            //var bf = new BinaryFormatter();
            //using (var fs=new FileStream("file.bin",FileMode.OpenOrCreate))
            //{
            //    bf.Serialize(fs, database);
            //}

            #endregion


            #region Binary Deserialize
            //Translator[] db = null;
            //var bf=new BinaryFormatter();
            //using (var fs=new FileStream("file.bin",FileMode.OpenOrCreate))
            //{
            //    db = bf.Deserialize(fs) as Translator[];
            //}

            //foreach (var item in db)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion




            #region JsonSerialization


            //var serializer = new JsonSerializer();
            //using (var sw = new StreamWriter("cars.json"))
            //{
            //    using (var jw = new JsonTextWriter(sw))
            //    {
            //        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
            //        serializer.Serialize(jw, cars);
            //    }
            //}

            #endregion



            #region Json Deserialize
            Car[] mycars = null;
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader("cars.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    mycars = serializer.Deserialize<Car[]>(jr);
                }
            }
            Console.WriteLine(mycars);
            foreach (var item in mycars)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
