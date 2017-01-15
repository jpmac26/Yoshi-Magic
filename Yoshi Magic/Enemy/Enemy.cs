using System;

namespace Yoshi_Magic.Enemy
{
	/// <summary>
	/// Represents any type of enemy (normal field enemy, boss) in a Mario and Luigi game. Has stats such as HP/POW/DEF/etc.
	/// </summary>
	public class Enemy
	{
		/// <summary>
		/// The enemy's name. This will affect the tooltip that is shown when selected with the cursor.
		/// </summary>
		public String Name { get; set; }
		/// <summary>
		/// The pointer to where this enemy's name is located in ROM.
		/// </summary>
		public String NamePointer { get; set; }
		/// <summary>
		/// The enemy's level. In Superstar Saga, this affects the chance of falling, and in Bowser's Inside Story, this
		/// affects the amount of damage a player will deal to the enemy.
		/// </summary>
		public Int32 Level { get; set; }
		/// <summary>
		/// Maximum Health that this enemy has. Enemies will start with this health (and cannot heal over this amount) in
		/// battle.
		/// </summary>
		public Int32 MaxHp { get; set; }
		/// <summary>
		/// Power affects the amount of damage the enemy will deal a player on a successful attack. Enemies in Mario and
		/// Luigi: Superstar Saga do not have a Power stat.
		/// </summary>
		public Int32? Power { get; set; }
		/// <summary>
		/// Defense affects the amount of damage the enemy will take when a player deals a successful attack to this
		/// enemy (so long as this enemy can take damage in it's state). 
		/// </summary>
		public Int32 Defense { get; set; }
		/// <summary>
		/// Speed affects turn order. A higher speed will give the enemy a chance to attack first before either Mario or
		/// Luigi.
		/// </summary>
		public Int32 Speed { get; set; }
		/// <summary>
		/// The amount of coins earned by defeating this enemy.
		/// </summary>
		public Int32 Experience { get; set; }
		/// <summary>
		/// The amount of coins earned by defeating this enemy.
		/// </summary>
		public Int32 Coins { get; set; }
	}
}
