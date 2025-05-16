using System;
using System.Text;

namespace Security.CarlosSuaza.Encode
{
    public class CarlosSuazaEncode
    {
        public static string CodificarCarlosSuaza(string plaintext)
        {
			string alfabeto;
			int i;
			int j;
			string mensajeentrada;
			string mensajematrizsustitucionsalida;
			string mensajematrizsustituciontransposicionsalida;
			int tamanoalfabeto;
			int tamanomensajeentrada;
			double valordinamico;
			// -----------------------------------------------------//
			// T0	
			// 1. Definicion de Variables
			// 2 Entrada de Datos
			//Console.WriteLine("Ingrese Mensaje");
			//mensajeentrada = Console.ReadLine();
            mensajeentrada = plaintext;
            
			tamanomensajeentrada = mensajeentrada.Length;
			Console.WriteLine("Mensaje de Entrada: "+mensajeentrada);
			Console.WriteLine("Tamaño Mensaje Entrada: "+tamanomensajeentrada);
			// 3. Dimensionamiento de Vectores
			string[] matrizmensajeentrada = new string[tamanomensajeentrada];
			string[] matrizmensajecifradosustitucion = new string[tamanomensajeentrada];
			string[] matrizmensajecifradosustituciontransposicion = new string[tamanomensajeentrada];
			string[] matrizmensajedecifradosustitucion = new string[tamanomensajeentrada];
			string[] matrizmensajedecifradosustituciontransposicion = new string[tamanomensajeentrada];
			// 4. Poblar Vector Mensaje Original
			i = 1;
			while (i<=tamanomensajeentrada) {
				matrizmensajeentrada[i-1] = mensajeentrada.Substring(i-1, i-i+1);
				i = i+1;
			}
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
			// T1
			// 6. Proceso Cifrado Sustitucion
			for (i=1; i<=tamanomensajeentrada; ++i) {
				for (j=1; j<=tamanoalfabeto; ++j) {
					if (matrizmensajeentrada[i-1].Equals(matrizalfabeto[0,j-1])) {
						matrizmensajecifradosustitucion[i-1] = matrizalfabeto[1,j-1];
					}
				}
			}
			// 7. Imprimir Cifrado Sustitucion
			i = 1;
			mensajematrizsustitucionsalida = "";
			while (i<=tamanomensajeentrada) {
				mensajematrizsustitucionsalida = mensajematrizsustitucionsalida+"@"+matrizmensajecifradosustitucion[i-1];
				i = i+1;
			}
			mensajematrizsustitucionsalida = mensajematrizsustitucionsalida+"@";
			Console.WriteLine("Mensaje Salida Cifrado Sustitucion: "+mensajematrizsustitucionsalida);
			// 8. Proceso Cifrado Transposicion
			i = tamanomensajeentrada;
			j = 1;
			while (i!=0) {
				matrizmensajecifradosustituciontransposicion[j-1] = matrizmensajecifradosustitucion[i-1];
				i = i-1;
				j = j+1;
			}
			// Para i <- tamañomensajeentrada Hasta 0 Con Paso -1 Hacer
			// matrizmensajesustituciontransposicion[j] <- matrizmensajesustitucion[i]
			// j<- j + 1
			// Fin Para
			// 9. Imprimir Cifrado Transposicion
			i = 1;
			mensajematrizsustituciontransposicionsalida = "";
			while (i<=tamanomensajeentrada) {
				mensajematrizsustituciontransposicionsalida = mensajematrizsustituciontransposicionsalida+"@"+matrizmensajecifradosustituciontransposicion[i-1];
				i = i+1;
			}
			mensajematrizsustituciontransposicionsalida = mensajematrizsustituciontransposicionsalida+"@";
			Console.WriteLine("Mensaje Salida Cifrado Sustitucion y Transposicion: "+mensajematrizsustituciontransposicionsalida);
            
            return mensajematrizsustituciontransposicionsalida;
        }
    }
}