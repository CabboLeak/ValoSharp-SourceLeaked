using System;
using System.Reflection;

// Token: 0x0200000C RID: 12
internal class Class0
{
	internal static Module module_0;
	// Token: 0x06000048 RID: 72 RVA: 0x000083A0 File Offset: 0x000065A0
	internal static void AF9OXX(int typemdt)
	{
		Type type = Class0.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class0.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}
	
}
