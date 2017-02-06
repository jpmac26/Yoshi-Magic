using System;
using System.Collections.Generic;
using System.IO;
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
		protected BinaryReader reader;
		protected BinaryWriter writer;

		public Rom(String filePath)
		{
			byte[] rawData;
			try
			{
				rawData = File.ReadAllBytes(filePath);
			}
			catch (IOException e)
			{
				throw new AggregateException("An error occurred during ROM loading", e);
			}
			Stream = new MemoryStream(rawData);
			reader = new BinaryReader(Stream, Encoding.ASCII);
			writer = new BinaryWriter(Stream, Encoding.ASCII);
		}

		public MemoryStream Stream { get; protected set; }

		/// <summary>
		/// Gets the in-memory copy of the raw data of the game's ROM file
		/// </summary>
		public byte[] RawData
		{
			get
			{
				long currentPosition = Stream.Position;
				Stream.Seek(0, SeekOrigin.Begin);
				byte[] data = new byte[Stream.Length];
				Stream.Read(data, 0, (int)Stream.Length);
				Stream.Seek(currentPosition, SeekOrigin.Begin);
				return data;
			}
		}
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
