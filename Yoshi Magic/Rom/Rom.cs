using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoshi_Magic.Rom
{
	/// <summary>
	/// An abstract class that represents a generic, non-game specific ROM that
	/// is used as the deriving point for other game ROMs.
	/// </summary>
	public abstract class Rom
	{
		/// <summary>
		/// Gets the raw data of the game's ROM file
		/// </summary>
		public byte[] RawData { get; protected set; }
		/// <summary>
		/// Region that this ROM belongs to.
		/// </summary>
		public Version GameVersion { get; protected set; }
	}

	/// <summary>
	/// An enumration of all of the game versions known
	/// </summary>
	public enum Version
	{
		/// <summary>
		/// Unknown game version type.
		/// </summary>
		Unknown = -1,
		/// <summary>
		/// Version released in North America (sometimes referred to as NTSC-U)
		/// </summary>
		NorthAmerica = 0,
		/// <summary>
		/// Version released in Europe (sometimes referred to as PAL)
		/// </summary>
		Europe = 1,
		/// <summary>
		/// Version released in Japan (sometimes referred to as NTSC-J)
		/// </summary>
		Japan = 2,
		/// <summary>
		/// Version for the North American demo
		/// </summary>
		NorthAmericaDemo = 3,
	}
}
