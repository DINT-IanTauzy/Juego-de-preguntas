using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.Servicios
{
    class ServicioAzureBlobStorage
    {
        private const string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialian;AccountKey=Kv7OsdziSGsW7qGZxfQgJswiqT/BhhqmCbrumbD67yohiH8upcFb3/+RSeK8Mxk8zfffITr0xtDp+AStJuSB7g==;EndpointSuffix=core.windows.net";
        private readonly string nombreContenedorBlobs = "trivial";
        
        public string AlmacenarImagenEnLaNube(string rutaImagen)
        {
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            Stream streamImagen = File.OpenRead(rutaImagen);
            string nombreImagen = Path.GetFileName(rutaImagen);
            clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            return clienteBlobImagen.Uri.AbsoluteUri;


        }
    }
}
