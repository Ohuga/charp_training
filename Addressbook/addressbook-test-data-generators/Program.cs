using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
namespace WebAddressbookTests
{
     class Program
    {
        static void Main(string[] args)
        {
            string dtype = args[0];
            int count = Convert.ToInt32(args[1]);            
            string filename = args[2];
            StreamWriter writer = new StreamWriter(filename);
            string format = args[3];
            if (dtype == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
            }
            else if (dtype=="contacts")
            {
                List<AddressData> list = new List<AddressData>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new AddressData()
                    {
                        Fname = TestBase.GenerateRandomString(100),
                        Lname = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "xml")
                {
                    writeContactsToXmlFile(list, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(list, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
            }
            else
                System.Console.Out.Write("Unrecognized data type " + dtype);
            writer.Close();
        }

        private static void writeContactsToJsonFile(List<AddressData> list, StreamWriter writer)
        {
            writer.WriteLine(JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
        }

        private static void writeContactsToXmlFile(List<AddressData> list, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressData>)).Serialize(writer, list);
        }

        private static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            var app = new Excel.Application();
            app.Visible = true;
            var wb = app.Workbooks.Add();
            var ws = wb.ActiveSheet;
            for (int i = 0; i < groups.Count; i++)
            {
                GroupData group = groups[i];
                ws.Cells[i+1,1] = group.Name;
                ws.Cells[i + 1, 2] = group.Header;
                ws.Cells[i + 1, 3] = group.Footer;
            }
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
           foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.WriteLine(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
