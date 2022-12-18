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
        private bool partidaEnJuego;

        public bool PartidaEnJuego
        {
            get { return partidaEnJuego; }
            set { SetProperty(ref partidaEnJuego, value); }
        }


        private string dificultadPartida;

        public string DificultadPartida
        {
            get { return dificultadPartida; }
            set { SetProperty(ref dificultadPartida, value); }
        }

        public Partida() { }


    }
}
