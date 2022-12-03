﻿using Juego_de_preguntas.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Juego_de_preguntas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM vm = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Examinar_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            vm.Examniar(boton.Tag.ToString());
        }

        private void AñadirPregunta_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirPregunta();
        }

        private void LimpiarFormulario_Click(object sender, RoutedEventArgs e)
        {
            vm.LimpiarFormulario();
        }
    }
}
