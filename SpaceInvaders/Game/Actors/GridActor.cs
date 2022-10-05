using SpaceInvaders.Engine;
using SpaceInvaders.Engine.Game;
using SpaceInvaders.Engine.Math;

namespace SpaceInvaders.Game.Actors;

public class GridActor : Actor
{
    private enum Direction
    {
        Left,
        Right
    }

    private const int Columns = 11;
    private const int Rows = 5;
    private const int InvaderSpacing = 10;
    private const int InvaderSize = 24;
    private const int InvaderSpeed = 8;
    private const float IntervalMult = .8f; 
    private float invaderInterval = 1.5f;

    private Rect gridBorderRect;
    private Color gridColor;

    private float LeftBound => this.gridBorderRect.Position.X + InvaderSpacing;

    private float RightBound => this.gridBorderRect.Position.X
                                + this.gridBorderRect.Size.X
                                - InvaderSpacing
                                - InvaderSize;
    
    private float lastInterval = 0f;
    private bool moveDown = false;
    private Direction currentDirection = Direction.Right;

    private readonly InvaderActor[] invaders = new InvaderActor[Columns * Rows];

    public override void OnInitialize()
    {
        var windowSize = this.Application!.Window.Size;
        var gridSize = new Vector2F(512, 512);
        var gridPosition = new Vector2F(
            (windowSize.X - gridSize.X) / 2,
            windowSize.Y - gridSize.Y - 20);
        this.gridBorderRect = new Rect(gridPosition, gridSize);
        this.gridColor = Color.White();

        this.CreateInvaders();
    }

    public override void OnUpdate(float deltaTime)
    {
        if (this.lastInterval >= this.invaderInterval
            || (this.moveDown && this.lastInterval >= this.invaderInterval / 2) )
        {
            if (this.moveDown)
            {
                for (var i = 0; i < Columns * Rows; i++)
                {
                    var invader = this.invaders[i];
                    var currentPos = invader.GetPosition();

                    currentPos.Y += InvaderSize;
                    this.moveDown = false;
                }
                this.currentDirection = this.currentDirection == Direction.Left
                    ? Direction.Right
                    : Direction.Left;

                this.lastInterval = 0;
                this.invaderInterval *= IntervalMult;
                return;
            }
            
            var distanceToBound = 0f;
            for (var i = 0; i < Columns * Rows; i++)
            {
                var invader = this.invaders[i];
                var currentPos = invader.GetPosition();

                currentPos.X += this.currentDirection == Direction.Right
                    ? InvaderSpeed
                    : -InvaderSpeed;
                
                if (currentPos.X > this.RightBound
                    || currentPos.X < this.LeftBound)
                {
                    this.moveDown = true;
                    distanceToBound = this.currentDirection == Direction.Left
                        ? this.LeftBound - currentPos.X
                        : this.RightBound - currentPos.X;
                }
            }

            if (distanceToBound != 0f)
            {
                for (var i = 0; i < Columns * Rows; i++)
                {
                    var invader = this.invaders[i];
                    var currentPos = invader.GetPosition();

                    currentPos.X += distanceToBound;
                }
            }

            this.lastInterval = 0f;
        }
        else
        {
            this.lastInterval += deltaTime;
        }
    }

    public override void OnRender()
    {
        this.Application!.Renderer.DrawRect(this.gridBorderRect, this.gridColor);
    }

    private void CreateInvaders()
    {
        for (var i = 0; i < Columns * Rows; i++)
        {
            var invader = this.RegisterActor<InvaderActor>($"Invader_{i}");
            var col = i % Columns;
            var row = i / Columns;
            invader.SetPosition(new Vector2F(
                this.gridBorderRect.Position.X + col * InvaderSize + (col + 1) * InvaderSpacing,
                this.gridBorderRect.Position.Y + row * InvaderSize + (row + 1) * InvaderSpacing));
            invader.SetSize(new Vector2F(InvaderSize, InvaderSize));
            this.invaders[i] = invader;
        }
    }
}