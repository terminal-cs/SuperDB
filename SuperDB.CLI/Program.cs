using SuperDB;

Database DB = new();

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