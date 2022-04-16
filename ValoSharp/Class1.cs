using System;
using System.Windows.Forms;

// Token: 0x02000019 RID: 25
internal class Class1
{
	// Token: 0x060000E9 RID: 233 RVA: 0x0000A6D4 File Offset: 0x000088D4
	internal static void MF9OXz()
	{
		if (!Class1.bool_0)
		{
			Class1.bool_0 = true;
			try
			{
				MessageBox.Show("This assembly is protected by an unregistered version of Eziriz's \".NET Reactor\"!");
			}
			catch
			{
			}
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00002812 File Offset: 0x00000A12
	internal static bool uM6()
	{
		return Class1.lM7 == null;
	}

	// Token: 0x0400008F RID: 143
	private static bool bool_0;

	// Token: 0x04000090 RID: 144
	internal static Class1 lM7;
}
