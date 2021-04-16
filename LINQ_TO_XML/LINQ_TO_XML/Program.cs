using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Xml;
using System.Xml.Linq;
namespace LINQ_TO_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLTask_28();
            XMLTask_68();
            XMLTask_58("azaza");
            XMLTask_48();
            XMLTask_18();
            XMLTask_8();
            Console.WriteLine("Hello World!");
            
        }
        public static void XMLTask_8(string path = "InputFile.txt", string outPutXML = "output.xml")
        {
            var doc = new XElement("root");
            string[] arrOfLines = File.ReadAllLines(path);
            for (int i = 0; i < arrOfLines.Length; i++)
            {
                var lineData = new XElement("line");
                var arrOfWords = arrOfLines[i].Split(' ');
                foreach (string str in arrOfWords)
                {
                    var wordData = new XElement("word");
                    foreach (char c in str)
                    {
                        wordData.Add(new XElement("char", c));
                    }
                    lineData.Add(wordData);
                }
                doc.Add(lineData);
            }
            doc.Save("output.xml");
        }
        public static void XMLTask_18()
        {
            XDocument xDoc = XDocument.Load("Task18.xml");
            var attributes = xDoc.Root.Descendants().Attributes();
            var allNames = (from attr in attributes select attr.Name).Distinct();
            foreach (var name in allNames)
            {
                var values = from atr in attributes where atr.Name == name orderby atr.Value ascending select atr.Value;
                Console.WriteLine($"attribute name : {name}");
                foreach (var val in values)
                {
                    Console.WriteLine(val);
                }
            }
        }
        public static void XMLTask_28()
        {
            // Сделать выборку элементов у которых есть дочерний текстовый
            //XDocument xDoc = XDocument.Load("Task28.xml");
            //var elemsOfthird = xDoc.Elements().Elements().Elements();
            //foreach(var item in elemsOfthird)
            //{
            //    foreach (var text in item.DescendantNodes())
            //    {
            //        if (item.DescendantNodes().Count() == 1 && text.)
            //        {
            //            //if (text.OfType<XText>())

            //        }
            //        else
            //        {
            //            text.Remove();
            //        }
            //    }
            //}
            XDocument xdoc1 = XDocument.Load("Task28.xml");
            var third = xdoc1.Elements().Elements().Elements();
            foreach (XElement elem3 in third)
            {
                IEnumerable<XText> xtext = elem3.Elements().OfType<XText>();
                foreach (XText deleteIt in xtext)
                {
                    deleteIt.Remove();
                }
                elem3.Value = "";
            }
            xdoc1.Save("Task28Processed.xml");
        }
        public static void XMLTask_48()
        {
            XDocument xDoc = XDocument.Load("Task48.xml");
            var hasTwoChildren = from node in xDoc.Root.Descendants() where node.DescendantNodes().Count() >= 2 select node;
            var withProcInstr = from node in hasTwoChildren where node.DescendantNodes().OfType<XProcessingInstruction>().Any() select node;
            var withoutProcInstr = hasTwoChildren.Except(withProcInstr);
            foreach (var node in withProcInstr)
            {
                XElement elem = new XElement("has-instructions", true);
                node.LastNode.AddBeforeSelf(elem);
            }
            foreach (var node in withoutProcInstr)
            {
                XElement elem = new XElement("has-instructions", false);
                node.LastNode.AddBeforeSelf(elem);
            }
            xDoc.Save("Task48AfterProcessing.xml");
        }
        public static void XMLTask_58(string S, string inputXMLFilePath = "Task58.xml")
        {
            var document = XDocument.Load(inputXMLFilePath);
            XNamespace ns = S;
            document.Root.Name = ns + document.Root.Name.ToString();
            document.Root.Add(new XAttribute(XNamespace.Xmlns + "node", S));
            foreach (var element in document.Root.Elements())
            {
                element.Add(new XAttribute(ns + "count", element.DescendantNodes().Count()));
                element.Add(new XAttribute(XNamespace.Xml + "count", element.Descendants().Count()));
            }
            document.Save("Task58Processed.xml");

        }
        public static void XMLTask_68()
        {
            XDocument xDoc = XDocument.Load("Task68.xml");
            var elems = from elem in xDoc.Root.Elements() where elem.Name == "record" select elem;
            Console.WriteLine(elems.Count());
            foreach (var node in elems)
            {
                XElement station = new XElement("station", new XAttribute("company", node.Element("company").Value));
                station.Add(new XAttribute("street", node.Element("street").Value));
                XElement info = new XElement("info");
                info.Add(new XElement("brand", node.Element("brand").Value), new XElement("price", node.Element("price").Value));
                station.Add(info);
                xDoc.Root.Add(station);
                Console.WriteLine(elems.Count());
            }
            elems.Remove();
            xDoc.Save("Task68_Processed.xml");
        }
    }
}
