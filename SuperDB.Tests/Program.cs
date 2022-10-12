using SuperDB;

Database DB = new();
Random R = new();

// Simulate 100000 users
for (int I = 0; I < 1000000; I++)
{
	string Name = R.Next(100, 9999999).ToString();

	// simulate several fields, 8 bytes each
	for (int I2 = 0; I2 < 100; I2++)
	{
		DB.WriteDouble(Name + "." + I, R.NextDouble());
	}
}

// Save
DB.Export("Test.sdb");