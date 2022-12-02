using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.Modelo
{
    class Pregunta : ObservableObject
    {

        private string textoPregunta;
        private string respuesta;
        private string imagen;
        private string dificultad;
        private string categoria;

        public string TextoPregunta { get => textoPregunta; set { SetProperty(ref textoPregunta, value); } }
        public string Respuesta { get => respuesta; set { SetProperty(ref respuesta, value); } }
        public string Imagen { get => imagen; set { SetProperty(ref imagen, value); } }
        public string Dificultad { get => dificultad; set { SetProperty(ref dificultad, value); } }
        public string Categoria { get => categoria; set { SetProperty(ref categoria, value); } } 

        public Pregunta(string textoPregunta, string respuesta, string imagen, string dificultad, string categoria)
        {
            TextoPregunta = textoPregunta;
            Respuesta = respuesta;
            Imagen = imagen;
            Dificultad = dificultad;
            Categoria = categoria;
        }

        public Pregunta(){}


    }
}
