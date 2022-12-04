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
        public string EscrituraJSON(ObservableCollection<Pregunta> lista)
        {
            string preguntaJson = JsonConvert.SerializeObject(lista);
            //File.WriteAllText("preguntas.json", preguntaJson);
            return preguntaJson;
        }


        public ObservableCollection<Pregunta> LecturaJSON(string ruta)
        {
            string preguntaJson = File.ReadAllText(ruta);
            return JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(preguntaJson);
        }
    }
}
