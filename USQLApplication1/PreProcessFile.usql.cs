using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace USQLApplication1
{
    public class Script
    {
        static public int Start(string inputFilePath, string outputFilePath)
        {
            return USQLFileProcessingHelper.PreProcessFile.Start(inputFilePath, outputFilePath);
        }
    }
}
