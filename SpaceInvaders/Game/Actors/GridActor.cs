using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class GridActor : Actor
{
    private Rect gridBorderRect;
    private Color gridColor;
    
    public override void OnInitialize()
    {
        var windowSize = this.Application!.Window.Size;
        var gridSize = new Vector2I(700, 600);
        var gridPosition = new Vector2I((windowSize.X - gridSize.X) / 2, 20);
        this.gridBorderRect = new Rect(gridPosition, gridSize);
        this.gridColor = Color.White();
    }

    public override void OnUpdate(float deltaTime)
    {
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawRect(this.gridBorderRect, this.gridColor, true);
    }
}