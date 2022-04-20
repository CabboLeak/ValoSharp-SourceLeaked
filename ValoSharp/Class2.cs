using System;
using System.Reflection;
using System.Windows.Forms;

// Token: 0x0200000F RID: 15
internal static class Class2
{
	// Token: 0x06000054 RID: 84 RVA: 0x0000242C File Offset: 0x0000062C
	internal static string PF9Okn(Assembly assembly)
	{
		if (assembly == typeof(Class2).Assembly)
		{
			return Application.ExecutablePath;
		}
		return assembly.Location;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00002452 File Offset: 0x00000652


}
