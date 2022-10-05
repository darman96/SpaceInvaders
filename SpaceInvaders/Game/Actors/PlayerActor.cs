using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class PlayerActor : Actor
{
    private int playerSize = 32;
    private int bottomOffset = 50;
    private Rect playerRect;
    
    public override void OnInitialize()
    {
        var windowSize = this.Application!.Window.Size;
        var playerPosition = new Vector2F(
            (windowSize.X - this.playerSize) / 2f,
            windowSize.Y - this.bottomOffset - this.playerSize);

        this.playerRect = new Rect(
            playerPosition,
            new Vector2F(this.playerSize, this.playerSize));
    }

    public override void OnUpdate(float deltaTime)
    {
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawRect(this.playerRect, Color.White());
    }
}