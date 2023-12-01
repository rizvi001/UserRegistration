﻿using System;
using SQLite;
namespace Task1.ViewModels
{
	public class UserModel
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Gender { get; set; }

		public string Phone { get; set; }

		public string Password { get; set; }

		public string Age { get; set; }

		public string DOB { get; set; }
	}
}

