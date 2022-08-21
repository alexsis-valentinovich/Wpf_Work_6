using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Work_6
{
    enum Precipitation
    {
        солнечно,
        облачно,
        дождь,
        снег
    }
    class WeatherControl : DependencyObject
    {
        private string wind_direction;
        private int wind_speed;


        public WeatherControl(string windDir, int windSpeed, Precipitation precipitation)
        {
            this.wind_direction = windDir;
            this.wind_speed = windSpeed;
        }
        public static readonly DependencyProperty TempProperty;
        public static readonly DependencyProperty WindProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public string WindDirection
        {
            get => (string)GetValue(WindProperty);
            set => SetValue(WindProperty, value);

        }

        static WeatherControl()
        {

            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));


            WindProperty = DependencyProperty.Register(
                nameof(WindDirection),
                typeof(string),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
            new CoerceValueCallback(CoerceWind)),
            new ValidateValueCallback(ValidateWind));

        }
        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }
        private static bool ValidateWind(object value)
        {
            string v = (string)value;
            if (v == "С" || v == "Ю" || v == "В" || v == "З")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceWind(DependencyObject d, object baseValue)
        {
            string v = (string)baseValue;
            if (v == "С" || v == "Ю" || v == "В" || v == "З")
            {
                return v;
            }
            else
            {
                return null;
            }
        }
    }
}

