using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Colorful;
using KeyAuth;

namespace Valorant
{
	// Token: 0x02000011 RID: 17
	internal class Program
	{
		// Token: 0x060000CA RID: 202
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

		// Token: 0x060000CB RID: 203
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x060000CC RID: 204 RVA: 0x00009C84 File Offset: 0x00007E84
		[STAThread]
		private static void Main(string[] args)
		{
			Console.Clear();
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			Program.ShowWindow(Program.ThisConsole, 3);
			Console.Title = "valosharp ~ Login";
			Console.Write("\n");
			Console.Write("                    ██▒   █▓ ▄▄▄       ██▓     ▒█████    ██████  ██░ ██  ▄▄▄       ██▀███   ██▓███  \n", Color.Red);
			Console.Write("                   ▓██░   █▒▒████▄    ▓██▒    ▒██▒  ██▒▒██    ▒ ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▓██░  ██▒\n", Color.Red);
			Console.Write("                    ▓██  █▒░▒██  ▀█▄  ▒██░    ▒██░  ██▒░ ▓██▄   ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒▓██░ ██▓▒\n", Color.Red);
			Console.Write("                     ▒██ █░░░██▄▄▄▄██ ▒██░    ▒██   ██░  ▒   ██▒░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ▒██▄█▓▒ ▒\n", Color.Red);
			Console.Write("                      ▒▀█░   ▓█   ▓██▒░██████▒░ ████▓▒░▒██████▒▒░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒▒██▒ ░  ░\n", Color.Red);
			Console.Write("                      ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒▓▒░ ░  ░\n", Color.Red);
			Console.Write("                      ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░▒▓▒░ ░  ░\n", Color.Red);
			Console.Write("                      ░ ░░    ▒   ▒▒ ░░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░ ▒ ░▒░ ░  ▒   ▒▒ ░  ░▒ ░ ▒░░▒ ░     \n", Color.Red);
			Console.Write("                        ░░    ░   ▒     ░ ░   ░ ░ ░ ▒  ░  ░  ░   ░  ░░ ░  ░   ▒     ░░   ░ ░░       \n", Color.Red);
			Console.Write("                        ░░    ░   ▒     ░ ░   ░ ░ ░ ▒  ░  ░  ░   ░  ░░ ░  ░   ▒     ░░   ░ ░░       \n", Color.Red);
			Console.Write("                         ░        ░  ░    ░  ░    ░ ░        ░   ░  ░  ░      ░  ░   ░              \n", Color.Red);
			Console.Write("                        ░                                                                           \n", Color.Red);
			Console.Write("\n                                                   t.me/valosharp", Color.Purple);
			Console.Write("\n");
			Console.Write("\n");
			Console.Write("\n");
			CheckerHelper.log_prefix();
			Console.WriteLine("Connecting...");
			Program.KeyAuthApp.init();
			string currentDirectory = Environment.CurrentDirectory;
			Program.autoUpdate();
			CheckerHelper.log_prefix();
			Console.WriteLine("Registered users: " + Program.KeyAuthApp.app_data.numUsers);
			CheckerHelper.log_prefix();
			Console.WriteLine("Current version: " + Program.KeyAuthApp.app_data.version);
			CheckerHelper.log_prefix();
			Console.WriteLine("");
			string text;
			if (File.Exists(currentDirectory + "/LICENSE_KEY.txt"))
			{
				text = File.ReadAllText(currentDirectory + "/LICENSE_KEY.txt");
			}
			else
			{
				CheckerHelper.log_prefix();
				Console.Write("Please enter your license key: ");
				text = Console.ReadLine();
			}
			Program.KeyAuthApp.license(text);
			CheckerHelper.log_prefix();
			if (!Program.KeyAuthApp.response.success)
			{
				Console.WriteLine();
				File.Delete(currentDirectory + "/LICENSE_KEY.txt");
				CheckerHelper.log_prefix();
				Console.WriteLine(Program.KeyAuthApp.response.message);
				Thread.Sleep(3000);
				Program.Main(args);
				return;
			}
			Console.WriteLine("Welcome back, " + Program.KeyAuthApp.user_data.username);
			CheckerHelper.log_prefix();
			Console.WriteLine("Your IP Address: " + Program.KeyAuthApp.user_data.ip);
			CheckerHelper.log_prefix();
			Console.WriteLine("Your subscription(s): ");
			for (int i = 0; i < Program.KeyAuthApp.user_data.subscriptions.Count; i++)
			{
				CheckerHelper.log_prefix();
				Console.WriteLine(string.Format("Subscription name: {0} - Expires at: {1}", Program.KeyAuthApp.user_data.subscriptions[i].subscription, Program.UnixTimeToDateTime(long.Parse(Program.KeyAuthApp.user_data.subscriptions[i].expiry))));
			}
			Program.KeyAuthApp.check();
			File.WriteAllText(currentDirectory + "/LICENSE_KEY.txt", text);
			Thread.Sleep(3000);
			CheckerHelper.Checker();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00009FAC File Offset: 0x000081AC
		public static DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000274F File Offset: 0x0000094F
		private static void autoUpdate()
		{
			if (Program.KeyAuthApp.response.message == "invalidver")
			{
				MessageBox.Show("New update available");
				Process.Start(Program.KeyAuthApp.app_data.downloadLink);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00009FE0 File Offset: 0x000081E0
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

		// Token: 0x060000D0 RID: 208 RVA: 0x000022F6 File Offset: 0x000004F6
		public Program()
		{
			Class1.MF9OXz();
			base..ctor();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000278C File Offset: 0x0000098C
		static Program()
		{
			Class1.MF9OXz();
			Program.KeyAuthApp = new api("valosharp", "NNTqYBUMO9", "813a6312f1ae5af11dcd302edaeb50cbff9deb25b73055930d1fe66527fcbd34", "2.00");
			Program.ThisConsole = Program.GetConsoleWindow();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000027BB File Offset: 0x000009BB
		internal static bool Mhb()
		{
			return Program.ghU == null;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void DhB()
		{
		}

		// Token: 0x0400007D RID: 125
		public static api KeyAuthApp;

		// Token: 0x0400007E RID: 126
		private static IntPtr ThisConsole;

		// Token: 0x0400007F RID: 127
		private const int HIDE = 0;

		// Token: 0x04000080 RID: 128
		private const int MAXIMIZE = 3;

		// Token: 0x04000081 RID: 129
		private const int MINIMIZE = 6;

		// Token: 0x04000082 RID: 130
		private const int RESTORE = 9;

		// Token: 0x04000083 RID: 131
		private static Program ghU;
	}
}
