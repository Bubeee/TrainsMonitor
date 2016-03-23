using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using TrainsMonitor.Models;
using TrainsMonitor.Repository.MSSQL.Entities;

namespace TrainsMonitor.Helpers
{
    public static class ParameterParser
    {
        public static TrainDataEntity GetDataModelFromInputString(string inputStr)
        {
            var parameterPositionsString = ConfigurationManager.AppSettings["parameterPositions"].Split(',');
            var parameterPositionsInt = Array.ConvertAll(parameterPositionsString, int.Parse);
            
            var byteArray = inputStr.SplitInParts(2).Select(s => byte.Parse(s, NumberStyles.HexNumber)).ToArray();

            while (byteArray.Length > 0)
            {
                
            }

            var dataModel = new TrainDataEntity();
            return dataModel;
        }
    }
}