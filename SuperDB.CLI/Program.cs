using SuperDB;

Console.WriteLine("Hello, World!");
Console.Write("Please type file name to load: ");
Database DB = new Database(File.ReadAllBytes(Console.ReadLine()));

while (true)
{
	try
	{
		string[] Input = Console.ReadLine().Split(' ');

		switch (Input[0].ToLower())
		{
			case "read":
				// todo
				break;
			case "write":
				// todo
				break;
			case "remove":
				DB.Remove(Input[1]);
				break;
		}
	}
	catch (Exception E)
	{
		Console.WriteLine($"Fatal: {E.Message}");
	}
}