using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Juego_de_preguntas.Servicios
{
    class ServicioDialogos
    {
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files |*.png;*.jpeg|" + "JSON files |*.json";
            openFileDialog.InitialDirectory = @"c:\temp\";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                   return openFileDialog.FileName;
            }
            return "";
        }

        public void SaveFileDialog(string ruta)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, ruta);
        }
    }
}
