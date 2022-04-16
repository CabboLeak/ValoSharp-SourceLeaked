using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200000E RID: 14
	public class json_wrapper
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00002685 File Offset: 0x00000885
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000048D8 File Offset: 0x00002AD8
		public json_wrapper(object obj_to_work_with)
		{
			Class1.MF9OXz();
			base..ctor();
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004930 File Offset: 0x00002B30
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000026A2 File Offset: 0x000008A2
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000026B0 File Offset: 0x000008B0
		internal static bool Yud()
		{
			return json_wrapper.Vua == null;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void DuC()
		{
		}

		// Token: 0x04000043 RID: 67
		private DataContractJsonSerializer serializer;

		// Token: 0x04000044 RID: 68
		private object current_object;

		// Token: 0x04000045 RID: 69
		private static json_wrapper Vua;
	}
}
