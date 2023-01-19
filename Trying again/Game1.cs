using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Trying_again
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D cat;
        Texture2D coin;
        Texture2D background;
        SpriteFont gameFont;
        private Vector2 catDirection = new Vector2();
        private Rectangle catRectangle = new Rectangle();
        private Vector2 coinDirection = new Vector2();
        private Rectangle coinRectangle = new Rectangle();
        private Rectangle BackgroundRect = new Rectangle();
        

        Random rand = new Random();

        int score;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            

            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 700;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            catRectangle = cat.Bounds;
            coinRectangle = coin.Bounds;
            BackgroundRect = background.Bounds;
            score = 0;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            cat = Content.Load<Texture2D>("Smol_Mudkip");
            coin = Content.Load<Texture2D>("Pikachu-Spritesheet");
            background = Content.Load<Texture2D>("download");
            gameFont = Content.Load<SpriteFont>("Caveat-VariableFont_wght");
        }

        public Texture2D texture
        {
            get { return texture; }
        }

        protected override void Update(GameTime gameTime)
        {

            Random R = new Random();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //cat movement
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (catRectangle.Top > 0)
                {

                    catDirection.Y = -4f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (catRectangle.Bottom < _graphics.PreferredBackBufferHeight)
                {

                    catDirection.Y = 4f;
                }
            }else
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (catRectangle.Top > 0)
                {

                    catDirection.Y = -4f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (catRectangle.Bottom < _graphics.PreferredBackBufferHeight)
                {

                    catDirection.Y = 4f;
                }
            }
            else
            {
                catDirection.Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (catRectangle.Left > 0)
                {
                    catDirection.X = -4f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (catRectangle.Right < _graphics.PreferredBackBufferWidth)
                {

                    catDirection.X = 4f;
                }
            }else
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (catRectangle.Left > 0)
                {
                    catDirection.X = -4f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (catRectangle.Right < _graphics.PreferredBackBufferWidth)
                {

                    catDirection.X = 4f;
                }
            }
            else
            {
                catDirection.X = 0;
            }
            
            if (catRectangle.Top < 0 )
            {
                catRectangle.Y = 0;
            }
            if (catRectangle.Left < 0)
            {
                catRectangle.X = 0;
            }
            if (catRectangle.Bottom > _graphics.PreferredBackBufferHeight)
            {
                catRectangle.Y = _graphics.PreferredBackBufferHeight - 69;
            }
            if (catRectangle.Right > _graphics.PreferredBackBufferWidth)
            {
                catRectangle.X = _graphics.PreferredBackBufferWidth - 71;
            }

            
            catRectangle.Offset(catDirection);
            //coinRectangle.Offset(coinDirection);
            
            if (catRectangle.Intersects(coinRectangle))
            {
                coinDirection.X = rand.Next(107, 517);
                coinDirection.Y = rand.Next(137, 490);

                score += 1;
            }


            coinRectangle.X = (int)coinDirection.X;
            coinRectangle.Y = (int)coinDirection.Y;


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            Vector2 textCenter = gameFont.MeasureString("hi") / 2f;
            _spriteBatch.Draw(background, BackgroundRect = new Rectangle(1, 1, 700, 600), Color.White);
            _spriteBatch.Draw(cat, catRectangle.Location.ToVector2(), Color.White);
            _spriteBatch.Draw(coin, coinRectangle.Location.ToVector2(), Color.White);
            _spriteBatch.DrawString(gameFont, "Score: " + score.ToString(), new Vector2(20, 20), Color.Black, 0, textCenter, 2.0f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}