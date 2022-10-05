using SpaceInvaders.Engine.Math;
using SpaceInvaders.Engine.System;

namespace SpaceInvaders.Game;

public class SpaceInvaders : Game<SdlApplication>
{
    private readonly Vector2F titlePosition;
    private readonly SdlFont titleFont;
    public SpaceInvaders() 
        : base(new WindowProps("Space Invaders", 600, 650, true))
    {
        this.titlePosition = new Vector2F(300f, 48f);
        this.titleFont = new SdlFont("Assets.SpaceMission.otf");
    }
}