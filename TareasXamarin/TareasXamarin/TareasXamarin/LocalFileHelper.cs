using System;
using System.IO;
using Xamarin.Forms;

[assembly :Dependency(typeof(TareasXamarin.LocalFileHelper))]

namespace TareasXamarin
{
    class LocalFileHelper : ILocalFileHelper
    {
        // Implementamos la clase LocalFileHelper empleando la interfaz previamente construida
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // Ruta completa donde se guardarán las BD internamente en nuestro dispositivo
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            // En caso de que el directorio creado para guardar las BD no exista ya
            if (!Directory.Exists(libFolder))
            {
                // Creamos el directorio especificado en libFolder
                Directory.CreateDirectory(libFolder);
            }
            /*else
            {
                Directory.Delete(libFolder, true);
                Directory.CreateDirectory(libFolder);
            }*/

            // En ambos casos devuelve la ruta especificada
            return Path.Combine(libFolder, fileName);

        }
    }
}
