using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Juego_de_preguntas.Convertidores
{
    class ConvertidorPista : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Random semilla = new Random();
                int numRandom = 0;
                string respuesta = value.ToString();
                string respuestaFinal = "";
                //StringBuilder sb = new StringBuilder();
                for (int i = 0; i < respuesta.Length / 2; i++)
                {
                    numRandom = semilla.Next(0, respuesta.Length);

                    //sb.Append(respuesta[numRandom]);
                    if (respuesta[numRandom] != ' ')
                        respuesta = respuesta.Replace(respuesta[numRandom], '-');
                    
                }
                return respuesta;
            }
            else return "";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
