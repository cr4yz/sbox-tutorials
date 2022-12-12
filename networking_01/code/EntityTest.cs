
using Sandbox;

public partial class EntityTest : Entity
{

	[Net]
	public int NetworkedInt { get; set; }
	[Net]
	public string NetworkedString { get; set; }

	public override void Spawn()
	{
		base.Spawn();

		// Server-side initialization

		NetworkedInt = 55;
	}

	public override void ClientSpawn()
	{
		base.ClientSpawn();

		// Client-side initialization
	}

	[ClientRpc]
	public void ShowDeathMessage(string deathMessage )
	{
		if ( Game.IsServer )
		{
			Log.Error( "THIS SHOULDN'T CALL ON THE SERVER!" );
			return;
		}

		Log.Error( deathMessage );
	}

	[Event.Tick]
	public void OnTick()
	{
		var lineNumber = Game.IsClient ? 0 : 1;
		var color = Game.IsClient ? Color.Green : Color.Yellow;
		DebugOverlay.ScreenText( "NetworkedInt value is: " + NetworkedInt, new Vector2( 64, 64 ), lineNumber, color );

		if ( Game.IsServer )
		{
			ShowDeathMessage( "You died" );

			ShowDeathMessage( To.Everyone, "EVeryone died" );
			ShowDeathMessage( To.Single( this ), "You died" );
		}
	}

}
