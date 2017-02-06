using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yoshi_Magic.Rom
{
	/// <summary>
	/// A class representing a ROM from the Mario and Luigi: Superstar Saga game
	/// </summary>
	public class SuperstarSagaRom : MarioAndLuigiRom
	{

		public const String VersionPrefix = "MARIO&LUIGI";
		public const String NorthAmericanDemoVersionString = "M&L DEMO USAB88E";

		public const String NorthAmericanVersionSuffix = "UA88E";
		public const String EuropeanVersionSuffix = "PA88P";
		public const String JapaneseVersionSuffix = "JA88J";

		public const long VersionOffset = 0x500;
		public const int VersionStringLength = 16;

		public SuperstarSagaRom(String filePath) : base(filePath)
		{
			this.GameVersion = FindVersion();
			Stream.Seek(0, System.IO.SeekOrigin.Begin);	
		}

		private Version FindVersion()
		{
			Stream.Seek(VersionOffset, System.IO.SeekOrigin.Begin);
			String version = new String(reader.ReadChars(VersionStringLength));
			if (version.Equals(NorthAmericanDemoVersionString))
			{
				return Version.NorthAmericaDemo;
			}
			else if (version.StartsWith(VersionPrefix))
			{
				switch (version.Substring(VersionPrefix.Length - 1))
				{
					case NorthAmericanVersionSuffix:
						return Version.NorthAmerica;
					case EuropeanVersionSuffix:
						return Version.Europe;
					case JapaneseVersionSuffix:
						return Version.Japan;
				}
			}
			return Version.Unknown;
		}
	}
}
