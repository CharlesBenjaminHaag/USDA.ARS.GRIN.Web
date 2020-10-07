using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace GrinGlobal.Core
{
	/// <summary>
	/// Summary description for Crypto.
	/// </summary>
	[ComVisible(true)]
	public class Crypto : IDisposable
	{


		/// <summary>
		/// Encodes the given plain text into hex text (UTF8 only)
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		[ComVisible(true)]
		public static string HexEncodeText(string plainText)
		{
			return new Crypto().HexEncode(plainText);
		}

		/// <summary>
		/// Decodes the given hex text into plain text (UTF8 only)
		/// </summary>
		/// <param name="hexText"></param>
		/// <returns></returns>
		[ComVisible(true)]
		public static string HexDecodeText(string hexText)
		{
			return new Crypto().HexDecode(hexText);
		}


		/// <summary>
		/// Encodes the given plain text into base 64 text (UTF8 only)
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		[ComVisible(true)]
		public static string Base64EncodeText(string plainText)
		{
			return new Crypto().Base64Encode(plainText);
		}

		/// <summary>
		/// Decodes the given base64 text into plain text (UTF8 only)
		/// </summary>
		/// <param name="base64Text"></param>
		/// <returns></returns>
		[ComVisible(true)]
		public static string Base64DecodeText(string base64Text)
		{
			return new Crypto().Base64Decode(base64Text);
		}

		/// <summary>
		/// Encrypts the given plainText into a cipherText that is then encoded in Base64 for web-friendliness
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static string EncryptText(string plainText)
		//{
		//	return new Crypto().Encrypt(plainText);
		//}

		/// <summary>
		/// Encrypts the given plainText into a cipherText that is then encoded in Base64 for web-friendliness
		/// </summary>
		/// <param name="plainText"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static string EncryptText(string plainText, string password)
		//{
		//	return new Crypto().Encrypt(plainText, password);
		//}

		/// <summary>
		/// Encrypts the given plainBytes into a sequence of encrypted bytes that is then encoded in Base64 for web-friendliness
		/// </summary>
		/// <param name="plainBytes"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static byte[] EncryptBytes(byte[] plainBytes)
		//{
		//	return new Crypto().Encrypt(plainBytes);
		//}

		/// <summary>
		/// Decrypts the given cipherText which is Base64-encoded into the original plain text
		/// </summary>
		/// <param name="cipherText"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static string DecryptText(string cipherText)
		//{
		//	return new Crypto().Decrypt(cipherText);
		//}

		/// <summary>
		/// Decrypts the given cipherText which is Base64-encoded into the original plain text
		/// </summary>
		/// <param name="cipherText"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static string DecryptText(string cipherText, string password)
		//{
		//	return new Crypto().Decrypt(cipherText, password);
		//}

		/// <summary>
		/// Decrypts the given cipherBytes which are Base64-encoded into the original sequence of plain bytes.
		/// </summary>
		/// <param name="cipherBytes"></param>
		/// <returns></returns>
		//[ComVisible(true)]
		//public static byte[] DecryptBytes(byte[] cipherBytes)
		//{
		//	return new Crypto().Decrypt(cipherBytes);
		//}

		/// <summary>
		/// Creates an instance of the Crypto class
		/// </summary>
		public Crypto()
		{
			_aes = new AesCng();

#if NEW_CRYPTO
            _aes.BlockSize = 256;
            _aes.KeySize = 256;
            _aes.Padding = PaddingMode.ISO10126;
#endif

			// use the default key embedded in this assembly
			Password = @"ki&89sEBY40$@*woijPYH9097WSDW299[[[2qxopEX{OIWo*";


			_sha1 = new SHA1Cng();
			_sha256 = new SHA256Cng();
		}

		private static byte[] SALT = new byte[] { 0xb4, 0x52, 0x59, 0x99, 0x64, 0x36, 0x65, 0x1c, 0xf7, 0x8d, 0x6a, 0x23, 0x2e, };

		private AesCng _aes;
		private ICryptoTransform _encryptor;
		private ICryptoTransform _decryptor;

		private string _password;
		/// <summary>
		/// Gets or sets the current password to use for encryption.  Regenerates the IV and Key when set.
		/// </summary>
		public string Password
		{
			get { return _password; }
			set
			{
				if (_password == null)
				{
					_password = String.Empty;
				}
				if (_password != value)
				{
					_password = value;
					PasswordDeriveBytes pdb = new PasswordDeriveBytes(_password, Crypto.SALT);
#if NEW_CRYPTO
                    _aes.IV = pdb.GetBytes(32);
                    _aes.Key = pdb.GetBytes(32);
#else
					_aes.IV = pdb.GetBytes(16);
					_aes.Key = pdb.GetBytes(32);


#endif

					_encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
					_decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);
				}
			}
		}

		private byte[] _plainBytes;
		/// <summary>
		/// Gets or sets the Decrypted / Original sequence of bytes
		/// </summary>
		public byte[] PlainBytes
		{
			get { return _plainBytes; }
			set
			{
				_plainBytes = value;
				_cipherBytes = null;
			}
		}

		/// <summary>
		/// Gets or sets the Decrypted / Original string (UTF8 Encoding)
		/// </summary>
		public string PlainText
		{
			get { return _plainBytes == null ? null : UTF8Encoding.UTF8.GetString(_plainBytes); }
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					_plainBytes = null;
				}
				else
				{
					_plainBytes = UTF8Encoding.UTF8.GetBytes(value);
				}
				_cipherBytes = null;
			}
		}

		private byte[] _cipherBytes;
		/// <summary>
		/// Gets or sets the Encrypted sequence of bytes
		/// </summary>
		public byte[] CipherBytes
		{
			get { return _cipherBytes; }
			set
			{
				_cipherBytes = value;
				_plainBytes = null;
			}
		}

		/// <summary>
		/// Gets or sets the Encrypted string (Base64 Encoding)
		/// </summary>
		public string CipherText
		{
			get { return _cipherBytes == null ? null : Convert.ToBase64String(_cipherBytes); }
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					_cipherBytes = null;
				}
				else
				{
					_cipherBytes = Convert.FromBase64String(value);
				}
				_plainBytes = null;
			}
		}

		/// <summary>
		/// hex-encodes the given plain text
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		public string HexEncode(string plainText)
		{
			byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < plainBytes.Length; i++)
			{
				sb.Append(plainBytes[i].ToString("X"));
			}

			string ret = sb.ToString();
			return ret;
		}

		/// <summary>
		/// hex-decodes the given hex text
		/// </summary>
		/// <param name="hexText"></param>
		/// <returns></returns>
		public string HexDecode(string hexText)
		{
			byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(hexText);
			StringBuilder sb = new StringBuilder();
			int size = hexText.Length / 2;
			for (int i = 0; i < size; i += 2)
			{
				byte b = byte.Parse(hexText.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
				char c = (char)b;
				sb.Append(c);
			}
			string ret = sb.ToString();
			return ret;

		}

		/// <summary>
		/// base64-encodes the given plain text
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		public string Base64Encode(string plainText)
		{
			byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			string ret = Convert.ToBase64String(encodedBytes);
			return ret;
		}

		/// <summary>
		/// base64-decodes the given base64 text
		/// </summary>
		/// <param name="base64Text"></param>
		/// <returns></returns>
		public string Base64Decode(string base64Text)
		{
			byte[] plainBytes = Convert.FromBase64String(base64Text);
			string ret = System.Text.Encoding.UTF8.GetString(plainBytes);
			return ret;
		}

		/// <summary>
		/// Returns the SHA1 hash of the given text in base64 encoded format.  Use Crypto.Hash instead if calling several times.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string HashText(string text)
		{
			if (String.IsNullOrEmpty(text))
			{
				return null;
			}
			else
			{
				return new Crypto().Hash(text);
			}
		}

		/// <summary>
		/// Returns the SHA256 hash of the given text in base64 encoded format.  Use Crypto.Hash instead if calling several times.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string HashTextSHA256(string text)
		{
			if (String.IsNullOrEmpty(text))
			{
				return null;
			}
			else
			{
				return new Crypto().HashSHA256(text);
			}
		}

		/// <summary>
		/// Returns random bytes as base64 encoded string for use as password salt
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public static string SaltText(int size)
		{
			if (size < 1)
			{
				return null;
			}
			else
			{
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
				byte[] buff = new byte[size];
				rng.GetBytes(buff);

				// Return a Base64 string representation of the random number.
				return Convert.ToBase64String(buff);
			}
		}


		/// <summary>
		/// Returns the SHA1 hash of the given text in base64 encoded format
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public string Hash(string text)
		{
			if (String.IsNullOrEmpty(text))
			{
				return null;
			}
			else
			{
				var bytes = Hash(UTF8Encoding.UTF8.GetBytes(text));
				if (bytes == null || bytes.Length == 0)
				{
					return null;
				}
				else
				{
					var rv = Convert.ToBase64String(bytes);
					return rv;
				}
			}
		}

		/// <summary>
		/// Returns the SHA256 hash of the given text in base64 encoded format
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public string HashSHA256(string text)
		{
			if (String.IsNullOrEmpty(text))
			{
				return null;
			}
			else
			{
				var bytes = HashSHA256(UTF8Encoding.UTF8.GetBytes(text));
				if (bytes == null || bytes.Length == 0)
				{
					return null;
				}
				else
				{
					var rv = Convert.ToBase64String(bytes);
					return rv;
				}
			}
		}

		/// <summary>
		/// Returns the SHA1 hash of the given input.
		/// </summary>
		/// <param name="inputBytes"></param>
		/// <returns></returns>
		public byte[] Hash(byte[] inputBytes)
		{
			if (inputBytes == null || inputBytes.Length == 0)
			{
				return null;
			}
			return _sha1.ComputeHash(inputBytes);
		}

		/// <summary>
		/// Returns the SHA256 hash of the given input.
		/// </summary>
		/// <param name="inputBytes"></param>
		/// <returns></returns>
		public byte[] HashSHA256(byte[] inputBytes)
		{
			if (inputBytes == null || inputBytes.Length == 0)
			{
				return null;
			}
			return _sha256.ComputeHash(inputBytes);
		}


		/// <summary>
		/// Encrypts the given plainText and returns the encrypted text
		/// </summary>
		/// <param name="plainText">Decrypted string to encrypt</param>
		/// <returns>Encrypted string in Base64 Encoding</returns>
		//public string Encrypt(string plainText)
		//{
		//	//return Encrypt(plainText, Toolkit.GetSetting("EncryptionPassword", Password));
		//}

		/// <summary>
		/// Encrypts the given plainText using the given password and returns the encrypted Base 64 Encoded string.
		/// </summary>
		/// <param name="plainText">Decrypted string to encrypt</param>
		/// <param name="password">Password to encrypt the data with</param>
		/// <returns>Encrypted string in Base64 Encoding</returns>
		public string Encrypt(string plainText, string password)
		{
			PlainText = plainText;
			Password = password;
			Encrypt();
			return CipherText;
		}

		/// <summary>
		/// Encrypts the given plainBytes and returns the encrypted bytes
		/// </summary>
		/// <param name="plainBytes">Decrypted bytes to encrypt</param>
		/// <returns>Encrypted bytes</returns>
		//public byte[] Encrypt(byte[] plainBytes)
		//{
		//	//return Encrypt(plainBytes, Toolkit.GetSetting("EncryptionPassword", Password));
		//}

		/// <summary>
		/// Encrypts the given plainBytes using the given password and returns the encrypted bytes
		/// </summary>
		/// <param name="plainBytes">Decrypted bytes to encrypt</param>
		/// <param name="password">Password to encrypt the data with</param>
		/// <returns>Encrypted bytes</returns>
		public byte[] Encrypt(byte[] plainBytes, string password)
		{
			PlainBytes = plainBytes;
			Password = password;
			Encrypt();
			return CipherBytes;
		}

		/// <summary>
		/// Decrypts the given cipherText and returns the decrypted text
		/// </summary>
		/// <param name="cipherText">Encrypted string to decrypt</param>
		/// <returns>Decrypted string in Base64 Encoding</returns>
		//public string Decrypt(string cipherText)
		//{
		//	//return Decrypt(cipherText, Toolkit.GetSetting("EncryptionPassword", Password));
		//}

		/// <summary>
		/// Decrypts the given cipherText using the given password and returns the decrypted text
		/// </summary>
		/// <param name="cipherText">Encrypted string to decrypt</param>
		/// <param name="password">Password to decrypt the data with</param>
		/// <returns>Decrypted string in Base64 Encoding</returns>
		public string Decrypt(string cipherText, string password)
		{
			CipherText = cipherText;
			Password = password;
			Decrypt();
			return PlainText;
		}

		/// <summary>
		/// Decrypts the given cipherBytes and returns the decrypted bytes
		/// </summary>
		/// <param name="cipherBytes">Encrypted bytes to decrypt</param>
		/// <returns>Decrypted bytes</returns>
		//public byte[] Decrypt(byte[] cipherBytes)
		//{
		//	//return Decrypt(cipherBytes, Toolkit.GetSetting("EncryptionPassword", Password));
		//}

		/// <summary>
		/// Decrypts the given cipherBytes using the given password and returns the decrypted bytes
		/// </summary>
		/// <param name="cipherBytes">Encrypted bytes to decrypt</param>
		/// <param name="password"></param>
		/// <returns>Decrypted bytes</returns>
		public byte[] Decrypt(byte[] cipherBytes, string password)
		{
			CipherBytes = cipherBytes;
			Password = password;
			Decrypt();
			return PlainBytes;
		}

		/// <summary>
		/// Encrypts value in PlainText (or PlainBytes) into CipherText (or CipherText)
		/// </summary>
		public void Encrypt()
		{

			if (_plainBytes == null || _plainBytes.Length == 0)
			{
				// nothing to do
				_cipherBytes = null;
				return;
			}

			// create a memorystream for loading the plain bytes
			MemoryStream enc = new MemoryStream();

			// create a cryptostream to store the resulting encrypted bytes
			CryptoStream cs = new CryptoStream(enc, _encryptor, CryptoStreamMode.Write);

			// load the data into the encrypted buffer
			if (_plainBytes == null)
			{
				// nothing to do???
			}
			else
			{
				cs.Write(_plainBytes, 0, _plainBytes.Length);
			}

			// flush the cryptostream
			cs.FlushFinalBlock();

			// load the data into the encrypted buffer
			_cipherBytes = enc.ToArray();

		}

		/// <summary>
		/// Decrypts value in CipherText (or CipherBytes) into PlainText (or PlainBytes)
		/// </summary>
		public void Decrypt()
		{

			if (_cipherBytes == null || _cipherBytes.Length == 0)
			{
				_plainBytes = null;
				return;
			}

			// create a memorystream for loading the encrypted bytes
			MemoryStream dec = new MemoryStream();

			// create a cryptostream to store the resulting plain bytes
			CryptoStream cs = new CryptoStream(dec, _decryptor, CryptoStreamMode.Write);

			// load the data into the plain buffer
			if (_cipherBytes == null)
			{
				// nothing to do???
			}
			else
			{
				cs.Write(_cipherBytes, 0, _cipherBytes.Length);
			}

			// flush the cryptostream
			cs.FlushFinalBlock();

			// load the data into the plain buffer
			_plainBytes = dec.ToArray();
		}
		#region IDisposable Members
		/// <summary>
		/// Disposes all unmanaged resources
		/// </summary>
		public void Dispose()
		{
			if (_encryptor != null)
			{
				_encryptor.Dispose();
			}
			if (_decryptor != null)
			{
				_decryptor.Dispose();
			}
			if (_aes != null)
			{
				_aes.Clear();
			}

			if (_sha1 != null)
			{
				_sha1.Clear();
			}
			if (_sha256 != null)
			{
				_sha256.Clear();
			}

		}

		#endregion

		SHA1Cng _sha1;
		SHA256Cng _sha256;
	}
}
