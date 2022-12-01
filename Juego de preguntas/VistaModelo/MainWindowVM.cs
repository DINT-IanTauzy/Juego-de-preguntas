using CommunityToolkit.Mvvm.ComponentModel;
using Juego_de_preguntas.Modelo;
using Juego_de_preguntas.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.VistaModelo
{
    class MainWindowVM : ObservableObject
    {
        private Pregunta pregunta;

        public Pregunta Pregunta
        {
            get => pregunta;
            set
            {
                SetProperty(ref pregunta, value);
            }
        }

        private Pregunta nuevaPregunta;

        public Pregunta NuevaPregunta
        {
            get { return nuevaPregunta; }
            set { SetProperty(ref nuevaPregunta, value); }
        }


        private ObservableCollection<string> dificultades;

        public ObservableCollection<string> Dificultades
        {
            get { return dificultades; }
            set { SetProperty(ref dificultades, value); }
        }


        private ObservableCollection<string> categorias;

        public ObservableCollection<string> Categorias
        {
            get => categorias;
            set
            {
                SetProperty(ref categorias, value);
            }
        }

        private Pregunta preguntaSeleccionada;

        public Pregunta PreguntaSeleccionada
        {
            get { return preguntaSeleccionada; }
            set { SetProperty(ref preguntaSeleccionada, value); }
        }

        private ObservableCollection<Pregunta> listaPreguntas;

        public ObservableCollection<Pregunta> ListasPreguntas
        {
            get { return listaPreguntas; }
            set { SetProperty(ref listaPreguntas, value); }
        }


        public MainWindowVM()
        {
            serviceDialog = new ServicioDialogos();
            Categorias = new ObservableCollection<string> { "Armas", "Personajes", "Habilidades", "Mapas" };
            Dificultades = new ObservableCollection<string> { "Facil", "Medio", "Dificil" };
            NuevaPregunta = new Pregunta();
        }

        public void AñadirPregunta()
        {
            listaPreguntas.Add(NuevaPregunta);

            nuevaPregunta = new Pregunta();
        }

        private ServicioDialogos serviceDialog;

        public void Examniar()
        {
            NuevaPregunta.Imagen =  serviceDialog.OpenFileDialog();
        }
    }
}
