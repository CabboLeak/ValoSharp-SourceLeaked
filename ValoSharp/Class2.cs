using System;
using System.Reflection;
using System.Windows.Forms;

// Token: 0x0200001A RID: 26
internal static class Class2
{
	// Token: 0x060000EC RID: 236 RVA: 0x0000281C File Offset: 0x00000A1C
	internal static string PF9Okn(Assembly assembly)
	{
		if (assembly == typeof(Class2).Assembly)
		{
			return Application.ExecutablePath;
		}
		return assembly.Location;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00002842 File Offset: 0x00000A42


	// Token: 0x04000091 RID: 145

}
