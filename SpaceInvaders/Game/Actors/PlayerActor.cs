using System.Runtime.InteropServices;
using SDL2;
using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class PlayerActor : Actor
{
    private const int PlayerSize = 32;
    private const int BottomOffset = 30;
    private const int PlayerSpeed = 75;
    
    private Rect playerRect;


    private readonly int worldWidth;
    private float leftBound;
    private float rightBound;

    private int bulletCount = 0;

    private bool spaceHeld = false;
    
    public PlayerActor(int worldWidth)
    {
        this.worldWidth = worldWidth;
    }
    
    public override void OnInitialize()
    {
        var windowSize = this.Application!.Window.Size;
        var playerPosition = new Vector2F(
            (windowSize.X - PlayerSize) / 2f,
            windowSize.Y - BottomOffset - PlayerSize);

        this.leftBound = (windowSize.X - this.worldWidth) / 2 + 10;
        this.rightBound = this.leftBound + this.worldWidth - PlayerSize - 20;

        this.playerRect = new Rect(
            playerPosition,
            new Vector2F(PlayerSize, PlayerSize));
    }

    public override void OnUpdate(float deltaTime)
    {
        if (this.Application!.KeyState.IsKeyPressed(KeyCode.Left))
        {
            this.playerRect.Position.X -= PlayerSpeed * deltaTime;
            if (this.playerRect.Position.X < this.leftBound)
                this.playerRect.Position.X = this.leftBound;
        }
        if(this.Application!.KeyState.IsKeyPressed(KeyCode.Right))
        {
            this.playerRect.Position.X += PlayerSpeed * deltaTime;
            if (this.playerRect.Position.X > this.rightBound)
                this.playerRect.Position.X = this.rightBound;
        }

        if (this.Application!.KeyState.IsKeyPressed(KeyCode.Space) && !this.spaceHeld)
        {
            this.spaceHeld = true;
            var windowSize = this.Application!.Window.Size;
            var pos = new Vector2F(this.playerRect.Position.X + PlayerSize / 2f, this.playerRect.Position.Y - 5);
            var bullet = new BulletActor(pos);
            bullet.Initialize(this.Application, this);
            this.RegisterActor(bullet, $"Bullet-{this.bulletCount}");
            this.bulletCount++;
        }
        else if (!this.Application!.KeyState.IsKeyPressed(KeyCode.Space))
            this.spaceHeld = false;
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawRect(this.playerRect, Color.White());
    }
}