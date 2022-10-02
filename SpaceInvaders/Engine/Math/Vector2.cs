namespace SpaceInvaders.Engine.Math;

public class Vector2I
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2I()
        : this(0, 0) {}

    public Vector2I(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public class Vector2F
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2F()
        : this(0f, 0f) {}

    public Vector2F(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
}