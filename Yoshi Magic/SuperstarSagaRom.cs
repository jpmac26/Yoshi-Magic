using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yoshi_Magic
{
	/// <summary>
	/// Represents a Mario and Luigi: Superstar Saga ROM and contains the functions and properties specific. Superstar 
	/// Saga was the first in the Mario and Luigi series, released on the Gameboy Advance.
	/// </summary>
	public class SuperstarSagaRom : MarioAndLuigiRom
	{
		/// <summary>
		/// Defines the size of the game's RAM.
		/// </summary>
		public const UInt16 RAM_SIZE = 0x4000;
		/// <summary>
		/// The game's unique identifier.
		/// </summary>
		public const String GAME_IDENTIFIER = "MARIO&LUIGIUA88E";
		/// <summary>
		/// Defines the location of the game's enemy database for the North American version of the ROM.
		/// The first value is the enemy database itself, the second is the arrangement database, the third is the
		/// battle database, the last three an unknown pointer (rndpointer, rpbank and rbgdbase in original version).
		/// </summary>
		public static readonly UInt32[] NA_ENEMY_DB = { 0x7B514, 0x7B8C4, 0x80668, 0x123300, 0x22B78, 0xFC30C };
		/// <summary>
		/// Defines the location of the game's enemy database for the European version of the ROM.
		/// The first value is the enemy database itself, the second is the arrangement database, the third is the
		/// battle database, the last three an unknown pointer (rndpointer, rpbank and rbgdbase in original version).
		/// </summary>
		public static readonly UInt32[] EU_ENEMY_DB = { 0x7BD50, 0x7C100, 0x80EA4, 0x1240A4, 0x22B8C, 0xFCB48 };
		/// <summary>
		/// Defines the location of the game's enemy database for the Japanese version of the ROM.
		/// The first value is the enemy database itself, the second is the arrangement database, the third is the
		/// battle database, the last three an unknown pointer (rndpointer, rpbank and rbgdbase in original version).
		/// </summary>
		public static readonly UInt32[] J_ENEMY_DB  = { 0x7C1AC, 0x7C57C, 0x81344, 0x11B264, 0x22C6C, 0xF3A08 };
		/// <summary>
		/// Defines the location of the game's enemy database for the North American Demo version of the ROM.
		/// The first value is the enemy database itself, the second is the arrangement database, the third is the
		/// battle database, the last three an unknown pointer (rndpointer, rpbank and rbgdbase in original version).
		/// </summary>
		public static readonly UInt32[] NADEMO_ENEMY_DB = { 0x6645C, 0x6680C, 0x6B5B0, 0x10DF00, 0xD824, 0xE7284 };

		/// <summary>
		/// Creates a new instance for methods and functions specific to the Mario and Luigi: Superstar Saga. This loads the ROM, and verifies
		/// whether this is a valid copy of Mario and Luigi: Superstar Saga.
		/// </summary>
		/// <param name="Path">Path to the ROM file</param>
		/// <exception cref="IOException">If an IO error (not found, permission denied, etc) was caught while reading the ROM.</exception>
		/// <exception cref="NotSupportedException">If the loaded file is not a valid ROM of Mario and Luigi: Superstar Saga</exception>
		public SuperstarSagaRom(String Path)
		{
			try
			{
				Data = Bits.OpenFile(Path);
			}
			catch (IOException)
			{
				throw;
			}
			if (Bits.GetString(Data, 0xA0, 16) != GAME_IDENTIFIER)
			{
				throw new NotSupportedException("This game is not Mario and Luigi: Superstar Saga.");
			}
            RAMData = new byte[RAM_SIZE];
			//TODO: Read ROM version on open.
		}
		/// <summary>
		/// Loads a map onto a form.
		/// </summary>
		/// <exception cref="NotImplementedException">Always thrown; not implemented yet.</exception>
		public void LoadMap()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Loads enemy data.
		/// </summary>
		/// <returns></returns>
		public override void LoadEnemyData()
		{
			this.EnemyData = new EnemyData(this);
		}
		/// <summary>
		/// Gets the RAM data.
		/// </summary>
		public byte[] RAMData { get; private set; }
		public EnemyData EnemyData { get; private set; }
		
	}
}
