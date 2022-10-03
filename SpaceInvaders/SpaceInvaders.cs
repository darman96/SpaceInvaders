using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Math;
using SpaceInvaders.Engine.System;

namespace SpaceInvaders;

public class SpaceInvaders : SdlGame
{
    public SpaceInvaders() 
        : base(new WindowProps("Space Invaders", 1024, 768, true))
    {
    }
    
    public override void Init()
    {
    }

    public override void Update(float deltaTime)
    {
    }

    public override void Render()
    {
        this.Renderer.DrawRect(
            new Vector2I(10, 10),
            new Vector2I(100, 100),
            new Color(255, 0, 0));
        
        this.Renderer.DrawRect(
            new Vector2I(120, 120),
            new Vector2I(100, 100),
            new Color(255, 0, 0),
            true);
    }
}