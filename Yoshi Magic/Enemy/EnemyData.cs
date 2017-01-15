using System;

namespace Yoshi_Magic
{
	/// <summary>
	/// A class which represents a set of enemy data. This is not particular to any specific game.
	/// </summary>
	public class EnemyData
	{
		/// <summary>
		/// Count of enemies in Mario and Luigi: Superstar Saga.
		/// </summary>
		[Obsolete("Use the ROM class enemy count")] public const Byte SS_ENEMY_COUNT = 0xBC;
		/// <summary>
		/// Count of enemies in Mario and Luigi: Partners in Time.
		/// </summary>
		[Obsolete("Use the ROM class enemy count")]public const Byte PIT_ENEMY_COUNT = 0x5C;
		/// <summary>
		/// Loads enemy data from the ROM.
		/// </summary>
		/// <param name="ROM">ROM to load the enemy data from.</param>
		/// <exception cref="NotSupportedException">Unknown version of the loaded ROM</exception>
		/// <exception cref="NotImplementedException">Always thrown. Not completed yet.</exception>
		public EnemyData(MarioAndLuigiRom ROM)
		{
			if (ROM is SuperstarSagaRom)
			{
				switch (ROM.ROMVersion)
				{
					case Version.NorthAmerica:
						Offsets = SuperstarSagaRom.NA_ENEMY_DB;
						break;
					case Version.Europe:
						Offsets = SuperstarSagaRom.EU_ENEMY_DB;
						break;
					case Version.Japan:
						Offsets = SuperstarSagaRom.J_ENEMY_DB;
						break;
					case Version.NorthAmericaDemo:
						Offsets = SuperstarSagaRom.NADEMO_ENEMY_DB;
						break;
					default:
						throw new NotSupportedException("Unknown ROM version");
				}
				throw new NotImplementedException();
				int[,] RawData = new int[SS_ENEMY_COUNT, 6];
				byte offset = 0x00;
				for (byte enemy = 0; enemy < SS_ENEMY_COUNT; enemy++)
				{
					//TODO: Fix.
					for (byte stat = 0; stat < 6; stat++)
					{
						switch (stat)
                        {
							case 1:
								offset = 0x04;
								break;
							case 2:
								offset = 0x14;
								break;
							case 4:
								offset = 0x1C;
								break;
						}
						RawData[enemy, stat] = ROM.Data[GetSSDataPointer(enemy, (byte)((stat * 2) + offset))];
					}
				}
				//TODO: Remove - Debug Code
				for (int i = 0; i < RawData.GetLength(1); i++)
				{
					for (int j = 0; j < RawData.GetLength(0); j++)
					{
						Console.Write("{0, -15}", RawData[i, j]);
					}
					Console.WriteLine();
				}
				//TODO: Remove - Debug Code
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets the data pointer for a specific enemy's stat.
		/// </summary>
		/// <param name="Enemy">The enemy to read the data for.</param>
		/// <param name="DataOffset">The offset at what the data is from the pointer.</param>
		/// <returns>A data pointer that can be used to find enemy data for Superstar Saga.</returns>
		/// <remarks>The data pointer is calculated by taking the battle database pointer, subtracting 0x800000 from it,
		/// adding the data offset (the parameter), then adding that to 0x2C multiplied by the enemy ID (the parameter),
		/// and finally adding one to that final value.
		/// <para>As an equation it looks like Offset - 0x800000 + DataOffset + (0x2C * Enemy) + 1.</para></remarks>
		private uint GetSSDataPointer(byte Enemy, byte DataOffset)
		{
			return (uint)(Offsets[0] - 0x800000 + DataOffset + (0x2C * Enemy) + 1);
		}
		private UInt32[] Offsets { get; set; }
	}
}
