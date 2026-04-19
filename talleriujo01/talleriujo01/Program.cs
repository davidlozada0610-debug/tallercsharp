
using System;
using System.IO;

namespace talleriujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("=== Taller 01 IUJO - David Lozada ==="); 
			
			// --- REGISTRO DE DATOS ---
			string registroUsuario = "ID_777; DavidLozada; Evaluacion; 95";
			string[] partes = registroUsuario.Split(';');
			
			string identificador = partes[0].Trim();
			string nombreAlumno = partes[1].Trim();
			string notaFinal = partes[3].Trim();
			string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
			
			// Crear carpeta para los datos
			string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			if (!Directory.Exists(rutaCarpeta)) {
				Directory.CreateDirectory(rutaCarpeta);
			}
			
			// Guardar el registro en un bloc de notas
			string rutaArchivoTexto = Path.Combine(rutaCarpeta, "notas.txt");
			using (StreamWriter escribirNotas = new StreamWriter(rutaArchivoTexto, true)) {
				escribirNotas.WriteLine("ID: " + identificador + " | Alumno: " + nombreAlumno + " | Nota: " + notaFinal);
			}
			Console.WriteLine("(+) Alumno registrado con exito.");

			
			// --- DESAFIO 1: SEGURIDAD (Clave Debil) ---
			string datosClave = "DavidLozada;clave123"; 
			string[] pedazos = datosClave.Split(';');
			string clave = pedazos[1].Trim();

			if (clave.Contains("123")) {
				using (StreamWriter escribirSeg = new StreamWriter("seguridad.txt", true)) {
					escribirSeg.WriteLine("Alerta: El usuario " + pedazos[0].Trim() + " tiene una clave insegura.");
				}
				Console.WriteLine("(!) Alerta de seguridad guardada en seguridad.txt");
			}

			
			// --- DESAFIO 2: CLONAR FOTO (Byte a Byte) ---
			string original = "avatar.jpg";
			string copia = "respaldo.jpg";

			if (File.Exists(original)) {
				using (FileStream leer = new FileStream(original, FileMode.Open))
				using (FileStream escribir = new FileStream(copia, FileMode.Create)) {
					byte[] balde = new byte[1024];
					int cantidadLeida;

					while ((cantidadLeida = leer.Read(balde, 0, balde.Length)) > 0) {
						escribir.Write(balde, 0, cantidadLeida);
					}
				}
				Console.WriteLine("(+) La foto se clono correctamente.");
			} else {
				Console.WriteLine("(!) No se encontro 'avatar.jpg', se salto este paso.");
			}

			
			// --- DESAFIO 3: LIMPIEZA (Borrar archivos pesados) ---
			string rutaActual = AppDomain.CurrentDomain.BaseDirectory;
			string[] listaArchivos = Directory.GetFiles(rutaActual);

			foreach (string archivo in listaArchivos) {
				FileInfo info = new FileInfo(archivo);
				
				// Solo miramos fotos o textos para evitar errores de Windows
				if (archivo.EndsWith(".txt") || archivo.EndsWith(".jpg")) {
					// Si pesa mas de 5KB (5120 bytes), se borra
					if (info.Length > 5120) {
						File.Delete(archivo);
						Console.WriteLine("[-] Archivo pesado borrado: " + info.Name);
					}
				}
			}

			Console.WriteLine("\n=== PROCESO TERMINADO ===");
			Console.WriteLine("Presione cualquier tecla para salir...");
			Console.ReadKey(true);
		}
	}
}
