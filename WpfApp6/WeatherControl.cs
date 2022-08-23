using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    enum precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    internal class WeatherControl : DependencyObject
    {
        private precipitation precipitation;
        private int temperature;
        private string direction;
        private int speed;
        public string Direction { get; set; }
        public int Speed { get; set; }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WeatherControl(int temperature, string direction, int speed, precipitation precipitation)
        {
            this.temperature = temperature;
            this.direction = direction;
            this.speed = speed;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TemperatureProperty;
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }
        private static bool ValidateTemperature(object value)
        {
            int v=(int)value;
            if (v>=-50 && v<=50)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return null;
        }

    }
}
