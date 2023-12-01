using System;
using SQLite;

namespace Task1.Interface
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

