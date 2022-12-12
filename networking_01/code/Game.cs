
using Sandbox;

public partial class MyGame : GameManager
{

	[Net]
	public EntityTest TestingEntity { get; set; }

	public MyGame()
	{
		if ( Game.IsServer )
		{
			TestingEntity = new EntityTest();
		}
	}

	public override void ClientJoined( IClient cl )
	{
		base.ClientJoined( cl );

		// cl.Name has joined the game
		// cl.Pawn = new Entity()...
	}

	public override void ClientDisconnect( IClient cl, NetworkDisconnectionReason reason )
	{
		base.ClientDisconnect( cl, reason );

		//cl.Name has left the game
	}

}
