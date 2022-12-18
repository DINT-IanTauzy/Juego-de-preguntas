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

        private ObservableCollection<Pregunta> listaPreg_Partida;
        public ObservableCollection<Pregunta> ListaPreg_Partida
        {
            get { return listaPreg_Partida; }
            set { SetProperty(ref listaPreg_Partida, value); }
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

        private int posicionPreguntaPartida;
        public int PosicionPreguntaPartida
        {
            get { return posicionPreguntaPartida; }
            set { SetProperty(ref posicionPreguntaPartida, value); }
        }


        private bool categoria_Armas;
        public bool Categoria_Armas
        {
            get { return categoria_Armas; }
            set { SetProperty(ref categoria_Armas, value); }
        }

        private bool categoria_Mapas;
        public bool Categoria_Mapas
        {
            get { return categoria_Mapas; }
            set { SetProperty(ref categoria_Mapas, value); }
        }

        private bool categoria_Personajes;
        public bool Categoria_Personajes
        {
            get { return categoria_Personajes; }
            set { SetProperty(ref categoria_Personajes, value); }
        }

        private bool categoria_Habilidades;
        public bool Categoria_Habilidades
        {
            get { return categoria_Habilidades; }
            set { SetProperty(ref categoria_Habilidades, value); }
        }

        public MainWindowVM()
        {
            PreguntaSeleccionada = new Pregunta();
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
            RespuestaUsu = "";
            PartidaActual.DificultadPartida = "Facil";
            PartidaActual.PartidaEnJuego = false;
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
        public void ReiniciarCategorias()
        {
            Categoria_Armas = false;
            Categoria_Habilidades = false;
            Categoria_Mapas = false;
            Categoria_Personajes = false;
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
                ListaPreg_Partida = new ObservableCollection<Pregunta>();
                PreguntaActual = new Pregunta();
                ListaPreg_Nivel.Clear();
                PartidaActual.PartidaEnJuego = true;
                

                FiltrarPreguntasDificultad(PartidaActual.DificultadPartida);
                foreach (Pregunta item in ListaPreg_Nivel)
                    ListaPreg_Partida.Add(item);

                GeneraPregunta();
            }
            else
                serviceDialog.MostrarMensaje("No hay preguntas para poder empezar la partida", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

        }

        public void Validar()
        {
            if (RespuestaUsu == PreguntaActual.Respuesta)
            {
                switch (PreguntaActual.Categoria)
                {
                    case "Habilidades":
                        Categoria_Habilidades = true;
                        break;
                    case "Personajes":
                        Categoria_Personajes = true;
                        break;
                    case "Mapas":
                        Categoria_Mapas = true;
                        break;
                    case "Armas":
                        Categoria_Armas = true;
                        break;
                }
                ListaPreg_Partida.Remove(PreguntaActual);

                if (Categoria_Armas && Categoria_Habilidades && Categoria_Mapas && Categoria_Personajes)
                {
                    serviceDialog.MostrarMensaje("Enhorabuena!! Has ganado","WIN!!",System.Windows.MessageBoxButton.OK,System.Windows.MessageBoxImage.Information);
                    PreguntaActual = new Pregunta();
                    RespuestaUsu = "";
                    ReiniciarCategorias();
                    PartidaActual.PartidaEnJuego = false;
                }
                else
                   GeneraPregunta();
            }
        }

        public void GeneraPregunta()
        {
            RespuestaUsu = "";
            Random semilla = new Random();
            PosicionPreguntaPartida = 0;
            PosicionPreguntaPartida = semilla.Next(0, ListaPreg_Partida.Count);
            PreguntaActual = ListaPreg_Partida[PosicionPreguntaPartida];
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

    }
}
