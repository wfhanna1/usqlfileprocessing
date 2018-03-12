using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingHelper
{
    public static class PreProcessFile
    {
        private static StreamReader inputStream;
        private static StreamWriter outputStream;

        public static int Start(string inputFilePath, string outputFilePath)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"No file found at {inputFilePath}");
                }

                //Get ASCII values for new line and empty line
                //var returnLine = Encoding.ASCII.GetBytes("\r");
                //var newLine = Encoding.ASCII.GetBytes('\n');

                //Create or overwrite the output file
                var fileCreated = File.Create(outputFilePath);
                fileCreated.Close();
                fileCreated.Dispose();

                //Open connection to the files
                inputStream = new StreamReader(inputFilePath);
                outputStream = new StreamWriter(outputFilePath);
                outputStream.AutoFlush = true;

                ////File Cleanup

                //var lastLine = File.ReadAllLines(inputFilePath);
                ////Get InputFile Size
                //var inputFileLength = File.ReadAllLines(inputFilePath).Length;
                //var counter = 0;

                //Start pre processing the file
                var firstLine = inputStream.ReadLine();
                var updatedFirstLine = firstLine.Insert(0, "[");
                outputStream.WriteLine(updatedFirstLine.Insert(updatedFirstLine.Length, ","));

                while (!inputStream.EndOfStream)
                {
                    var line = inputStream.ReadLine();
                    //Add a comma at the end of each line unless you find an empty line
                    var peekValue = inputStream.Peek();
                    if (peekValue != -1)
                    {
                        outputStream.WriteLine(line?.Insert(line.Length, ","));
                    }
                    else
                    {
                        outputStream.Write(line);
                        //Update the last line in the file
                        outputStream.Write("]");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close any open connection to the files
                outputStream.Flush();
                outputStream.Close();
                outputStream.Dispose();
                inputStream.Close();
                inputStream.Dispose();
            }
            return 0;
        }
    }
}
