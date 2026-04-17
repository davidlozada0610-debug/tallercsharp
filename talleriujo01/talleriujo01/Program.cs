
using System;
using System.IO;

namespace talleriujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===taller01 ===");
			
			
			// 1. El dato del usuario
			string registroUsuario = "    ID_777;  DavidLozada  ;  Evaluacion;    95";
			
			Console.WriteLine(registroUsuario);
			string registroLimpio = registroUsuario.Trim();
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes [2].Trim();
			string nota = partes [3].Trim();
			
			Console.WriteLine(string.Format("el id es: {0} del usuario {1} con la nota {2}", id,nombre,nota));
			
			
			//flujo en archivos  
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");
			
			if(!Directory.Exists("rutaraiz")){
				Directory.CreateDirectory("rutaraiz");
				Console.WriteLine("Creado Directorio Correctamente");
			}
			
			string archivotexto = Path.Combine(rutaraiz,"notas.txt");
			Console.WriteLine(archivotexto);
			
			using( 
			      StreamWriter sw = new StreamWriter(archivotexto,true)){
			
				sw.WriteLine(string.Format("ID : {0} nota {1}  {yyyy-MM-dd HH:mm}",id,nota,DateTime.Now));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}