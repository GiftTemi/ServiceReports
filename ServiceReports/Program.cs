using System;
using System.IO;
using System.Linq;

namespace ServiceReports
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadFie();
            }
            catch (Exception ex)
            {
                //Log Error here
            }
        }
        static void ReadFie()
        {
            try
            {
                string buffer = default;
                using (FileStream stm = new FileStream(@"Files\PhoneNumbers.txt", FileMode.Open, FileAccess.Read, System.IO.FileShare.None))
                {
                    using (StreamReader rdr = new StreamReader(stm))
                    {
                        buffer = rdr.ReadToEnd();
                    }
                }
                if (!string.IsNullOrEmpty(buffer))
                {
                    var numList = buffer.Split('\n', StringSplitOptions.None).ToList();

                    int MTNCount = numList.Where(ToCheck => ToCheck.StartsWith("0703") || ToCheck.StartsWith("0706") || ToCheck.StartsWith("0803") ||
                    ToCheck.StartsWith("0806") || ToCheck.StartsWith("0810") || ToCheck.StartsWith("0813") || ToCheck.StartsWith("0814") ||
                    ToCheck.StartsWith("0816") || ToCheck.StartsWith("0903") || ToCheck.StartsWith("0906") || ToCheck.StartsWith("0913") ||
                    ToCheck.StartsWith("0916") || ToCheck.StartsWith("07025") || ToCheck.StartsWith("07026") || ToCheck.StartsWith("0704")).Count();


                    int AirtelCount = numList.Where(ToCheck => ToCheck.StartsWith("0701") || ToCheck.StartsWith("0708") || ToCheck.StartsWith("0802") ||
                    ToCheck.StartsWith("0808") || ToCheck.StartsWith("0812") || ToCheck.StartsWith("0901") || ToCheck.StartsWith("0902") ||
                    ToCheck.StartsWith("0904") || ToCheck.StartsWith("0907") || ToCheck.StartsWith("0912")).Count();

                    int GloCount = numList.Where(ToCheck => ToCheck.StartsWith("0705") || ToCheck.StartsWith("0805") || ToCheck.StartsWith("0807") ||
                    ToCheck.StartsWith("0811") || ToCheck.StartsWith("0815") || ToCheck.StartsWith("0905") || ToCheck.StartsWith("0915")).Count();

                    int NineMobileCount = numList.Where(ToCheck => ToCheck.StartsWith("0809") || ToCheck.StartsWith("0817")
                    || ToCheck.StartsWith("0818") || ToCheck.StartsWith("0909") || ToCheck.StartsWith("0908")).Count();

                    var MTELCount = numList.Where(ToCheck => ToCheck.StartsWith("0804")).Count();

                    Console.WriteLine($"Service Provider's Summary report by count \n");
                    Console.WriteLine($"MTN\t: {MTNCount}");
                    Console.WriteLine($"Airtel\t: {AirtelCount}");
                    Console.WriteLine($"Glo\t: {GloCount}");
                    Console.WriteLine($"9Mobile\t: {NineMobileCount}");
                    Console.WriteLine($"MTEL\t: {MTELCount}");
                    Console.WriteLine($"Total Record\t: {numList.Count()}");
                }
                else
                    Console.WriteLine($"No Phone numbers found in file");
                Console.ReadLine();
            }
            catch (Exception ex)
            {//Place Logger here to log error
            }
        }
    }
}
