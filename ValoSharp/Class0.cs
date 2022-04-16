using System;
using System.Reflection;

// Token: 0x02000017 RID: 23
internal class Class0
{
	// Token: 0x060000E0 RID: 224 RVA: 0x0000A668 File Offset: 0x00008868
	internal static void AF9OXX(int typemdt)
	{
		Type type = Class0.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class0.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x000022F6 File Offset: 0x000004F6
	public Class0()
	{
		Class1.MF9OXz();
		base..ctor();
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x000027E0 File Offset: 0x000009E0
	static Class0()
	{
		Class1.MF9OXz();
		Class0.module_0 = typeof(Class0).Assembly.ManifestModule;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00002800 File Offset: 0x00000A00
	internal static bool thp()
	{
		return Class0.jho == null;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000231C File Offset: 0x0000051C
	internal static void phP()
	{
	}

	// Token: 0x0400008D RID: 141
	internal static Module module_0;

	// Token: 0x0400008E RID: 142
	private static Class0 jho;

	// Token: 0x02000018 RID: 24
	// (Invoke) Token: 0x060000E6 RID: 230
	internal delegate void Delegate0(object o);
}
