using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Juego_de_preguntas.Convertidores
{
    class ConvertidorCategoria : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return "./Recursos/Categorias/no-categoria.png";
            
            switch(value.ToString())
            {
                case "Armas":
                    return "./Recursos/Categorias/armas.png";
                case "Habilidades":
                    return "./Recursos/Categorias/habilidades.png";
                case "Personajes":
                    return "./Recursos/Categorias/personajes.png";
                case "Mapas":
                    return "./Recursos/Categorias/mapa.png";
                default:
                    return "./Recursos/Categorias/no-categoria.png";

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
