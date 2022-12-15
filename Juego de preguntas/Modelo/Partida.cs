using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.Modelo
{
    class Partida : ObservableObject
    {
        private Pregunta pregunta;
        public Pregunta Pregunta { get => pregunta; set => pregunta = value; }

        

        private ObservableCollection<Pregunta> listaPreguntas;

        private string dificultadPartida;

        public string DificultadPartida
        {
            get { return dificultadPartida; }
            set { SetProperty(ref dificultadPartida, value); }
        }

        public Partida() { }


    }
}
