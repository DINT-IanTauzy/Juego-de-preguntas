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

        private const string noImage = "https://trivialian.blob.core.windows.net/trivial/no-image.png";
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

        private ObservableCollection<Pregunta> listaPreg_Nivel;

        public ObservableCollection<Pregunta> ListaPreg_Nivel
        {
            get { return listaPreg_Nivel; }
            set { SetProperty(ref listaPreg_Nivel, value); }
        }

        private ObservableCollection<Pregunta> listaPreg_Categoria;

        public ObservableCollection<Pregunta> ListaPreg_Categoria
        {
            get { return listaPreg_Categoria; }
            set { SetProperty(ref listaPreg_Categoria, value); }
        }

        private string respuestaUsu;

        public string RespuestaUsu
        {
            get { return respuestaUsu; }
            set { SetProperty(ref respuestaUsu, value); }
        }


        private Pregunta preguntaActual;

        public Pregunta PreguntaActual
        {
            get { return preguntaActual; }
            set { SetProperty(ref preguntaActual, value); }
        }


        private Partida partidaActual;

        public Partida PartidaActual
        {
            get { return partidaActual; }
            set { SetProperty(ref partidaActual, value); }
        }

        private ServicioDialogos serviceDialog;
        public ServicioDialogos ServiceDialog { get => serviceDialog; set { SetProperty(ref serviceDialog, value); } }

        private ServicioAzureBlobStorage servicioAzure;

        public ServicioAzureBlobStorage ServicioAzure { get => servicioAzure; set { SetProperty(ref servicioAzure, value); } }

        private ServicioJson servicioJson;

        public ServicioJson ServicioJson { get => servicioJson; set { SetProperty(ref servicioJson, value); } }

        public MainWindowVM()
        {
            PartidaActual = new Partida();
            PreguntaActual = new Pregunta();
            ListaPreguntas = new ObservableCollection<Pregunta>();
            ServiceDialog = new ServicioDialogos();
            ServicioAzure = new ServicioAzureBlobStorage();
            ServicioJson = new ServicioJson();
            Categorias = new ObservableCollection<string> { "Armas", "Personajes", "Habilidades", "Mapas" };
            Dificultades = new ObservableCollection<string> { "Facil", "Medio", "Dificil" };
            NuevaPregunta = new Pregunta();
            ListaPreg_Nivel = new ObservableCollection<Pregunta>();
            listaPreg_Categoria = new ObservableCollection<Pregunta>();
            RespuestaUsu = "";
        }

        public void AñadirPregunta()
        {
            if (NuevaPregunta.Imagen is null)
                NuevaPregunta.Imagen = noImage;
            ListaPreguntas.Add(NuevaPregunta);
            NuevaPregunta = new Pregunta();
        }

        public void LimpiarFormulario()
        {
            NuevaPregunta = null;
        }


        public void Examniar_NuevaPregunta()
        {
            NuevaPregunta.Imagen = ServicioAzure.AlmacenarImagenEnLaNube(ServiceDialog.OpenFileDialog());
        }

        public void Examinar_GestionarPregunta()
        {
            PreguntaSeleccionada.Imagen = ServicioAzure.AlmacenarImagenEnLaNube(ServiceDialog.OpenFileDialog());
        }

        public void EliminarPregunta()
        {
            ListaPreguntas.Remove(PreguntaSeleccionada);
        }

        public void CargarJson()
        {
            ListaPreguntas = ServicioJson.LecturaJSON(ServiceDialog.OpenFileDialog());
        }

        public void GuardarJson()
        {
            string ruta = ServiceDialog.SaveFileDialog();
            ServicioJson.EscrituraJSON(ruta, ListaPreguntas);
        }

        public void NuevaPartida()
        {
            if (ListaPreguntas.Count != 0)
            {

                PreguntaActual = new Pregunta();
                Random semilla = new Random();
                int n = 0;


                FiltrarPreguntasDificultad(PartidaActual.DificultadPartida);
                n = semilla.Next(0, ListaPreg_Nivel.Count);
                PreguntaActual = ListaPreg_Nivel[n];


                /*do
                {
                    n = semilla.Next(0, ListaPreguntas.Count);

                    if (ListaPreguntas[n].Dificultad == PartidaActual.DificultadPartida)
                        PreguntaActual = ListaPreguntas[n];

                } while (PreguntaActual.Dificultad == null);*/
            }
            else
                serviceDialog.MostrarMensaje("No hay preguntas para poder empezar la partida");

        }

        public void Validar()
        {
            if (RespuestaUsu == PreguntaActual.Respuesta)
            {

            }
        }

        public void FiltrarPreguntasDificultad(string dificultad)
        {
            foreach (Pregunta item in ListaPreguntas)
            {
                if (item.Dificultad == dificultad)
                {
                    ListaPreg_Nivel.Add(item);
                }
            }
        }

        public void FiltrarPreguntasCategoria(ObservableCollection<Pregunta> lista)
        {
            /*foreach (Pregunta item in lista)
            {
                if (item.Categoria)
                {

                }
                ListaPreg_Categoria.Add(item);
            }*/
        }


    }
}
