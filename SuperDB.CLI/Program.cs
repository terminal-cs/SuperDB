using SuperDB;

Database DB = new();

// Publsh: dotnet publish -c release --self-contained -r linux-x64

while (true)
{
	string? Input = Console.ReadLine();
	if (Input == null || Input.Length == 0)
	{
		continue;
	}
	string[] Split = Input.Split(' ');

	try
	{
		switch (Split[0])
		{
			#region Export
			case "export":
				if (DB == null)
				{
					Console.WriteLine("Databse not loaded.");
					continue;
				}
				DB.Export(Split[1]);
				Console.WriteLine($"Saved database to '{Split[1]}'.");
				break;
			#endregion
			#region Load
			case "load":
				DB = new(File.ReadAllBytes(Split[1]));
				Console.WriteLine($"Loaded database from file '{Split[1]}'.");
				break;
			#endregion
			#region Read
			case "read":
				switch (Split[1])
				{
					case "string":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadString(Split[2]));
						break;
					case "ulong":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadULong(Split[2]));
						break;
					case "long":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadLong(Split[2]));
						break;
					case "uint":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadUInt(Split[2]));
						break;
					case "int":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadInt(Split[2]));
						break;
					case "ushort":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadUShort(Split[2]));
						break;
					case "short":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadUShort(Split[2]));
						break;
					case "double":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadDouble(Split[2]));
						break;
					case "float":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadFloat(Split[2]));
						break;
					case "byte":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						Console.WriteLine(DB.ReadByte(Split[2]));
						break;
					default:
						Console.WriteLine($"Unknown or unsupported type '{Split[1]}'");
						break;
				}
				break;
			#endregion
			#region Write
			case "write":
				switch (Split[1])
				{
					case "string":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteString(Split[2], Split[3]);
						break;
					case "ulong":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteULong(Split[2], ulong.Parse(Split[3]));
						break;
					case "long":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteLong(Split[2], long.Parse(Split[3]));
						break;
					case "uint":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteUInt(Split[2], uint.Parse(Split[3]));
						break;
					case "int":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteInt(Split[2], int.Parse(Split[3]));
						break;
					case "ushort":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteUShort(Split[2], ushort.Parse(Split[3]));
						break;
					case "short":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteShort(Split[2], short.Parse(Split[3]));
						break;
					case "double":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteDouble(Split[2], double.Parse(Split[3]));
						break;
					case "float":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteFloat(Split[2], float.Parse(Split[3]));
						break;
					case "byte":
						if (DB == null)
						{
							Console.WriteLine("Database is not loaded.");
							continue;
						}
						DB.WriteByte(Split[2], byte.Parse(Split[3]));
						break;
					default:
						Console.WriteLine($"Unknown or unsupported type '{Split[1]}'");
						break;
				}
				break;
			#endregion
			#region Remove
			case "remove":
				if (DB == null)
				{
					Console.Write("No database is loaded.");
					continue;
				}
				DB.Remove(Split[1]);
				Console.WriteLine($"Removed entry '{Split[1]}'.");
				break;
			#endregion
			#region List
			case "list":
				if (DB == null)
				{
					Console.Write("No database is loaded.");
					continue;
				}
				string[] T = DB.List();
				if (T.Length == 0)
				{
					Console.WriteLine("Nothing to display.");
					continue;
				}
				for (int I = 0; I < T.Length; I++)
				{
					Console.WriteLine(T[I]);
				}
				break;
			#endregion
			#region Exit
			case "exit":
				Environment.Exit(0);
				break;
			#endregion
			#region Default
			default:
				Console.WriteLine($"Unrecognized command '{Split[0]}'.");
				break;
			#endregion
		}
	}
	catch (Exception E)
	{
		Console.WriteLine($"Fatal: {E.Message}");
	}
}