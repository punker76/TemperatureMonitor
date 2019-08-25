﻿using System;
using System.Globalization;
using System.Windows.Data;
using TemperatureMonitor.Utilities;

namespace TemperatureMonitor
{
    public class TransformConverter : BaseConverter, IMultiValueConverter
    {
        public TransformConverter()
        {
        }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Length >= 2)
            {
                var lowerValue = System.Convert.ToDouble(value[0]);
                var upperValue = System.Convert.ToDouble(value[1]);

                var result = 1 / (upperValue - lowerValue);

                if (System.Convert.ToString(parameter).Equals("translate"))
                {
                    result = -GraphSettings.Width * result * lowerValue;
                }

                return result;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
