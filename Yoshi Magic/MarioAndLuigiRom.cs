using System;
namespace Yoshi_Magic
{
	public abstract class MarioAndLuigiRom
	{
		/// <summary>
		/// Loads the enemy data for use from the game's ROM
		/// </summary>
		/// <returns>The game's enemy data</returns>
		public abstract void LoadEnemyData();
		/// <summary>
		/// Gets the raw data for this ROM.
		/// </summary>
		public byte[] Data { get; protected set; }
		/// <summary>
		/// Gets the version of this ROM.
		/// </summary>
		public Version ROMVersion { get; protected set; }
	}
	public enum Version
	{
		Unknown = -1,
		NorthAmerica = 0,
		Europe = 1,
		Japan = 2,
		NorthAmericaDemo = 3,
	}
}
