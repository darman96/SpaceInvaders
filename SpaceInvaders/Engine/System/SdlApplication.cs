using SDL2;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Engine.System;

public class SdlApplication : IApplication
{
    public IWindow Window => this.sdlWindow;
    public IRenderer Renderer => this.sdlRenderer;
    public IKeyState KeyState => this.sdlKeyState;
    
    private const float DeltaLowLimit = 0.0167f;
    private const float DeltaHighLimit = 0.1f;
    
    private SdlWindow sdlWindow = default!;
    private SdlRenderer sdlRenderer = default!;
    private SdlKeyState sdlKeyState = default!;
    private SdlFont fpsCounterFont = default!;
    
    private float DeltaTime
    {
        get
        {
            var currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var delta = (currentTime - this.lastTime) / 1000f;
            this.lastTime = currentTime;

            return delta switch
            {
                < DeltaLowLimit => DeltaLowLimit,
                > DeltaHighLimit => DeltaHighLimit,
                _ => delta
            };
        }
    }
    private long lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

    private bool isInitialized = false;

    public void Initialize(WindowProps windowProps)
    {
        var windowHandle = SDL.SDL_CreateWindow(
            windowProps.Title,
            SDL.SDL_WINDOWPOS_CENTERED,
            SDL.SDL_WINDOWPOS_CENTERED,
            windowProps.Width, windowProps.Height,
            0 | SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN);

        var rendererHandle = SDL.SDL_CreateRenderer(
            windowHandle,
            -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        SDL.SDL_RenderSetVSync(rendererHandle, windowProps.Vsync ? 1 : 0);
        
        this.sdlWindow = new SdlWindow(windowHandle, rendererHandle);
        this.sdlRenderer = new SdlRenderer(rendererHandle);
        this.sdlKeyState = new SdlKeyState();
        this.fpsCounterFont = new SdlFont("Assets.SpaceMission.otf");
    }

    public void Run()
    {
        if (!isInitialized)
            throw new Exception("Application was not initialized!");
        
        while (!this.sdlWindow.ShouldClose())
        {
            this.sdlWindow.PollEvents();
            this.sdlKeyState.Update();

            this.sdlWindow.Clear();
            
            this.Renderer.RenderText(
                $"FPS:{(int)(60f / this.DeltaTime)}", 
                new Vector2F(10, 5),
                28,
                fpsCounterFont,
                Color.White());

            this.sdlRenderer.Present();
        }
        
        this.sdlRenderer.Destroy();
        this.sdlWindow.Destroy();
    }
}