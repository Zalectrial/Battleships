using Microsoft.VisualBasic;
using System;
namespace BattleShipConversion
{
	/// <summary>
	/// The ISeaGrid defines the read only interface of a Grid. This
	/// allows each player to see and attack their opponents grid.
	/// </summary>
	public abstract class ISeaGrid
	{
        public int Width { get; private set; }

        public int Height { get; private set; }

		/// <summary>
		/// Indicates that the grid has changed.
		/// </summary>
        public event EventHandler Changed;

        protected void OnChanged()
        {
            if (Changed != null)
                Changed (this, EventArgs.Empty);
        }

		/// <summary>
		/// Provides access to the given row/column
		/// </summary>
		/// <param name="row">the row to access</param>
		/// <param name="column">the column to access</param>
		/// <value>what the player can see at that location</value>
		/// <returns>what the player can see at that location</returns>
        public abstract TileView Item (int row, int column);

		/// <summary>
		/// Mark the indicated tile as shot.
		/// </summary>
		/// <param name="row">the row of the tile</param>
		/// <param name="col">the column of the tile</param>
		/// <returns>the result of the attack</returns>
        public abstract AttackResult HitTile(int row, int col);
	}
}
