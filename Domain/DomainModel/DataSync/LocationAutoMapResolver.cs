using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.DataSync
{
    /// <summary>
    /// location 从 引号分隔的字符串 映射为 经纬度 两个double类型字段.,
    /// </summary>
    public class LocationLongtitudeAutoMapResolver : IValueResolver<string, double?, double?>
    {
        public double? Resolve(string source, double? destination, double? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source)) { return null; }
            var splited = source.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length != 2) return null;
            try
            {
                return Convert.ToDouble(splited[0]);
            }
            catch
            {
                return null;
            }
        }
    }
    public class LocationLatitudeAutoMapResolver : IValueResolver<string, double?, double?>
    {
        public double? Resolve(string source, double? destination, double? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source)) { return null; }
            var splited = source.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length != 2) return null;
            try
            {
                return Convert.ToDouble(splited[1]);
            }
            catch
            {
                return null;
            }
        }
    }

    public class LocationResolver
    {
        public static double?[] Resolve(string source)

        {
            if (string.IsNullOrEmpty(source)) { return null; }
            var splited = source.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length != 2) return null;
            try
            {
                 var longtitude= Convert.ToDouble(splited[0]);
                var latitude = Convert.ToDouble(splited[1]);
                return new double?[] { longtitude, latitude };
            }
            catch
            {
                return null;
            }

        }
    }
}
