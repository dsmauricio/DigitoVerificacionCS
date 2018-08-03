using System;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{
		var dh = new DianHelper();
		Console.WriteLine(dh.CalcularDv("1166745514481"));
		Console.WriteLine(dh.CalcularDv("1166745514482"));
		Console.WriteLine(dh.CalcularDv("1166745514483"));
		Console.WriteLine(dh.CalcularDv("1166745514484"));
		Console.WriteLine(dh.CalcularDv("1166745514485"));
		Console.WriteLine(dh.CalcularDv("1166745514486"));
		Console.WriteLine(dh.CalcularDv("1166745514487"));
		Console.WriteLine(dh.CalcularDv("1166745514488"));
		Console.WriteLine(dh.CalcularDv("1166745514489"));
		Console.WriteLine(dh.CalcularDv("1166745514490"));
	}
	
	
}

public class DianHelper
{
	public int CalcularDv( string numero )
	{
		int[] primos = new int[] {3,7,13,17,19,23,29,37,41,43,47,53,59,67,71};

		// Hacemos limpieza preliminar del string de entrada, quitamos puntos, comas y guiones.
        var cleanNum = numero.Replace(",","").Replace(".","").Replace("-","");
		
        // Verificamos que todos los caracteres sean digitos.
		if (!Regex.IsMatch(cleanNum, @"^\d+$"))
		{
			throw new Exception("No es un número válido");
		}
		
		var largoArreglo = primos.Length;
		var posicion = 1;
		var valorAcumulado = 0;
		
		foreach( char c in cleanNum.PadLeft(largoArreglo, '0'))
		{
			valorAcumulado += Convert.ToInt32(c.ToString()) * primos[largoArreglo - posicion++];
		}
		
		var valorModulo = valorAcumulado % 11;
		var valorARetornar = (valorModulo>1) ? 11 - valorModulo : valorModulo;
		
		return valorARetornar;
		
	}
}