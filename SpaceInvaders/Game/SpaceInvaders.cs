using SpaceInvaders.Engine.System;
using SpaceInvaders.Game.Actors;

namespace SpaceInvaders;

public class SpaceInvaders : SdlGame
{
    public SpaceInvaders() 
        : base(new WindowProps("Space Invaders", 800, 800, true))
    {
    }

    public override void OnInitialize()
    {
        this.RegisterActor<GridActor>("WorldGrid");
        this.RegisterActor<PlayerActor>("Player");
    }

    public override void OnUpdate(float deltaTime)
    {
    }

    public override void OnRender()
    {
    }
}