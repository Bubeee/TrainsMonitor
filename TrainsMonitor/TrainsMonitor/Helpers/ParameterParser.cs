using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using TrainsMonitor.Repository.MSSQL.Entities;

namespace TrainsMonitor.Helpers
{
    public static class ParameterParser
    {
        public static TrainDataEntity GetDataModelFromInputString(string snNumber, string inputStr, out ushort serverComputedCrc)
        {
            inputStr = inputStr.StringCuttedBy("%");

            var paramPositions =
                Array.ConvertAll(ConfigurationManager.AppSettings["parameterPositions"].Split(','), int.Parse);

            var dataModel = new TrainDataEntity();
            // retrieve date, because it's in integer
            dataModel.DateTime = GetDateTime(inputStr.Substring(paramPositions[4] * 2, 12));
            var byteArray = inputStr.SplitInParts(2).Select(s => byte.Parse(s, NumberStyles.HexNumber)).ToArray();

            var index = 1;
            dataModel.PackageNumber = ushort.Parse(snNumber);
            dataModel.SystemSerialNumber = BitConverter.ToUInt16(byteArray, paramPositions[index++]);
            dataModel.ProviderName = Encoding.Default.GetString(byteArray.SubArray(paramPositions[index++], 15)).StringCuttedBy("\0");
            dataModel.IsSystemWorking = BitConverter.ToBoolean(byteArray, paramPositions[index++]);

            // skipping date
            index += 6;

            dataModel.EnvironmentTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.Radiator1Temperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.Radiator2Temperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.FootstepTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.TurbineTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.OilTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.TransformatorTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.CabinTemperature = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.Voltage = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.Heater1FuelConsumption = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.Heater2FuelConsumption = BitConverter.ToSingle(byteArray, paramPositions[index++]);
            dataModel.AirHeaterFuelConsumption = BitConverter.ToSingle(byteArray, paramPositions[index++]);

            dataModel.Heater1Flags = BitConverter.ToUInt16(byteArray, paramPositions[index++]);
            dataModel.Heater2Flags = BitConverter.ToUInt16(byteArray, paramPositions[index++]);
            dataModel.AirHeaterFlags = BitConverter.ToUInt16(byteArray, paramPositions[index++]);

            dataModel.SystemFlags = byteArray[paramPositions[index++]];
            dataModel.CrcData = BitConverter.ToUInt16(byteArray, paramPositions[index]);

            serverComputedCrc = Crc16Calculator.ComputeCrc16Bit(byteArray, byteArray.Length - 2);

            return dataModel;
        }

        private static DateTime GetDateTime(string dateString)
        {
            var dateArray = dateString.SplitInParts(2).Select(s => int.Parse(s, NumberStyles.Integer)).ToArray();

            return new DateTime(2000 + dateArray[0], dateArray[1], dateArray[2], dateArray[3], dateArray[4], dateArray[5]);
        }
    }
}