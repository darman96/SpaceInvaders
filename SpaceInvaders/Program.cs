using SpaceInvaders.Engine;

namespace SpaceInvaders;

public static class Program
{
    public static void Main(string[] args)
    {
        var app = new Application(
            new WindowProps(
                "SpaceInvaders",
                1024,
                768,
                true));
        app.Run();
    }
}