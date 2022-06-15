using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace CSVHelperDemo
{
    public class ReadAndWriteCsvToCsv
    {
        public void ReadAndWrite()
        {
            string importPath = @"D:\Bridgelabz\.Net\CSVHelper\CSVHelperDemo\Utilities\ImportDetails.csv";
            string exportPath = @"D:\Bridgelabz\.Net\CSVHelper\CSVHelperDemo\Utilities\ExportDetails.csv";
            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ModelCsv>().ToList();
                foreach(var record in records)
                {
                    Console.WriteLine(record.firstName);
                    Console.WriteLine(record.lastName);
                    Console.WriteLine(record.email);
                    Console.WriteLine(record.phoneNumber);
                    Console.WriteLine(record.country);
                    Console.WriteLine("================");
                }
                using (var export = new StreamWriter(exportPath))
                using (var write = new CsvWriter(export, CultureInfo.InvariantCulture))
                {
                    write.WriteRecords(records);
                }
            }           
        }
    }
}
