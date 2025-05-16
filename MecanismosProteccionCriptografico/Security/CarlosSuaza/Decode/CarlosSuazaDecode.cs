using System;
using System.Text;

namespace Security.CarlosSuaza.Decode
{
    public class CarlosSuazaDecode
    {
        public static string DecodificarCarlosSuaza(string encodedtext)
        {
			string alfabeto;
			int i;
			int indice;
			int inicio;
			int j;
			string mensajeentrada;
			string mensajeentradacifradooriginal;
			string mensajematrizdecifradosustituciontransposicionsalida;
			string mensajematrizsustitucionsalida;
			int tamanoalfabeto;
			int tamanomensajeentrada;
			double valordinamico;
			// -----------------------------------------------------//
			// T0	
			// 1. Definicion de Variables
			// 2 Entrada de Datos
			//Console.WriteLine("Ingrese Mensaje");
			// Hola
			// @71764072@71764083@71764086@71764053@
			mensajeentrada = encodedtext;

			tamanomensajeentrada = mensajeentrada.Length;
			Console.WriteLine("Mensaje de Entrada: "+mensajeentrada);
			Console.WriteLine("Tamaño Mensaje Entrada: "+tamanomensajeentrada);
			// 3. Dimensionamiento de Vectores
			
			string[] matrizmensajecifradosustitucion = new string[tamanomensajeentrada];
			string[] matrizmensajecifradosustituciontransposicion = new string[tamanomensajeentrada];
			string[] matrizmensajedecifradosustitucion = new string[tamanomensajeentrada];
			string[] matrizmensajedecifradosustituciontransposicion = new string[tamanomensajeentrada];
			// 4. Poblar Vector Mensaje Original
			// i<-1
			// Mientras i <= tamañomensajeentrada Hacer
			// matrizmensajeentrada[i] <- SubCadena(mensajeentrada,i,i)
			// i <- i + 1
			// Fin Mientras
			// 4. Poblar Vector Mensaje Original
			/*
			i = 1;
			inicio = 1;
			indice = 0;
			for (i=1; i<=tamanomensajeentrada; ++i) {
				if (mensajeentrada.Substring(i-1, i-i+1).Equals("@")) {
					if (inicio<i) {
						indice = indice+1;
						string[] matrizmensajeentrada = new string[indice];
						matrizmensajeentrada[indice-1] = mensajeentrada.Substring(inicio-1, i-6inicio);
					}
					inicio = i+1;
				}
			}
			*/
			string[] matrizmensajeentrada = mensajeentrada.Split('@', StringSplitOptions.RemoveEmptyEntries);
			indice = matrizmensajeentrada.Length;

			Console.WriteLine("Indice: "+indice);
			// 7. Imprimir Matriz Mensaje Entrada
			i = 1;
			mensajeentradacifradooriginal = "";
			while (i<=indice) {
				mensajeentradacifradooriginal = mensajeentradacifradooriginal+"-"+matrizmensajeentrada[i-1];
				i = i+1;
			}
			mensajeentradacifradooriginal = mensajeentradacifradooriginal+"-";
			Console.WriteLine("Mensaje Entrada Cifrado Original: "+mensajeentradacifradooriginal);
			// 5. Poblar Matriz Equivalencias
			alfabeto = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÁÉÍÓÚáéíóúÜüÑñÇç¡¿1234567890!@#$%^&*()_+-=[]{}|;:,.<>/?`~";
			tamanoalfabeto = alfabeto.Length;
			string[,] matrizalfabeto = new string[2,tamanoalfabeto];
			for (i=1; i<=tamanoalfabeto; ++i) {
				matrizalfabeto[0,i-1] = alfabeto.Substring(i-1, i-i+1);
				valordinamico = i+71764044;
				matrizalfabeto[1,i-1] = Convert.ToString(valordinamico);
			}
			// -----------------------------------------------------//
			// T2
			// 11. Proceso Decifrado Transposicion
			i = indice;
			j = 1;
			while (i!=0) {
				matrizmensajedecifradosustituciontransposicion[j-1] = matrizmensajeentrada[i-1];
				i = i-1;
				j = j+1;
			}
			// 12. Imprimir Decifrado Transposicion
			i = 1;
			mensajematrizdecifradosustituciontransposicionsalida = "";
			while (i<=indice) {
				mensajematrizdecifradosustituciontransposicionsalida = mensajematrizdecifradosustituciontransposicionsalida+"@"+matrizmensajedecifradosustituciontransposicion[i-1];
				i = i+1;
			}
			mensajematrizdecifradosustituciontransposicionsalida = mensajematrizdecifradosustituciontransposicionsalida+"@";
			Console.WriteLine("Mensaje Salida Decifrado Sustitucion y Transposicion: "+mensajematrizdecifradosustituciontransposicionsalida);
			// 13. Proceso Decifrado Sustitucion
			for (i=1; i<=indice; ++i) {
				for (j=1; j<=tamanoalfabeto; ++j) {
					if (matrizmensajedecifradosustituciontransposicion[i-1].Equals(matrizalfabeto[1,j-1])) {
						matrizmensajedecifradosustitucion[i-1] = matrizalfabeto[0,j-1];
					}
				}
			}
			// 14. Imprimir Decifrado Sustitucion
			i = 1;
			mensajematrizsustitucionsalida = "";
			while (i<=indice) {
				mensajematrizsustitucionsalida = mensajematrizsustitucionsalida+matrizmensajedecifradosustitucion[i-1];
				i = i+1;
			}
			Console.WriteLine("Mensaje Salida Decifrado Sustitucion y Transposicion: "+mensajematrizsustitucionsalida);

			return mensajematrizsustitucionsalida;
        }
    }
}