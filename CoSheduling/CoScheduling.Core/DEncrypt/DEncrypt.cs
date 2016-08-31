using System;
using System.Security.Cryptography;  
using System.Text;
namespace CoScheduling.Core.DEncrypt
{
	/// <summary>
	/// 类名：加密类
    /// 作者：李光强
    /// 时间：2013.7.2
	/// </summary>
	public class DEncrypt
	{
		/// <summary>
		/// 构造方法
		/// </summary>
		public DEncrypt()  
		{  
		} 

		#region 使用 缺省密钥字符串 加密/解密string

		/// <summary>
		/// 使用缺省密钥字符串加密string
		/// </summary>
		/// <param name="original">明文</param>
		/// <returns>密文</returns>
		public static string Encrypt(string original)
		{
            return Encrypt(original, "LiGuangQIANG");
		}
		/// <summary>
		/// 使用缺省密钥字符串解密string
		/// </summary>
		/// <param name="original">密文</param>
		/// <returns>明文</returns>
		public static string Decrypt(string original)
		{
            return Decrypt(original, "LiGuangQIANG", System.Text.Encoding.Default);
		}

		#endregion

		#region 使用 给定密钥字符串 加密/解密string
		/// <summary>
		/// 使用给定密钥字符串加密string
		/// </summary>
		/// <param name="original">原始文字</param>
		/// <param name="key">密钥</param>
		/// <param name="encoding">字符编码方案</param>
		/// <returns>密文</returns>
		public static string Encrypt(string original, string key)  
		{  
			byte[] buff = System.Text.Encoding.Default.GetBytes(original);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return Convert.ToBase64String(Encrypt(buff,kb));      
		}
		/// <summary>
		/// 使用给定密钥字符串解密string
		/// </summary>
		/// <param name="original">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
		public static string Decrypt(string original, string key)
		{
			return Decrypt(original,key,System.Text.Encoding.Default);
		}

		/// <summary>
		/// 使用给定密钥字符串解密string,返回指定编码方式明文
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <param name="encoding">字符编码方案</param>
		/// <returns>明文</returns>
		public static string Decrypt(string encrypted, string key,Encoding encoding)  
		{       
			byte[] buff = Convert.FromBase64String(encrypted);  
			byte[] kb = System.Text.Encoding.Default.GetBytes(key);
			return encoding.GetString(Decrypt(buff,kb));      
		}  
		#endregion

		#region 使用 缺省密钥字符串 加密/解密/byte[]
		/// <summary>
		/// 使用缺省密钥字符串解密byte[]
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
		public static byte[] Decrypt(byte[] encrypted)  
		{
            byte[] key = System.Text.Encoding.Default.GetBytes("LiGuangQIANG"); 
			return Decrypt(encrypted,key);     
		}
		/// <summary>
		/// 使用缺省密钥字符串加密
		/// </summary>
		/// <param name="original">原始数据</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
		public static byte[] Encrypt(byte[] original)  
		{
            byte[] key = System.Text.Encoding.Default.GetBytes("LiGuangQIANG"); 
			return Encrypt(original,key);     
		}  
		#endregion

		#region  使用 给定密钥 加密/解密/byte[]

		/// <summary>
		/// 生成MD5摘要
		/// </summary>
		/// <param name="original">数据源</param>
		/// <returns>摘要</returns>
		private static byte[] MakeMD5(byte[] original)
		{
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();   
			byte[] keyhash = hashmd5.ComputeHash(original);       
			hashmd5 = null;  
			return keyhash;
		}


		/// <summary>
		/// 使用给定密钥加密
		/// </summary>
		/// <param name="original">明文</param>
		/// <param name="key">密钥</param>
		/// <returns>密文</returns>
		public static byte[] Encrypt(byte[] original, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();       
			des.Key =  MakeMD5(key);
			des.Mode = CipherMode.ECB;  
     
			return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);     
		}  

		/// <summary>
		/// 使用给定密钥解密数据
		/// </summary>
		/// <param name="encrypted">密文</param>
		/// <param name="key">密钥</param>
		/// <returns>明文</returns>
		public static byte[] Decrypt(byte[] encrypted, byte[] key)  
		{  
			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();  
			des.Key =  MakeMD5(key);    
			des.Mode = CipherMode.ECB;  

			return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
		}  
  
		#endregion

        #region MD5
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="sSourceData">明文</param>
        /// <returns>密文</returns>
        public static string MD5(string sSourceData)
        {
            byte[] tmpSource = null;
            byte[] tmpHash = null;
            tmpSource = System.Text.ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(tmpSource);
            int i = 0;
            System.Text.StringBuilder sOutput = new System.Text.StringBuilder(tmpHash.Length);
            for (i = 0; i <= tmpHash.Length - 1; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        #endregion




    }
}
