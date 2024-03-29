﻿using SQLite;

namespace SQLiteHighScoreBuddy.Models
{
	[Table("Scores")]
	public class Score
	{
		[PrimaryKey, AutoIncrement]
		public int? Id { get; set; }

		public uint Points { get; set; }

		[MaxLength(16)]
		public string Initials { get; set; }

		public int DayId { get; set; }

		public int HighScoreListId { get; set; }
	}
}
