using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using ExcelDataReader;

namespace _1C2Bastion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Файл .xls не найден, перетащите его на значок программы");
                Console.WriteLine("Нажмите любую кнопку для выхода");
                Console.Read();
                return;
            }
            Document doc = new Document();

            using (FileStream stream = File.Open(args[0], FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet();
                    result.Tables[0].Rows[0].Delete();
                    result.AcceptChanges();
                    foreach (DataRow dataRow in result.Tables[0].Rows)
                    {
                        Row row = new Row();
                        row.PassType      = 1.ToString();
                        row.Name          = dataRow.ItemArray[0].ToString();
                        row.FirstName     = dataRow.ItemArray[1].ToString();
                        row.SecondName    = dataRow.ItemArray[2].ToString();
                        row.TableNo       = dataRow.ItemArray[3].ToString();
                        row.Birthdate     = dataRow.ItemArray[4].ToString();
                        row.Sex           = dataRow.ItemArray[5].ToString() == "Женский" ? "1" : "0";
                        row.Address       = dataRow.ItemArray[6].ToString();
                        row.Citizenship   = dataRow.ItemArray[7].ToString();
                        row.DocType       = dataRow.ItemArray[8].ToString();
                        row.DocSer        = dataRow.ItemArray[9].ToString();
                        row.DocNo         = dataRow.ItemArray[10].ToString();
                        row.DocIssueDate  = dataRow.ItemArray[11].ToString();
                        row.DocIssueOrgan = dataRow.ItemArray[12].ToString();
                        string[] split = Regex.Split(dataRow.ItemArray[13].ToString(), @"(?<!^)(?=[А-Я])");
                        if (split.Length == 1)
                        {
                            row.Department = split[0];
                        }
                        else
                        {
                            row.Department = split[0].Trim() + @" \ " + split[1].Trim();
                        }
                        row.Post       = dataRow.ItemArray[14].ToString();
                        row.Birthplace = dataRow.ItemArray[15].ToString();
                        doc.Rows.Add(row);
                    }
                }
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent             = true;
            settings.Encoding           = Encoding.GetEncoding("WINDOWS-1251");
            XmlSerializer xml   = new XmlSerializer(typeof(Document));
            string        path  = Path.GetFullPath(args[0]).Split('.')[0] + ".xml";
            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                xml.Serialize(writer, doc);
            }
        }
    }
}