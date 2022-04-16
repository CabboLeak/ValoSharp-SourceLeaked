using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x02000004 RID: 4
	public class api
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002C7C File Offset: 0x00000E7C
		public api(string name, string ownerid, string secret, string version)
		{
			Class1.MF9OXz();
			this.app_data = new api.app_data_class();
			this.user_data = new api.user_data_class();
			this.response = new api.response_class();
			this.response_decoder = new json_wrapper(new api.response_structure());
			base..ctor();
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002D14 File Offset: 0x00000F14
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002E98 File Offset: 0x00001098
		public void register(string username, string pass, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003004 File Offset: 0x00001204
		public void login(string username, string pass)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003158 File Offset: 0x00001358
		public void web_login()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			HttpListener httpListener = new HttpListener();
			string text = "handshake";
			text = "http://localhost:1337/" + text + "/";
			httpListener.Prefixes.Add(text);
			httpListener.Start();
			HttpListenerContext context = httpListener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse httpListenerResponse = context.Response;
			httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
			httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
			httpListenerResponse.AddHeader("Via", "hugzho's big brain");
			httpListenerResponse.AddHeader("Location", "your kernel ;)");
			httpListenerResponse.AddHeader("Retry-After", "never lmao");
			httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			string text2 = request.RawUrl.Replace("/handshake?user=", "").Replace("&token=", " ");
			string value2 = text2.Split(Array.Empty<char>())[0];
			string value3 = text2.Split(new char[]
			{
				' '
			})[1];
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = value2;
			nameValueCollection["token"] = value3;
			nameValueCollection["hwid"] = value;
			nameValueCollection["sessionid"] = this.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			string json = api.req_unenc(nameValueCollection);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(json);
			this.load_response_struct(response_structure);
			bool flag = true;
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
				httpListenerResponse.StatusCode = 420;
				httpListenerResponse.StatusDescription = "SHEESH";
			}
			else
			{
				Console.WriteLine(response_structure.message);
				httpListenerResponse.StatusCode = 200;
				httpListenerResponse.StatusDescription = response_structure.message;
				flag = false;
			}
			byte[] bytes = Encoding.UTF8.GetBytes("Whats up?");
			httpListenerResponse.ContentLength64 = (long)bytes.Length;
			httpListenerResponse.OutputStream.Write(bytes, 0, bytes.Length);
			Thread.Sleep(1250);
			httpListener.Stop();
			if (!flag)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000033C0 File Offset: 0x000015C0
		public void button(string button)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			HttpListener httpListener = new HttpListener();
			string uriPrefix = "http://localhost:1337/" + button + "/";
			httpListener.Prefixes.Add(uriPrefix);
			httpListener.Start();
			HttpListenerContext context = httpListener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse httpListenerResponse = context.Response;
			httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
			httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
			httpListenerResponse.AddHeader("Via", "hugzho's big brain");
			httpListenerResponse.AddHeader("Location", "your kernel ;)");
			httpListenerResponse.AddHeader("Retry-After", "never lmao");
			httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
			httpListenerResponse.StatusCode = 420;
			httpListenerResponse.StatusDescription = "SHEESH";
			httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			httpListener.UnsafeConnectionNtlmAuthentication = true;
			httpListener.IgnoreWriteExceptions = true;
			httpListener.Stop();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000034B8 File Offset: 0x000016B8
		public void upgrade(string username, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000035E8 File Offset: 0x000017E8
		public void license(string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003724 File Offset: 0x00001924
		public void check()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000380C File Offset: 0x00001A0C
		public void setvar(string var, string data)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003924 File Offset: 0x00001B24
		public string getvar(string var)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003A34 File Offset: 0x00001C34
		public void ban()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003B1C File Offset: 0x00001D1C
		public string var(string varid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003C3C File Offset: 0x00001E3C
		public List<api.msg> chatget(string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003D4C File Offset: 0x00001F4C
		public bool chatsend(string msg, string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003E70 File Offset: 0x00002070
		public bool checkblack()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003F8C File Offset: 0x0000218C
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
				return null;
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000040EC File Offset: 0x000022EC
		public byte[] download(string fileid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first. File is empty since no request could be made.");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00004204 File Offset: 0x00002404
		public void log(string message)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			api.req(nameValueCollection);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004300 File Offset: 0x00002500
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004370 File Offset: 0x00002570
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000043C0 File Offset: 0x000025C0
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000445C File Offset: 0x0000265C
		private static string req_unenc(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.1/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000044F8 File Offset: 0x000026F8
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000455C File Offset: 0x0000275C
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002328 File Offset: 0x00000528
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000231C File Offset: 0x0000051C
		internal static void i4()
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000234C File Offset: 0x0000054C
		internal static bool R3()
		{
			return api.Fw == null;
		}

		// Token: 0x04000005 RID: 5
		public string name;

		// Token: 0x04000006 RID: 6
		public string ownerid;

		// Token: 0x04000007 RID: 7
		public string secret;

		// Token: 0x04000008 RID: 8
		public string version;

		// Token: 0x04000009 RID: 9
		private string sessionid;

		// Token: 0x0400000A RID: 10
		private string enckey;

		// Token: 0x0400000B RID: 11
		private bool initzalized;

		// Token: 0x0400000C RID: 12
		public api.app_data_class app_data;

		// Token: 0x0400000D RID: 13
		public api.user_data_class user_data;

		// Token: 0x0400000E RID: 14
		public api.response_class response;

		// Token: 0x0400000F RID: 15
		private json_wrapper response_decoder;

		// Token: 0x04000010 RID: 16
		internal static api Fw;

		// Token: 0x02000005 RID: 5
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000001 RID: 1
			// (get) Token: 0x0600002D RID: 45 RVA: 0x00002356 File Offset: 0x00000556
			// (set) Token: 0x0600002E RID: 46 RVA: 0x0000235E File Offset: 0x0000055E
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000002 RID: 2
			// (get) Token: 0x0600002F RID: 47 RVA: 0x00002367 File Offset: 0x00000567
			// (set) Token: 0x06000030 RID: 48 RVA: 0x0000236F File Offset: 0x0000056F
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x06000031 RID: 49 RVA: 0x00002378 File Offset: 0x00000578
			// (set) Token: 0x06000032 RID: 50 RVA: 0x00002380 File Offset: 0x00000580
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000033 RID: 51 RVA: 0x00002389 File Offset: 0x00000589
			// (set) Token: 0x06000034 RID: 52 RVA: 0x00002391 File Offset: 0x00000591
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000035 RID: 53 RVA: 0x0000239A File Offset: 0x0000059A
			// (set) Token: 0x06000036 RID: 54 RVA: 0x000023A2 File Offset: 0x000005A2
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000037 RID: 55 RVA: 0x000023AB File Offset: 0x000005AB
			// (set) Token: 0x06000038 RID: 56 RVA: 0x000023B3 File Offset: 0x000005B3
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000039 RID: 57 RVA: 0x000023BC File Offset: 0x000005BC
			// (set) Token: 0x0600003A RID: 58 RVA: 0x000023C4 File Offset: 0x000005C4
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x0600003B RID: 59 RVA: 0x000023CD File Offset: 0x000005CD
			// (set) Token: 0x0600003C RID: 60 RVA: 0x000023D5 File Offset: 0x000005D5
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x0600003D RID: 61 RVA: 0x000023DE File Offset: 0x000005DE
			// (set) Token: 0x0600003E RID: 62 RVA: 0x000023E6 File Offset: 0x000005E6
			[DataMember]
			public List<api.msg> messages { get; set; }

			// Token: 0x0600003F RID: 63 RVA: 0x000022F6 File Offset: 0x000004F6
			public response_structure()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000040 RID: 64 RVA: 0x000023EF File Offset: 0x000005EF
			internal static bool Qr()
			{
				return api.response_structure.aQ == null;
			}

			// Token: 0x06000041 RID: 65 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void s0()
			{
			}

			// Token: 0x0400001A RID: 26
			internal static api.response_structure aQ;
		}

		// Token: 0x02000006 RID: 6
		public class msg
		{
			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000042 RID: 66 RVA: 0x000023F9 File Offset: 0x000005F9
			// (set) Token: 0x06000043 RID: 67 RVA: 0x00002401 File Offset: 0x00000601
			public string message { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000044 RID: 68 RVA: 0x0000240A File Offset: 0x0000060A
			// (set) Token: 0x06000045 RID: 69 RVA: 0x00002412 File Offset: 0x00000612
			public string author { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000046 RID: 70 RVA: 0x0000241B File Offset: 0x0000061B
			// (set) Token: 0x06000047 RID: 71 RVA: 0x00002423 File Offset: 0x00000623
			public string timestamp { get; set; }

			// Token: 0x06000048 RID: 72 RVA: 0x000022F6 File Offset: 0x000004F6
			public msg()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000049 RID: 73 RVA: 0x0000242C File Offset: 0x0000062C
			internal static bool Iuv()
			{
				return api.msg.Az == null;
			}

			// Token: 0x0600004A RID: 74 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void Ruh()
			{
			}

			// Token: 0x0400001E RID: 30
			internal static api.msg Az;
		}

		// Token: 0x02000007 RID: 7
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600004B RID: 75 RVA: 0x00002436 File Offset: 0x00000636
			// (set) Token: 0x0600004C RID: 76 RVA: 0x0000243E File Offset: 0x0000063E
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x0600004D RID: 77 RVA: 0x00002447 File Offset: 0x00000647
			// (set) Token: 0x0600004E RID: 78 RVA: 0x0000244F File Offset: 0x0000064F
			[DataMember]
			public string ip { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00002458 File Offset: 0x00000658
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00002460 File Offset: 0x00000660
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00002469 File Offset: 0x00000669
			// (set) Token: 0x06000052 RID: 82 RVA: 0x00002471 File Offset: 0x00000671
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000053 RID: 83 RVA: 0x0000247A File Offset: 0x0000067A
			// (set) Token: 0x06000054 RID: 84 RVA: 0x00002482 File Offset: 0x00000682
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000055 RID: 85 RVA: 0x0000248B File Offset: 0x0000068B
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00002493 File Offset: 0x00000693
			[DataMember]
			public List<api.Data> subscriptions { get; set; }

			// Token: 0x06000057 RID: 87 RVA: 0x000022F6 File Offset: 0x000004F6
			public user_data_structure()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000058 RID: 88 RVA: 0x0000249C File Offset: 0x0000069C
			internal static bool QuK()
			{
				return api.user_data_structure.EuM == null;
			}

			// Token: 0x06000059 RID: 89 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void aub()
			{
			}

			// Token: 0x04000025 RID: 37
			internal static api.user_data_structure EuM;
		}

		// Token: 0x02000008 RID: 8
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600005A RID: 90 RVA: 0x000024A6 File Offset: 0x000006A6
			// (set) Token: 0x0600005B RID: 91 RVA: 0x000024AE File Offset: 0x000006AE
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600005C RID: 92 RVA: 0x000024B7 File Offset: 0x000006B7
			// (set) Token: 0x0600005D RID: 93 RVA: 0x000024BF File Offset: 0x000006BF
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x0600005E RID: 94 RVA: 0x000024C8 File Offset: 0x000006C8
			// (set) Token: 0x0600005F RID: 95 RVA: 0x000024D0 File Offset: 0x000006D0
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000060 RID: 96 RVA: 0x000024D9 File Offset: 0x000006D9
			// (set) Token: 0x06000061 RID: 97 RVA: 0x000024E1 File Offset: 0x000006E1
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000062 RID: 98 RVA: 0x000024EA File Offset: 0x000006EA
			// (set) Token: 0x06000063 RID: 99 RVA: 0x000024F2 File Offset: 0x000006F2
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000064 RID: 100 RVA: 0x000024FB File Offset: 0x000006FB
			// (set) Token: 0x06000065 RID: 101 RVA: 0x00002503 File Offset: 0x00000703
			[DataMember]
			public string downloadLink { get; set; }

			// Token: 0x06000066 RID: 102 RVA: 0x000022F6 File Offset: 0x000004F6
			public app_data_structure()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000067 RID: 103 RVA: 0x0000250C File Offset: 0x0000070C
			internal static bool hun()
			{
				return api.app_data_structure.kux == null;
			}

			// Token: 0x06000068 RID: 104 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void Buf()
			{
			}

			// Token: 0x0400002C RID: 44
			internal static api.app_data_structure kux;
		}

		// Token: 0x02000009 RID: 9
		public class app_data_class
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000069 RID: 105 RVA: 0x00002516 File Offset: 0x00000716
			// (set) Token: 0x0600006A RID: 106 RVA: 0x0000251E File Offset: 0x0000071E
			public string numUsers { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600006B RID: 107 RVA: 0x00002527 File Offset: 0x00000727
			// (set) Token: 0x0600006C RID: 108 RVA: 0x0000252F File Offset: 0x0000072F
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00002538 File Offset: 0x00000738
			// (set) Token: 0x0600006E RID: 110 RVA: 0x00002540 File Offset: 0x00000740
			public string numKeys { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00002549 File Offset: 0x00000749
			// (set) Token: 0x06000070 RID: 112 RVA: 0x00002551 File Offset: 0x00000751
			public string version { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000071 RID: 113 RVA: 0x0000255A File Offset: 0x0000075A
			// (set) Token: 0x06000072 RID: 114 RVA: 0x00002562 File Offset: 0x00000762
			public string customerPanelLink { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000073 RID: 115 RVA: 0x0000256B File Offset: 0x0000076B
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00002573 File Offset: 0x00000773
			public string downloadLink { get; set; }

			// Token: 0x06000075 RID: 117 RVA: 0x000022F6 File Offset: 0x000004F6
			public app_data_class()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000076 RID: 118 RVA: 0x0000257C File Offset: 0x0000077C
			internal static bool Sul()
			{
				return api.app_data_class.guJ == null;
			}

			// Token: 0x06000077 RID: 119 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void guR()
			{
			}

			// Token: 0x04000033 RID: 51
			internal static api.app_data_class guJ;
		}

		// Token: 0x0200000A RID: 10
		public class user_data_class
		{
			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000078 RID: 120 RVA: 0x00002586 File Offset: 0x00000786
			// (set) Token: 0x06000079 RID: 121 RVA: 0x0000258E File Offset: 0x0000078E
			public string username { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007A RID: 122 RVA: 0x00002597 File Offset: 0x00000797
			// (set) Token: 0x0600007B RID: 123 RVA: 0x0000259F File Offset: 0x0000079F
			public string ip { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600007C RID: 124 RVA: 0x000025A8 File Offset: 0x000007A8
			// (set) Token: 0x0600007D RID: 125 RVA: 0x000025B0 File Offset: 0x000007B0
			public string hwid { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600007E RID: 126 RVA: 0x000025B9 File Offset: 0x000007B9
			// (set) Token: 0x0600007F RID: 127 RVA: 0x000025C1 File Offset: 0x000007C1
			public string createdate { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000080 RID: 128 RVA: 0x000025CA File Offset: 0x000007CA
			// (set) Token: 0x06000081 RID: 129 RVA: 0x000025D2 File Offset: 0x000007D2
			public string lastlogin { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000025DB File Offset: 0x000007DB
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000025E3 File Offset: 0x000007E3
			public List<api.Data> subscriptions { get; set; }

			// Token: 0x06000084 RID: 132 RVA: 0x000022F6 File Offset: 0x000004F6
			public user_data_class()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000085 RID: 133 RVA: 0x000025EC File Offset: 0x000007EC
			internal static bool cu3()
			{
				return api.user_data_class.Cuw == null;
			}

			// Token: 0x06000086 RID: 134 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void Gu4()
			{
			}

			// Token: 0x0400003A RID: 58
			internal static api.user_data_class Cuw;
		}

		// Token: 0x0200000B RID: 11
		public class Data
		{
			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000087 RID: 135 RVA: 0x000025F6 File Offset: 0x000007F6
			// (set) Token: 0x06000088 RID: 136 RVA: 0x000025FE File Offset: 0x000007FE
			public string subscription { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000089 RID: 137 RVA: 0x00002607 File Offset: 0x00000807
			// (set) Token: 0x0600008A RID: 138 RVA: 0x0000260F File Offset: 0x0000080F
			public string expiry { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600008B RID: 139 RVA: 0x00002618 File Offset: 0x00000818
			// (set) Token: 0x0600008C RID: 140 RVA: 0x00002620 File Offset: 0x00000820
			public string timeleft { get; set; }

			// Token: 0x0600008D RID: 141 RVA: 0x000022F6 File Offset: 0x000004F6
			public Data()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x0600008E RID: 142 RVA: 0x00002629 File Offset: 0x00000829
			internal static bool Vut()
			{
				return api.Data.DuS == null;
			}

			// Token: 0x0600008F RID: 143 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void fuF()
			{
			}

			// Token: 0x0400003E RID: 62
			private static api.Data DuS;
		}

		// Token: 0x0200000C RID: 12
		public class response_class
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000090 RID: 144 RVA: 0x00002633 File Offset: 0x00000833
			// (set) Token: 0x06000091 RID: 145 RVA: 0x0000263B File Offset: 0x0000083B
			public bool success { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000092 RID: 146 RVA: 0x00002644 File Offset: 0x00000844
			// (set) Token: 0x06000093 RID: 147 RVA: 0x0000264C File Offset: 0x0000084C
			public string message { get; set; }

			// Token: 0x06000094 RID: 148 RVA: 0x000022F6 File Offset: 0x000004F6
			public response_class()
			{
				Class1.MF9OXz();
				base..ctor();
			}

			// Token: 0x06000095 RID: 149 RVA: 0x00002655 File Offset: 0x00000855
			internal static bool quN()
			{
				return api.response_class.Yu6 == null;
			}

			// Token: 0x06000096 RID: 150 RVA: 0x0000231C File Offset: 0x0000051C
			internal static void AuA()
			{
			}

			// Token: 0x04000041 RID: 65
			internal static api.response_class Yu6;
		}
	}
}
