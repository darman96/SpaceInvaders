using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class BulletActor : Actor
{
    private Vector2F position;
    private float lifetime = 10f;
    private float currentLifetime = 0f;
    private const float BulletSpeed = 120f;

    public BulletActor(Vector2F position)
    {
        this.position = position;
    }
    
    public override void OnInitialize()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
        this.currentLifetime += deltaTime;
        if (this.currentLifetime > this.lifetime) 
            this.Parent.RemoveActor(this);

        this.position.Y -= BulletSpeed * deltaTime;
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawLine(
            this.position, 
            new Vector2F(this.position.X, this.position.Y + 10),
            Color.Red());
    }
}