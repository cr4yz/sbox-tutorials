
using System;

namespace Sandbox;

public partial class MyGame : Sandbox.Game
{

	public MyGame()
	{
		if ( IsClient )
		{
			_ = new Hud();
		}
	}

}
