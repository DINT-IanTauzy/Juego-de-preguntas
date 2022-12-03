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
        private string urlImagen;
        
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

        public ObservableCollection<Pregunta> ListaPreguntas
        {
            get { return listaPreguntas; }
            set { SetProperty(ref listaPreguntas, value); }
        }

        private ServicioDialogos serviceDialog;
        public ServicioDialogos ServiceDialog { get => serviceDialog; set { SetProperty(ref serviceDialog, value); } }

        private ServicioAzureBlobStorage servicioAzure;

        public ServicioAzureBlobStorage ServicioAzure { get => servicioAzure; set { SetProperty(ref servicioAzure, value); } }

        public MainWindowVM()
        {
            urlImagen = null;
            ListaPreguntas = new ObservableCollection<Pregunta>();
            ServiceDialog = new ServicioDialogos();
            ServicioAzure = new ServicioAzureBlobStorage();
            Categorias = new ObservableCollection<string> { "Armas", "Personajes", "Habilidades", "Mapas" };
            Dificultades = new ObservableCollection<string> { "Facil", "Medio", "Dificil" };
            NuevaPregunta = new Pregunta();
        }

        public void AñadirPregunta()
        {

            //NuevaPregunta.Imagen = urlImagen;

            ListaPreguntas.Add(NuevaPregunta);

            NuevaPregunta = new Pregunta();
        }

        public void LimpiarFormulario()
        {
            NuevaPregunta = null;
        }

        

        public void Examniar()
        {
            
            NuevaPregunta.Imagen = ServicioAzure.AlmacenarImagenEnLaNube(ServiceDialog.OpenFileDialog());

            //PreguntaSeleccionada.Imagen = servicioAzure.AlmacenarImagenEnLaNube(ServiceDialog.OpenFileDialog());
        }
    }
}
