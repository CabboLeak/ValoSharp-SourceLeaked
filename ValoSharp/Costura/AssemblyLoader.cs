using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000014 RID: 20
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x000027C5 File Offset: 0x000009C5
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000A03C File Offset: 0x0000823C
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000A0AC File Offset: 0x000082AC
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000A0E0 File Offset: 0x000082E0
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				Stream result;
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						result = memoryStream;
					}
				}
				return result;
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000A170 File Offset: 0x00008370
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullName;
			if (resourceNames.TryGetValue(name, out fullName))
			{
				return AssemblyLoader.LoadStream(fullName);
			}
			return null;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000A190 File Offset: 0x00008390
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000A1B8 File Offset: 0x000083B8
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000A278 File Offset: 0x00008478
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly == null)
			{
				assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
				if (assembly == null)
				{
					object obj2 = AssemblyLoader.nullCacheLock;
					lock (obj2)
					{
						AssemblyLoader.nullCache[e.Name] = true;
					}
					if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
					{
						assembly = Assembly.Load(assemblyName);
					}
				}
				return assembly;
			}
			return assembly;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000A350 File Offset: 0x00008550
		static AssemblyLoader()
		{
			Class1.MF9OXz();
			AssemblyLoader.nullCacheLock = new object();
			AssemblyLoader.nullCache = new Dictionary<string, bool>();
			AssemblyLoader.assemblyNames = new Dictionary<string, string>();
			AssemblyLoader.symbolNames = new Dictionary<string, string>();
			AssemblyLoader.assemblyNames.Add("colorful.console", "costura.colorful.console.dll.compressed");
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.symbolNames.Add("costura", "costura.costura.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("flurl", "costura.flurl.dll.compressed");
			AssemblyLoader.assemblyNames.Add("flurl.http", "costura.flurl.http.dll.compressed");
			AssemblyLoader.symbolNames.Add("flurl.http", "costura.flurl.http.pdb.compressed");
			AssemblyLoader.symbolNames.Add("flurl", "costura.flurl.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("leaf.xnet", "costura.leaf.xnet.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.bcl.asyncinterfaces", "costura.microsoft.bcl.asyncinterfaces.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.abstractions", "costura.microsoft.extensions.configuration.abstractions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration", "costura.microsoft.extensions.configuration.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.fileextensions", "costura.microsoft.extensions.configuration.fileextensions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.json", "costura.microsoft.extensions.configuration.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.fileproviders.abstractions", "costura.microsoft.extensions.fileproviders.abstractions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.fileproviders.physical", "costura.microsoft.extensions.fileproviders.physical.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.filesystemglobbing", "costura.microsoft.extensions.filesystemglobbing.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.abstractions", "costura.microsoft.extensions.logging.abstractions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.extensions.primitives", "costura.microsoft.extensions.primitives.dll.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("restsharp", "costura.restsharp.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.buffers", "costura.system.buffers.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.configuration.configurationmanager", "costura.system.configuration.configurationmanager.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.memory", "costura.system.memory.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.net.http.extensions", "costura.system.net.http.extensions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.net.http.primitives", "costura.system.net.http.primitives.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.numerics.vectors", "costura.system.numerics.vectors.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.security.accesscontrol", "costura.system.security.accesscontrol.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.security.permissions", "costura.system.security.permissions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.security.principal.windows", "costura.system.security.principal.windows.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.text.encodings.web", "costura.system.text.encodings.web.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.text.json", "costura.system.text.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.threading.tasks.extensions", "costura.system.threading.tasks.extensions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000A634 File Offset: 0x00008834
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000027D6 File Offset: 0x000009D6
		internal static bool rhm()
		{
			return AssemblyLoader.qh4 == null;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void ihd()
		{
		}

		// Token: 0x04000085 RID: 133
		private static object nullCacheLock;

		// Token: 0x04000086 RID: 134
		private static Dictionary<string, bool> nullCache;

		// Token: 0x04000087 RID: 135
		private static Dictionary<string, string> assemblyNames;

		// Token: 0x04000088 RID: 136
		private static Dictionary<string, string> symbolNames;

		// Token: 0x04000089 RID: 137
		private static int isAttached;

		// Token: 0x0400008A RID: 138
		internal static AssemblyLoader qh4;
	}
}
