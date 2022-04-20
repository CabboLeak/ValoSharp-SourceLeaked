using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Colorful;

namespace Valorant_Checker.Miscellaneous
{
	// Token: 0x02000002 RID: 2
	internal static class Utils
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000245C File Offset: 0x0000065C
		public static string LRParse(string data, string lS, string rS, bool recursive = false, bool useRegexLR = false)
		{
			string text = data;
			string result;
			if (lS == "" && rS == "")
			{
				result = data;
			}
			else if ((!text.Contains(lS) && lS != "") || (!text.Contains(rS) && rS != ""))
			{
				result = "";
			}
			else
			{
				string text2 = null;
				if (recursive)
				{
					if (useRegexLR)
					{
						try
						{
							string pattern = Utils.BuildLRPattern(lS, rS);
							foreach (object obj in Regex.Matches(text, pattern))
							{
								text2 = ((Match)obj).Value;
							}
							return text2;
						}
						catch
						{
							return text2;
						}
					}
					string result2;
					try
					{
						for (;;)
						{
							if (!text.Contains(lS))
							{
								if (!(lS == ""))
								{
									break;
								}
							}
							if (!text.Contains(rS) && !(rS == ""))
							{
								break;
							}
							int startIndex = (lS == "") ? 0 : (text.IndexOf(lS) + lS.Length);
							text = text.Substring(startIndex);
							int length = (!(rS == "")) ? text.IndexOf(rS) : (text.Length - 1);
							text2 = text.Substring(0, length);
							text = text.Substring(text2.Length + rS.Length);
						}
						result2 = text2;
					}
					catch
					{
						result2 = text2;
					}
					return result2;
				}
				if (useRegexLR)
				{
					string pattern2 = Utils.BuildLRPattern(lS, rS);
					MatchCollection matchCollection = Regex.Matches(text, pattern2);
					if (matchCollection.Count > 0)
					{
						text2 = matchCollection[0].Value;
					}
				}
				else
				{
					try
					{
						int startIndex2 = (!(lS == "")) ? (text.IndexOf(lS) + lS.Length) : 0;
						text = text.Substring(startIndex2);
						int length2 = (rS == "") ? text.Length : text.IndexOf(rS);
						text2 = text.Substring(0, length2);
					}
					catch
					{
					}
				}
				result = text2;
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000026A4 File Offset: 0x000008A4
		public static string BuildLRPattern(string ls, string rs)
		{
			string text = string.IsNullOrEmpty(ls) ? "^" : Regex.Escape(ls);
			string text2 = string.IsNullOrEmpty(rs) ? "$" : Regex.Escape(rs);
			return string.Concat(new string[]
			{
				"(?<=",
				text,
				").+?(?=",
				text2,
				")"
			});
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002708 File Offset: 0x00000908
		public static void centerText(string text)
		{
			System.Console.WriteLine(string.Format("{0," + (System.Console.WindowWidth / 2 + text.Length / 2).ToString() + "}", text));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022DA File Offset: 0x000004DA
		public static string Base64Encode(string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002748 File Offset: 0x00000948
		public static int Pourcentage(int current, int maximum)
		{
			int result = 0;
			if (maximum > 0)
			{
				result = (int)(current / maximum * 100m);
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002778 File Offset: 0x00000978
		public static DateTime ToDateTime(this double unixTime)
		{
			if (unixTime < 10000000000.0)
			{
				unixTime *= 1000.0;
			}
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return dateTime.AddMilliseconds(unixTime).ToUniversalTime();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000027C4 File Offset: 0x000009C4
		public static void centerText(string text, Color color)
		{
			Colorful.Console.WriteLine(string.Format("{0," + (System.Console.WindowWidth / 2 + text.Length / 2).ToString() + "}", text), color);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002804 File Offset: 0x00000A04
		public static void Equal(string text)
		{
			Colorful.Console.Write(string.Format("{0," + (System.Console.WindowWidth / 2 + text.Length / 2).ToString() + "}", text));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002844 File Offset: 0x00000A44
		public static string randomString()
		{
			Random random = new Random();
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022EC File Offset: 0x000004EC


		// Token: 0x04000002 RID: 2

	}
}
