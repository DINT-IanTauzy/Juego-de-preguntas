using Juego_de_preguntas.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.Servicios
{
    class ServicioJson
    {
        public void EscrituraJSON(string ruta, ObservableCollection<Pregunta> lista)
        {
            string preguntaJson = JsonConvert.SerializeObject(lista);
            try
            {
                File.WriteAllText(ruta, preguntaJson);
            }
            catch (ArgumentException)
            {
            }

        }


        public ObservableCollection<Pregunta> LecturaJSON(string ruta)
        {
            string preguntaJson = "";
            try
            {
                preguntaJson = File.ReadAllText(ruta);
            }
            catch (ArgumentException)
            {  
            }
            
            return JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(preguntaJson);
        }
    }
}
