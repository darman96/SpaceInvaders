using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Math;
using SpaceInvaders.Engine.System;
using SpaceInvaders.Game.Actors;

namespace SpaceInvaders.Game;

public class SpaceInvaders : SdlGame
{
    private readonly Vector2F titlePosition;
    public SpaceInvaders() 
        : base(new WindowProps("Space Invaders", 600, 650, true))
    {
        this.titlePosition = new Vector2F(300f, 48f);
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
        this.Renderer.RenderTextCentered(
            "SpaceInvaders",
            this.titlePosition,
            48,
            new Font("SpaceMission.otf"),
            Color.White());
    }
}