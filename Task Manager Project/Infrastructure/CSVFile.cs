using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Threading.Tasks;

public class CSVFile
{
    public static void WriteCSV(string filePath, List<MyTask> Tasks)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }

            var configTasks = new CsvConfiguration(CultureInfo.InvariantCulture) { };

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, configTasks))
            {
                csvWriter.WriteRecords(Tasks);
            }
            
        } catch (Exception ex)
        {
            Console.WriteLine("creating new Task is unsuccessful, Try-again");
        }
    }

  
    public static List<MyTask> ReadCSV(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };

                using (StreamReader streamReader = new StreamReader(filePath))
                using (CsvReader csvReader = new CsvReader(streamReader, config))
                {
                    IEnumerable<MyTask> tasksRecord = csvReader.GetRecords<MyTask>();
                    return tasksRecord.ToList();
                }
            }
            else
            {
                Console.WriteLine("There is no Tasks Created, recently");
                return new List<MyTask>(); 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loading Task is unsuccessful, Try-again");
            return null;
        }
    }




}



