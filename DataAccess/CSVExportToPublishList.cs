using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain; 
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    public class CSVExportToPublishList
    {
        public void CreateFile(Encoding encoding, string filePath, List<Offer> winningOfferList)
        {
            try
            {
                // Delete the file if it exists.
                if (File.Exists(filePath))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(filePath);
                }
                // Create the file.
                using (StreamWriter streamWriter = new StreamWriter(@filePath, true, encoding))
                {
                    streamWriter.WriteLine("Garantivognsnummer" + ";" + "Virksomhedsnavn" + ";" + "Pris" + ";");
                    foreach (Offer offer in winningOfferList)
                    {
                        streamWriter.WriteLine(offer.RouteID + ";" + offer.Contractor.CompanyName + ";" + offer.OperationPrice + ";");
                    }
                    streamWriter.Close();
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Filen blev ikke gemt");
            }
        }

    }

}
