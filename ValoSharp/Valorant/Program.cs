using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Colorful;

namespace Valorant
{
	// Token: 0x02000006 RID: 6
	internal class Program
	{
		// Token: 0x06000033 RID: 51
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

		// Token: 0x06000034 RID: 52
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000035 RID: 53 RVA: 0x00007B70 File Offset: 0x00005D70
		[STAThread]
		private static void Main(string[] args)
		{
			Colorful.Console.Clear();
			System.Console.SetWindowSize(System.Console.LargestWindowWidth, System.Console.LargestWindowHeight);
			Program.ShowWindow(Program.ThisConsole, 3);
			Colorful.Console.Title = "valosharp ~ Login";
			Colorful.Console.Write("\n");
			Colorful.Console.Write("                    ██▒   █▓ ▄▄▄       ██▓     ▒█████    ██████  ██░ ██  ▄▄▄       ██▀███   ██▓███  \n", Color.Red);
			Colorful.Console.Write("                   ▓██░   █▒▒████▄    ▓██▒    ▒██▒  ██▒▒██    ▒ ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▓██░  ██▒\n", Color.Red);
			Colorful.Console.Write("                    ▓██  █▒░▒██  ▀█▄  ▒██░    ▒██░  ██▒░ ▓██▄   ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒▓██░ ██▓▒\n", Color.Red);
			Colorful.Console.Write("                     ▒██ █░░░██▄▄▄▄██ ▒██░    ▒██   ██░  ▒   ██▒░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ▒██▄█▓▒ ▒\n", Color.Red);
			Colorful.Console.Write("                      ▒▀█░   ▓█   ▓██▒░██████▒░ ████▓▒░▒██████▒▒░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒▒██▒ ░  ░\n", Color.Red);
			Colorful.Console.Write("                      ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒▓▒░ ░  ░\n", Color.Red);
			Colorful.Console.Write("                      ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒▓▒░ ░  ░\n", Color.Red);
			Colorful.Console.Write("                      ░ ░░    ▒   ▒▒ ░░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░ ▒ ░▒░ ░  ▒   ▒▒ ░  ░▒ ░ ▒░░▒ ░     \n", Color.Red);
			Colorful.Console.Write("                        ░░    ░   ▒     ░ ░   ░ ░ ░ ▒  ░  ░  ░   ░  ░░ ░  ░   ▒     ░░   ░ ░░       \n", Color.Red);
			Colorful.Console.Write("                        ░░    ░   ▒     ░ ░   ░ ░ ░ ▒  ░  ░  ░   ░  ░░ ░  ░   ▒     ░░   ░ ░░       \n", Color.Red);
			Colorful.Console.Write("                         ░        ░  ░    ░  ░    ░ ░        ░   ░  ░  ░      ░  ░   ░              \n", Color.Red);
			Colorful.Console.Write("                        ░                                                                           \n", Color.Red);
			Colorful.Console.Write("\n                                                   t.me/valosharp", Color.Purple);
			Colorful.Console.Write("\n");
			Colorful.Console.Write("\n");
			Colorful.Console.Write("\n");
			CheckerHelper.log_prefix();
			Colorful.Console.WriteLine("Connecting...");
			string currentDirectory = Environment.CurrentDirectory;
			Colorful.Console.WriteLine("");
			string contents = "Full cracked by Cabbo. Telegram: @cabboshiba";
			CheckerHelper.log_prefix();
			Colorful.Console.WriteLine("Full cracked by Cabbo <3");
			Colorful.Console.WriteLine("Telegram: @cabboshiba");
			File.WriteAllText(currentDirectory + "/LICENSE_KEY.txt", contents);
			CheckerHelper.Checker();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00007CE4 File Offset: 0x00005EE4
		public static DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00007D18 File Offset: 0x00005F18
		private static string random_string()
		{
			string text = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))).ToString();
			}
			return text;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000237B File Offset: 0x0000057B
		public Program()
		{
			Class1.MF9OXz();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000023C2 File Offset: 0x000005C2
		static Program()
		{
			Class1.MF9OXz();
			Program.ThisConsole = Program.GetConsoleWindow();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000023D3 File Offset: 0x000005D3
		internal static bool Mhb()
		{
			return Program.ghU == null;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void DhB()
		{
		}

		// Token: 0x0400003B RID: 59
		private static IntPtr ThisConsole;

		// Token: 0x0400003C RID: 60
		private const int HIDE = 0;

		// Token: 0x0400003D RID: 61
		private const int MAXIMIZE = 3;

		// Token: 0x0400003E RID: 62
		private const int MINIMIZE = 6;

		// Token: 0x0400003F RID: 63
		private const int RESTORE = 9;

		// Token: 0x04000040 RID: 64
		private static Program ghU;
	}
}
