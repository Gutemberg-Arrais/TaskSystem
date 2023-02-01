﻿using System;
using TaskSystem.Enums;

namespace TaskSystem.Models
{
	public class TaskModel
	{


		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public EStatusTask Status { get; set; }
	}
}

