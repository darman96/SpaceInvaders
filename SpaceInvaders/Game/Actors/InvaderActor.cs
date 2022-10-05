using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class InvaderActor : Actor
{
    private Vector2F position;
    private Vector2F size;

    public void SetPosition(Vector2F position)
    {
        this.position = position;
    }

    public void SetSize(Vector2F size)
    {
        this.size = size;
    }

    public Vector2F GetPosition()
        => this.position;
    
    public override void OnInitialize()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawRect(
            this.position, 
            this.size,
            Color.White(),
            true);
    }
}