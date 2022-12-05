using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Juego_de_preguntas.Convertidores
{
    class ConvertidorDificultad : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return "./Recursos/Levels/battery-no-level.png";
            
            switch (value.ToString())
            {
                case "Facil":
                    return "./Recursos/Levels/easy-level.png";
                case "Medio":
                    return "./Recursos/Levels/medium-level.png";
                case "Dificil":
                    return "./Recursos/Levels/hard-level.png";
                default:
                    return "./Recursos/Levels/battery-no-level.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
