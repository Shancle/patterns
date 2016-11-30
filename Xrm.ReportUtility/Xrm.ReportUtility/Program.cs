using System;
using System.Linq;
using System.Text;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -withData -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args) // ФАБРИЧНЫЙ МЕТОД
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }

        private static void PrintReport(Report report) // Сделал 3-ую хотелку
        {
            if ((report.Config.VolumeSum || report.Config.WeightSum || report.Config.CostSum || report.Config.CountSum) == false) throw new Exception("2-ая Хотелка");

            if (report.Data == null && (report.Config.WithIndex || report.Config.WithTotalVolume || report.Config.WithTotalWeight)) // 1 ХОТЕЛКА
                WriteLineWithColor("warning", ConsoleColor.Yellow);

            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                string rowTemplate;
                var headerRow = GetHeader(report.Config, out rowTemplate); // ещё это можно было сделать с помощью ChainOfResponsibility но я решил не плодить столько классов

                Console.WriteLine(headerRow);
                
                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                    //Кажется не очень хорошо что функции связаны с столбцом через номер переменной в шаблоне, нужно бы вынести название номер в шаблоне и функцию 
                    // в отдельный класс, но как сделать это красиво я себе не очень представляю
                }

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine("  {0,-20}\t{1}", reportRow.Name, reportRow.Value);
                }
            }
        }

        private static string GetHeader(ReportConfig cfg, out string rowTemplate) // сделал builder
        {
            var header = new StringBuilder("Наименование");
            var template = new StringBuilder("{1,12}");
            if (!cfg.WithoutVolume)
            {
                header.Append("\tОбъём упаковки");
                template.Append("\t{2,14}");
            }
            if (!cfg.WithoutWeight)
            {
                header.Append("\tМасса упаковки");
                template.Append("\t{3,14}");
            }
            if (!cfg.WithoutCost)
            {
                header.Append("\tСтоимость");
                template.Append("\t{4,9}");
            }
            if (!cfg.WithoutCount)
            {
                header.Append("\tКоличество");
                template.Append("\t{5,10}");
            }
            if (cfg.WithIndex)
            {
                header.Insert(0, "№\t");
                template.Insert(0, "{0}\t");
            }
            if (cfg.WithTotalVolume)
            {
                header.Append("\tСуммарный объём");
                template.Append("\t{6,15}");
            }
            if (cfg.WithTotalWeight)
            {
                header.Append("\tСуммарный вес");
                template.Append("\t{7,13}");
            }
            rowTemplate = template.ToString();
            return header.ToString();
        }

        private static void WriteLineWithColor(string text, ConsoleColor color)
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = lastColor;
        }
    }
}