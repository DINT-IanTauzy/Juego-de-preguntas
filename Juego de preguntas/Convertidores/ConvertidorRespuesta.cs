using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Juego_de_preguntas.Convertidores
{
    class ConvertidorRespuesta : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Random semilla = new Random();
            int numRandom = 0;
            string respuesta = value.ToString();
            for (int i = 0; i < respuesta.Length/2; i++)
            {
                numRandom = semilla.Next(0, respuesta.Length);
                respuesta.Replace(respuesta[i], ' ');
            }
            return respuesta;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
