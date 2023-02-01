using System;
using System.ComponentModel;

namespace TaskSystem.Enums
{
	public enum EStatusTask
	{
		[Description("Task Open")]
		Open = 1,
		[Description("Task In Progress")]
		InProgress = 2,
		[Description("Task Finished")]
		Finish = 3
	}
}

