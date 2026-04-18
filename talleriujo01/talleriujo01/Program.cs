using System;
using System.IO;

namespace talleriujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("=== Taller 01 IUJO - Registro y Desafios ===");
			
			//Registro de Alumnos
			
			string registroUsuario = "ID_777; Davidlozada; Evaluacion; 95";
			string[] partes = registroUsuario.Split(';');
			
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			if (!Directory.Exists(rutaraiz)) {
				Directory.CreateDirectory(rutaraiz);
			}
			
			string archivotexto = Path.Combine(rutaraiz, "notas.txt");
			using (StreamWriter sw = new StreamWriter(archivotexto, true)) {
				sw.WriteLine(string.Format("ID: {0} | Usuario: {1} | Nota: {2} | Fecha: {3}", id, nombre, nota, fechaHoy));
			}
			Console.WriteLine("(+) Alumno registrado con exito.");

			
			// DESAFIO 1: Validador de Seguridad 
			
			string pruebaSeguridad = "DavidLozada;clave123"; 
			string[] pedazos = pruebaSeguridad.Split(';');
			string clave = pedazos[1].Trim();

			if (clave.Contains("123")) {
				using (StreamWriter sw2 = new StreamWriter("seguridad.txt", true)) {
					sw2.WriteLine("Alerta: El usuario " + pedazos[0].Trim() + " tiene clave debil.");
				}
				Console.WriteLine("(!) Alerta de seguridad guardada en seguridad.txt");
			}

			
			//DESAFIO 2: Clonador de Imagen
			
			string origen = "avatar.jpg";
			string destino = "respaldo.jpg";

			if (File.Exists(origen)) {
				using (FileStream fsIn = new FileStream(origen, FileMode.Open))
				using (FileStream fsOut = new FileStream(destino, FileMode.Create)) {
					byte[] balde = new byte[1024]; 
					int leido;

					while ((leido = fsIn.Read(balde, 0, balde.Length)) > 0) {
						fsOut.Write(balde, 0, leido);
					}
				}
				Console.WriteLine("(+) Imagen clonada byte a byte.");
			} else {
				Console.WriteLine("(!) No se encontro avatar.jpg para clonar.");
			}

			
			//DESAFIO 3: Buscador de Archivos Pesados
			
			string rutaCarpeta = AppDomain.CurrentDomain.BaseDirectory;
			string[] misArchivos = Directory.GetFiles(rutaCarpeta);

			foreach (string archivo in misArchivos) {
				FileInfo f = new FileInfo(archivo);
				// Si pesa mas de 5KB y no es el codigo ni el ejecutable, se borra
				if (f.Length > 5120 && !archivo.EndsWith(".exe") && !archivo.EndsWith(".cs")) {
					File.Delete(archivo);
					Console.WriteLine("(-) Archivo borrado por pesado: " + f.Name);
				}
			}

			Console.WriteLine("\n=== Todo listo ===");
			Console.Write("Presione una tecla para salir...");
			Console.ReadKey(true);
		}
	}
}
}
