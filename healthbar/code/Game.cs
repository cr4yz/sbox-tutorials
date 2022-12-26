
using Sandbox;

public partial class MyGame : GameManager
{
	public MyGame()
	{
		if ( Game.IsClient )
		{
			_ = new Hud();
		}
	}

	public override void ClientJoined( IClient cl )
	{
		base.ClientJoined( cl );

		cl.Pawn = new Pawn();
	}

}
