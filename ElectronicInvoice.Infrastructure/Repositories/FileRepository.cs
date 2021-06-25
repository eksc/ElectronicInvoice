using ElectronicInvoice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string _filePath = "../ElectronicInvoice.Infrastructure/SeedData/Invoices.csv";

        public async Task<string> ReadFile()
        {
            using var sourceStream = new FileStream(
                _filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true);

            var csvText = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                csvText.Append(text);
            }

            return csvText.ToString();
        }

        public async Task WriteFile(string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using var sourceStream =
                new FileStream(
                    _filePath,
                    FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }

        public List<Core.Models.ElectronicInvoice> ParseCsvTextToElectronicInvoices(string csvText)
        {
            var electronicInvoices = new List<Core.Models.ElectronicInvoice>();

            foreach (var line in csvText.Split(Environment.NewLine))
            {
                if (line.Trim().Length > 0)
                {
                    var columns = line.Split(";");
                    electronicInvoices.Add(new Core.Models.ElectronicInvoice()
                    {
                        CreateDate = DateTime.Parse(columns[0]),
                        Id = int.Parse(columns[1]),
                        StatusInvoice = (Core.Models.Enums.StatusInvoice)int.Parse(columns[2]),
                        Amount = double.Parse(columns[3], CultureInfo.InvariantCulture),
                        PaymentMethod = (Core.Models.Enums.PaymentMethod)int.Parse(columns[4])
                    });
                }
            }

            return electronicInvoices;
        }

        public string ParseElectronicInvoicesToCsvText(List<Core.Models.ElectronicInvoice> electronicInvoices)
        {
            var newText = new StringBuilder();

            foreach (var electronicInvoice in electronicInvoices)
            {
                newText.Append($@"{electronicInvoice.CreateDate:yyyy-MM-dd HH:mm:ss};
                                  {electronicInvoice.Id};
                                  {electronicInvoice.StatusInvoice};
                                  {electronicInvoice.Amount};
                                  {electronicInvoice.PaymentMethod}{Environment.NewLine}"
                              );
            }

            return newText.ToString();
        }
    }
}
