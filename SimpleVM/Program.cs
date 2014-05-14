using System;
using System.IO;
using System.Reflection;

namespace SimpleVM
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				ShowUsage();
				return;
			}

			var programData = TryLoadFile(Path.GetFullPath(args[0]));
			if (programData == null)
			{
				Console.WriteLine("Could not load program file");
				Console.WriteLine("Make sure it exists and is not locked by other process");
				return;
			}

			var inputData = TryLoadFile(Path.GetFullPath(args[1]));
			if (inputData == null)
			{
				Console.WriteLine("Could not load input file");
				Console.WriteLine("Make sure it exists and is not locked by other process");
				return;
			}

			var input = new Input(inputData);
			var output = new Output();
			var memory = new Memory();
			memory.Load(programData);

			var cpu = new Cpu(memory, input, output);

			while ((cpu.Flags & 2) != 2)
			{
				cpu.Tick();
			}
		}

		private static byte[] TryLoadFile(string path)
		{
			try
			{
				return File.ReadAllBytes(path);
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static void ShowUsage()
		{
			Console.WriteLine("Program usage:\r\n");
			Console.WriteLine("{0} <program> <input>\r\n", Assembly.GetExecutingAssembly().GetName().Name);
			Console.WriteLine("where:");
			Console.WriteLine("   <program> - path to a program file to execute");
			Console.WriteLine("   <input>   - path to a file for program input");
		}
	}
}
