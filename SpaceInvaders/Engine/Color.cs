namespace SpaceInvaders.Engine;

public struct Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }
    public int A { get; set; }

    public Color(int r, int g, int b, int a = 255)
    {
        this.R = r;
        this.G = g;
        this.B = b;
        this.A = a;
    }
}