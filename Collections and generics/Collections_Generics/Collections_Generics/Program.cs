using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace Collections_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: Collections/Generics.");
            Collections();
            Console.WriteLine("2: Serialization.");
            Serialization();
            Console.WriteLine("3: Deserialization.");
            Deserialization();

        }
        public static void Collections()
        {
            Console.WriteLine("Enter value for number of collection elements to search");
            int numOfElem = int.Parse(Console.ReadLine());

            MyLinkedList<Circle> list1 = new MyLinkedList<Circle>(new Circle(15), new Circle(7));
            //Создаем элементы для коллекции
            Circle cir1 = new Circle(8);
            Circle cir2 = new Circle(4);
            Circle cir3 = new Circle(9);
            Circle cir4 = new Circle(20);
            Circle cir5 = new Circle(5);

            list1.Add(cir1);
            list1.Add(cir2);
            list1.Add(new Circle(10));

            Node<Circle> node = list1.Add(cir3);

            list1.AddBefore(node, cir4);

            list1.AddFirst(cir5);

            Console.WriteLine("Collection before sorting:");
            list1.DisplayToConsole();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Collection after sorting with internal method");
            list1.BubbleSort();
            list1.DisplayToConsole();
            Console.WriteLine("=======================================================================");

            Console.WriteLine("Collection elements sorted by area via linq:");
            var Circles = from cir in list1 orderby cir.Square() descending select cir;
            int index = 0;
            foreach (var cir in Circles)
            {
                Console.WriteLine($" {index}: {cir}");
                index++;
            }
            Console.WriteLine("=======================================================================");


            Console.WriteLine("Collection saved into a file");
            list1.SaveToFile();
            Console.WriteLine("=======================================================================");

            Console.WriteLine("Output from file:");
            using (StreamReader sr = File.OpenText("MyLinkedList.txt"))
            {
                Console.Write(sr.ReadToEnd());
            }
            Console.WriteLine("=======================================================================");


            MyLinkedList<Circle> list2 = new MyLinkedList<Circle>(new Circle(10), new Circle(99), new Circle(1), new Circle(10), new Circle(99), new Circle(1));
            MyLinkedList<Circle> list3 = new MyLinkedList<Circle>(new Circle(7), new Circle(9), new Circle(15), new Circle(17));
            MyLinkedList<Circle> list4 = new MyLinkedList<Circle>(new Circle(7));
            MyLinkedList<Circle>[] listArray = new[] { list1, list2, list3, list4 };


            Console.WriteLine($"\n\n{' ',32}LINQ Queries:");
            //Запрос 1: найти количество коллекций у которых кол-во элементов равно какому-то числу
            var collectionsWithSixElelms = from list in listArray
                                           where list.Count == numOfElem
                                           select list;
            Console.WriteLine($"Collections with {numOfElem} elements:");
            foreach (var item in collectionsWithSixElelms)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=======================================================================");

            //Запрос 2: найти минимальную коллекцию и максимальную коллекции (выберем по количеству элементов)
            var lists = from list in listArray orderby list.Count ascending select list;
            Console.WriteLine($"Min collection by number of elemnts:\n{lists.First()}");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"Max collection by number of elements:\n{lists.Last()}");
            Console.WriteLine("=======================================================================");
        }
        public static void Serialization(string fileName = "SerializedCollection.txt")
        {
            MyLinkedList<Circle> list = new MyLinkedList<Circle>(new Circle(15), new Circle(10), new Circle(7), new Circle(99), new Circle(1));
            Console.WriteLine("Collection:");
            Console.WriteLine(list);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using Stream stream = File.Open(fileName, FileMode.Create);
                bf.Serialize(stream, list);
                Console.WriteLine($"Collection {nameof(list)} serialized into the \"{fileName}\"");
            }
            catch (SerializationException)
            {
                Console.WriteLine("Serialization error");
            }
        }
        public static void Deserialization(string fileName = "SerializedCollection.txt")
        {
            if (File.Exists(fileName))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    MyLinkedList<Circle> desirList;
                    Console.WriteLine("Collection after serializing:");
                    using (Stream stream = File.Open(fileName, FileMode.Open))
                    {
                        desirList = (MyLinkedList<Circle>)bf.Deserialize(stream);
                    }

                    Console.WriteLine(desirList);
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Failed to deserialize");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error");
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} doesn't exist.");
            }
        }
    }
}
