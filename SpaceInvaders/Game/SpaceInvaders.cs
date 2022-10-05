using SDL2;
using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
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
    }

    public override void OnUpdate(float deltaTime)
    {
        if (this.Application!.KeyState.IsKeyPressed(KeyCode.Escape))
            System.Environment.Exit(0);
    }

    public override void OnRender()
    {
        this.Renderer.RenderTextCentered(
            "SpaceInvaders",
            this.titlePosition,
            52,
            new SdlFont("SpaceMission.otf"),
            Color.White());
        
        SDL.SDL_Blit
    }
}