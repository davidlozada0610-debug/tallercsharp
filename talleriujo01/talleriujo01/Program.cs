using System;
using System.IO;

namespace talleriujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Taller 01 IUJO"); 
			
			
			string registroUsuario = "ID_777; Davidlozada; Evaluacion; 95";
			string[] partes = registroUsuario.Split(';'); // Pico la cadena donde vea el ';'
			
			string identificador = partes[0].Trim();
			string nombreAlumno = partes[1].Trim();
			string notaFinal = partes[3].Trim();
			string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
			
			// Si no existe la carpeta, la creo de una vez
			string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			if (!Directory.Exists(rutaCarpeta)) {
				Directory.CreateDirectory(rutaCarpeta);
			}
			
			// Guardo los datos 
			string rutaArchivoTexto = Path.Combine(rutaCarpeta, "notas.txt");
			using (StreamWriter escribirNotas = new StreamWriter(rutaArchivoTexto, true)) {
				escribirNotas.WriteLine(string.Format("ID: {0} | Usuario: {1} | Nota: {2} | Fecha: {3}", identificador, nombreAlumno, notaFinal, fechaActual));
			}
			Console.WriteLine("(+) Alumno registrado con exito.");

			
			//DESAFIO 1: Clave Debil
			
			string datosPrueba = "DavidLozada;clave123"; 
			string[] pedazos = datosPrueba.Split(';');
			string claveUsuario = pedazos[1].Trim();

			// Si la clave tiene 123, guardo el aviso en un archivo aparte
			if (claveUsuario.Contains("123")) {
				using (StreamWriter escribirSeguridad = new StreamWriter("seguridad.txt", true)) {
					escribirSeguridad.WriteLine("Alerta: El usuario " + pedazos[0].Trim() + " tiene clave debil.");
				}
				Console.WriteLine("(!) Alerta de seguridad guardada.");
			}

			
			//DESAFIO 2: Clonar Foto
			
			string fotoOriginal = "avatar.jpg";
			string fotoCopia = "respaldo.jpg";

			if (File.Exists(fotoOriginal)) {
				using (FileStream leerFoto = new FileStream(fotoOriginal, FileMode.Open))
				using (FileStream escribirFoto = new FileStream(fotoCopia, FileMode.Create)) {
					
					byte[] balde = new byte[1024]; // Llevamos los datos por pedazos
					int leido;

					// Mientras lea algo de la original, lo mando a la copia
					while ((leido = leerFoto.Read(balde, 0, balde.Length)) > 0) {
						escribirFoto.Write(balde, 0, leido);
					}
				}
				Console.WriteLine("(+) La foto se clono byte a byte.");
			} else {
				Console.WriteLine("(!) No hay foto para copiar.");
			}

			
			//DESAFIO 3: Borrar Archivos Pesados
			
			string dondeEstoy = AppDomain.CurrentDomain.BaseDirectory;
			string[] archivosEncontrados = Directory.GetFiles(dondeEstoy);

			foreach (string arc in archivosEncontrados) {
				FileInfo info = new FileInfo(arc);
				
				// Si pesa mas de 5KB y no es el codigo, lo borro
				if (info.Length > 5120 && !arc.EndsWith(".exe") && !arc.EndsWith(".cs")) {
					File.Delete(arc);
					Console.WriteLine("[-] Archivo borrado: " + info.Name);
				}
			}

			Console.WriteLine("\n=== Todo listo ===");
			Console.Write("Presione una tecla para salir...");
			Console.ReadKey(true);
			
		}
	}
}
