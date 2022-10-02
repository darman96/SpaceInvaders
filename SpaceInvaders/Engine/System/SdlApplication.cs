using SDL2;
using SpaceInvaders.Engine.Game;

namespace SpaceInvaders.Engine.System;

public class SdlApplication : IApplication
{
    public IWindow Window => this.sdlWindow;
    public IRenderer Renderer => this.sdlRenderer;

    private readonly IGame game;
    private readonly SdlWindow sdlWindow;
    private readonly SdlRenderer sdlRenderer;

    public SdlApplication(WindowProps windowProps, IGame game)
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

        this.game = game;
    }

    public void Run()
    {
        this.game.Init();
        while (!this.sdlWindow.ShouldClose())
        {
            this.sdlWindow.PollEvents();
            this.game.Update(1.0f);
            
            this.sdlWindow.Clear();
            this.game.Render();
            
            this.sdlRenderer.Present();
        }
        
        this.sdlRenderer.Destroy();
        this.sdlWindow.Destroy();
    }
}