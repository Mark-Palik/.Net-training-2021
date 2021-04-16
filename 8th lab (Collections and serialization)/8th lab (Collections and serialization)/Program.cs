using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace _8th_lab__Collections_and_serialization_
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
            //Создаем коллекцию с несколькими элементами
            MyLinkedList<Circle> list1 = new MyLinkedList<Circle>(new Circle(15), new Circle(7));
            //Создаем элементы для коллекции
            Circle hex1 = new Circle(8);
            Circle hex2 = new Circle(4);
            Circle hex3 = new Circle(9);
            Circle hex4 = new Circle(20);
            Circle hex5 = new Circle(5);

            //Привязываем элементы в коллекцию
            list1.Add(hex1);
            list1.Add(hex2);
            list1.Add(new Circle(10));

            Node<Circle> node = list1.Add(hex3);

            list1.AddBefore(node, hex4);

            list1.AddFirst(hex5);

            Console.WriteLine("Collection before sorting:");
            list1.DisplayToConsole();
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Collection after internal sort method:");
            list1.BubbleSort();
            list1.DisplayToConsole();
            Console.WriteLine("=======================================================================");

            Console.WriteLine("Collection after sorting by area via LINQ:");
            var Circles = from cir in list1 orderby cir.Square() descending select cir;
            int index = 0;
            foreach (var cir in Circles)
            {
                Console.WriteLine($" {index}: {cir}");
                index++;
            }
            Console.WriteLine("=======================================================================");


            Console.WriteLine("Collection saved to file");
            list1.SaveToFile();
            Console.WriteLine("=======================================================================");

            Console.WriteLine("Output from file:");
            using (StreamReader sr = File.OpenText("Linked List.txt"))
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
            var collectionsWithSixElelms =  from list in listArray
                                       where list.Count == numOfElem
                                       select list;
            Console.WriteLine($"Collections in which {numOfElem} elements:");
            foreach (var item in collectionsWithSixElelms)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=======================================================================");

            //Запрос 2: найти минимальную коллекцию и максимальную коллекции (выберем по количеству элементов)
            var lists = from list in listArray orderby list.Count ascending select list;
            Console.WriteLine($"Min collection by num of elements:\n{lists.First()}");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"Max collection by num of elements:\n{lists.Last()}");
            Console.WriteLine("=======================================================================");
        }
        public static void Serialization(string fileName = "SerializedCollection.txt")
        {
            MyLinkedList<Circle> list = new MyLinkedList<Circle>(new Circle(15), new Circle(10), new Circle(7), new Circle(99), new Circle(1));
            Console.WriteLine("Коллекция:");
            Console.WriteLine(list);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using Stream stream = File.Open(fileName, FileMode.Create);
                bf.Serialize(stream, list);
                Console.WriteLine($"Collection {nameof(list)} serialized into a file \"{fileName}\"");
            }
            catch (SerializationException)
            {
                Console.WriteLine("Serializing error.");
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
                    Console.WriteLine("Collection after deserializing:");
                    using (Stream stream = File.Open(fileName, FileMode.Open))
                    {
                        desirList = (MyLinkedList<Circle>)bf.Deserialize(stream);
                    }

                    Console.WriteLine(desirList);
                }
                catch (SerializationException)
                {
                    Console.WriteLine("Failed to deserialize.");
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
