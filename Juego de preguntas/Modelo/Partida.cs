using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.Modelo
{
    class Partida : ObservableObject
    {
        private Pregunta pregunta;
        public Pregunta Pregunta { get => pregunta; set => pregunta = value; }

        public Partida() { }

        public Partida(Pregunta pregunta)
        {
            Pregunta = pregunta;
        }


    }
}
