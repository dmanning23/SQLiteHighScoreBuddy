﻿using HighScoreBuddy;
using NUnit.Framework;

namespace SQLiteHighScoreBuddy.Tests
{
	[TestFixture]
	public class IsHighScoreTests
	{
		IHighScoreTable _highScores;

		private const string tableName = "testList";

		[SetUp]
		public void Setup()
		{
			_highScores = new SqlHighScoreTable();
			_highScores.InitializeDatabase();
			_highScores.ClearHighScoreList(tableName);
		}

		[Test]
		public void ZeroList()
		{
			Assert.IsFalse(_highScores.IsHighScore(tableName, 100, 0));
		}

		[Test]
		public void EmptyTable()
		{
			Assert.IsTrue(_highScores.IsHighScore(tableName, 100, 10));
		}

		[Test]
		public void HalfTable()
		{
			for (uint i = 0; i < 5; i++)
			{
				_highScores.AddHighScore(tableName, i * 100, i.ToString());
			}

			Assert.IsTrue(_highScores.IsHighScore(tableName, 100, 10));
		}

		[Test]
		public void FullTable_IsHighScore()
		{
			for (uint i = 0; i < 10; i++)
			{
				_highScores.AddHighScore(tableName, i * 100, i.ToString());
			}

			Assert.IsTrue(_highScores.IsHighScore(tableName, 1000, 10));
		}

		[Test]
		public void FullTable_NotHighScore()
		{
			for (uint i = 10; i < 20; i++)
			{
				_highScores.AddHighScore(tableName, i * 100, i.ToString());
			}

			Assert.IsFalse(_highScores.IsHighScore(tableName, 10, 10));
		}

		[Test]
		public void FullTable_NotHighScore_2()
		{
			for (uint i = 10; i < 40; i++)
			{
				_highScores.AddHighScore(tableName, i * 100, i.ToString());
			}

			Assert.IsFalse(_highScores.IsHighScore(tableName, 100, 10));
		}
	}
}
