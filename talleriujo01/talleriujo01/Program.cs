
using System;
using System.IO;

namespace talleriujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===taller 01 IUJO===");
			string registroUsuario = "ID_777; Davidlozada; Evaluacion;95";
				string[] partes = registroUsuario.Split(';');
			//* Uso el Split para pcar la cadena en pedazos donde vea un ';'
			
			string id=partes[0].Trim();
			string nombre=partes[1].Trim();
			string tarea=partes[2].Trim();
			string nota=partes[3].Trim();
			string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
			//Aquí guardo cada pedazo en su variable y uso Trim para quitar los espacios que sobran
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");
			
			if(!Directory.Exists(rutaraiz)){
				Directory.CreateDirectory(rutaraiz);
			}
			
			// Preparo el archivo de texto y uso el StreamWriter para escribir
			string archivotexto = Path.Combine(rutaraiz, "notas.txt");

			using (StreamWriter sw = new StreamWriter(archivotexto, true)) {			
				
			sw.WriteLine(string.Format("ID: {0} | Usuario: {1} | Nota: {2} | Fecha: {3}", id, nombre, nota, fechaHoy));
    }
			
			//Inicio del Desafio 1//

    // El dato para probar (Uso 'prueba' para que coincida con lo de abajo)
    string prueba = "DavidLozada;clave123"; 
    
    // Pico el nombre y la clave
    string[] pedazos = prueba.Split(';');
    string usuario = pedazos[0].Trim();
    string clave = pedazos[1].Trim();
    
    //Creo la variable fecha para que no de error
    string fecha = DateTime.Now.ToString("yyyy-MM-dd");

    // 4. El Contains busca si la clave tiene "123"
    if (clave.Contains("123")) {
        // Todo lo que use 'sw2' tiene que ir DENTRO de estas llaves
        using (StreamWriter sw2 = new StreamWriter("seguridad.txt", true)) {
            sw2.WriteLine(string.Format("Alerta: El usuario {0} tiene clave debil. Fecha: {1}", usuario, fecha));
        } // Aquí se cierra el archivo y sw2 deja de existir
        
        Console.WriteLine("(!) Se guardo la alerta en seguridad.txt");
    }

    //FIN DEL DESAFÍO 1
    
    //Inicio del Desafio 2
    int notafinal = int.Parse(nota);
    
    if(notafinal>=90) {
    	string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
    	string archivosobresalientes = Path.Combine(carpeta, "sobresalientes.txt");
    	
    	//Escribo los datos usando el sw3 para no confundirlo con los otros
    	using (StreamWriter sw3 = new StreamWriter(archivosobresalientes, true)) {
            sw3.WriteLine(string.Format("Alumno Destacado: {0} | notafinal: {1} | Fecha: {2}", nombre, notafinal, fecha));
        }
        
        Console.WriteLine("(!) Se guardo el registro del alumno sobresaliente.");
    }
 
    
    
    
    
    
    
    
    
    
    
			
			
			
			
			
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}