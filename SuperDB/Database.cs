using System.Text;
using System.IO;
using System.Collections.Generic;
using System;

namespace SuperDB
{
	public class Database
	{
		public Database(byte[] Buffer)
		{
			BinaryReader Reader = new BinaryReader(new MemoryStream(Buffer));
			InternalDB = new Dictionary<string, byte[]>();

			while (Reader.BaseStream.Position < Reader.BaseStream.Length)
			{
				InternalDB.Add(Reader.ReadString(), Reader.ReadBytes(Reader.ReadInt32()));
			}
		}
		public Database()
		{
			InternalDB = new Dictionary<string, byte[]>();
		}

		#region Direct Methods

		public void WriteString(string Name, string Value)
		{
			if (!TryWriteString(Name, Value))
			{
				throw new System.Exception("String write error");
			}
		}
		public string ReadString(string Name)
		{
			if (!TryReadString(Name, out string S))
			{
				throw new System.Exception("String read error");
			}
			return S;
		}

		public void WriteULong(string Name, ulong Value)
		{
			if (!TryWriteULong(Name, Value))
			{
				throw new System.Exception("64-bit insigned number write error");
			}
		}
		public ulong ReadULong(string Name)
		{
			if (!TryReadULong(Name, out ulong L))
			{
				throw new System.Exception("64-bit insigned number read error");
			}
			return L;
		}

		public void WriteLong(string Name, long Value)
		{
			if (!TryWriteLong(Name, Value))
			{
				throw new System.Exception("64-bit number write error");
			}
		}
		public long ReadLong(string Name)
		{
			if (!TryReadLong(Name, out long L))
			{
				throw new System.Exception("64-bit number read error");
			}
			return L;
		}

		public void WriteUInt(string Name, uint Value)
		{
			if (!TryWriteUInt(Name, Value))
			{
				throw new System.Exception("32-bit unsigned number write error");
			}
		}
		public uint ReadUInt(string Name)
		{
			if (!TryReadUInt(Name, out uint I))
			{
				throw new System.Exception("32-bit unsigned number read error");
			}
			return I;
		}

		public void WriteInt(string Name, int Value)
		{
			if (!TryWriteInt(Name, Value))
			{
				throw new System.Exception("32-bit number write error");
			}
		}
		public int ReadInt(string Name)
		{
			if (!TryReadInt(Name, out int I))
			{
				throw new System.Exception("32-bit number read error");
			}
			return I;
		}

		public void WriteUShort(string Name, ushort Value)
		{
			if (!TryWriteUShort(Name, Value))
			{
				throw new System.Exception("16-bit unsigned number write error");
			}
		}
		public ushort ReadUShort(string Name)
		{
			if (!TryReadUShort(Name, out ushort S))
			{
				throw new System.Exception("16-bit unsigned number read error");
			}
			return S;
		}

		public void WriteShort(string Name, short Value)
		{
			if (!TryWriteShort(Name, Value))
			{
				throw new System.Exception("16-bit number write error");
			}
		}
		public short ReadShort(string Name)
		{
			if (!TryReadShort(Name, out short S))
			{
				throw new System.Exception("16-bit number read error");
			}
			return S;
		}

		public void WriteDouble(string Name, double Value)
		{
			if (!TryWriteDouble(Name, Value))
			{
				throw new System.Exception("64-bit floating-point number write error");
			}
		}
		public double ReadDouble(string Name)
		{
			if (!TryReadDouble(Name, out double D))
			{
				throw new System.Exception("64-bit floating-point number read error");
			}
			return D;
		}

		public void WriteFloat(string Name, float Value)
		{
			if (!TryWriteFloat(Name, Value))
			{
				throw new System.Exception("32-bit floating-point number write error");
			}
		}
		public float ReadFloat(string Name)
		{
			if (!TryReadFloat(Name, out float F))
			{
				throw new System.Exception("32-bit floating-point number read error");
			}
			return F;
		}

		public void WriteByte(string Name, byte Value)
		{
			if (!TryWriteByte(Name, Value))
			{
				throw new System.Exception("8-bit number write error");
			}
		}
		public byte ReadByte(string Name)
		{
			if (!TryReadByte(Name, out byte B))
			{
				throw new System.Exception("8-bit number read error");
			}
			return B;
		}

		public void Remove(string Name)
		{
			if (!TryRemove(Name))
			{
				throw new System.Exception($"Cannot remove entry");
			}
		}


		public void WriteObject(string Name, object Value)
		{
			if (!TryWriteObj(Name, Value))
			{
				throw new System.Exception("Object write error");
			}
		}

		public object ReadObject(string Name)
		{
			if (!TryReadObj(Name, out object O))
			{
				throw new System.Exception("Object read error");
			}
			return O;
		}

		#endregion

		#region Try Methods

		public bool TryWriteString(string Name, string Value)
		{
			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Encoding.UTF8.GetBytes(Value));
				return true;
			}
			InternalDB[Name] = Encoding.UTF8.GetBytes(Value);
			return true;
		}
		public bool TryReadString(string Name, out string S)
		{
			if (InternalDB.ContainsKey(Name))
			{
				S = Encoding.UTF8.GetString(InternalDB[Name]);
				return true;
			}
			S = string.Empty;
			return false;
		}

		public bool TryWriteULong(string Name, ulong Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadULong(string Name, out ulong L)
		{
			if (InternalDB.ContainsKey(Name))
			{
				L = BitConverter.ToUInt64(InternalDB[Name],0);
				return true;
			}
			L = 0;
			return false;
		}


		public bool TryWriteObj(string Name, object Value)
		{
			byte[] Binary = (byte[])Value;

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadObj(string Name, out object O)
		{
			if (InternalDB.ContainsKey(Name))
			{
				O = InternalDB[Name];
				return true;
			}
			O = 0;
			return false;
		}


		public bool TryWriteLong(string Name, long Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadLong(string Name, out long L)
		{
			if (InternalDB.ContainsKey(Name))
			{
				L = BitConverter.ToInt64(InternalDB[Name],0);
				return true;
			}
			L = 0;
			return false;
		}

		public bool TryWriteUInt(string Name, uint Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadUInt(string Name, out uint I)
		{
			if (InternalDB.ContainsKey(Name))
			{
				I = BitConverter.ToUInt32(InternalDB[Name],0);
				return true;
			}
			I = 0;
			return false;
		}

		public bool TryWriteInt(string Name, int Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadInt(string Name, out int I)
		{
			if (InternalDB.ContainsKey(Name))
			{
				I = BitConverter.ToInt32(InternalDB[Name],0);
				return true;

			}
			I = 0;
			return false;
		}

		public bool TryWriteUShort(string Name, ushort Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadUShort(string Name, out ushort S)
		{
			if (InternalDB.ContainsKey(Name))
			{
				S = BitConverter.ToUInt16(InternalDB[Name],0);
				return true;
			}
			S = 0;
			return false;
		}

		public bool TryWriteShort(string Name, short Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadShort(string Name, out short S)
		{
			if (InternalDB.ContainsKey(Name))
			{
				S = BitConverter.ToInt16(InternalDB[Name],0);
				return true;
			}
			S = 0;
			return false;
		}

		public bool TryWriteDouble(string Name, double Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadDouble(string Name, out double D)
		{
			if (InternalDB.ContainsKey(Name))
			{
				D = BitConverter.ToDouble(InternalDB[Name],0);
				return true;
			}
			D = 0;
			return false;
		}

		public bool TryWriteFloat(string Name, float Value)
		{
			byte[] Binary = BitConverter.GetBytes(Value);

			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, Binary);
				return true;
			}
			InternalDB[Name] = Binary;
			return true;
		}
		public bool TryReadFloat(string Name, out float F)
		{
			if (InternalDB.ContainsKey(Name))
			{
				F = BitConverter.ToSingle(InternalDB[Name],0);
				return true;
			}
			F = 0;
			return false;
		}

		public bool TryWriteByte(string Name, byte Value)
		{
			if (!InternalDB.ContainsKey(Name))
			{
				InternalDB.Add(Name, new byte[] { Value });
				return true;
			}
			InternalDB[Name] = new byte[] { Value };
			return true;
		}
		public bool TryReadByte(string Name, out byte B)
		{
			if (InternalDB.ContainsKey(Name))
			{
				B = InternalDB[Name][0];
				return true;
			}
			B = 0;
			return false;
		}

		public bool TryRemove(string Name)
		{
			if (!InternalDB.ContainsKey(Name))
			{
				return false;
			}
			InternalDB.Remove(Name);
			return true;
		}

		#endregion

		#region Fields

		private readonly Dictionary<string, byte[]> InternalDB;

		#endregion

		#region Misc

		/// <summary>
		/// Exports all data to a file.
		/// </summary>
		/// <returns></returns>
		public void Export(string PathToFile)
		{
			File.WriteAllBytes(PathToFile, Export());
		}
		/// <summary>
		/// Exports all data to an array.
		/// </summary>
		/// <returns>Raw binary for the database.</returns>
		public byte[] Export()
		{
			BinaryWriter Writer = new BinaryWriter(new MemoryStream());

			foreach (KeyValuePair<string, byte[]> KVP in InternalDB)
			{
				Writer.Write(KVP.Key);
				Writer.Write(KVP.Value.Length);
				Writer.Write(KVP.Value);
			}

			return ((MemoryStream)Writer.BaseStream).ToArray();
		}

		#endregion
	}
}
