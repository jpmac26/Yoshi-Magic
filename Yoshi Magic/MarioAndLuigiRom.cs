using System;
using Yoshi_Magic.Rom;

namespace Yoshi_Magic
{
	[Obsolete("Use the classes in the Rom namespace")]
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
		public Rom.Version ROMVersion { get; protected set; }
	}
}
