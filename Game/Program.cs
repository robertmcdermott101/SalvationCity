
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SalvationCity
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _car;
        private Vector2 _carPos = new Vector2(200,200);

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _car = new Texture2D(GraphicsDevice, 50, 30);
            Color[] data = new Color[50*30];
            for (int i = 0; i < data.Length; i++) data[i] = Color.Brown;
            _car.SetData(data);
        }

        protected override void Update(GameTime gameTime)
        {
            var k = Keyboard.GetState();
            if (k.IsKeyDown(Keys.Escape))
                Exit();
            if (k.IsKeyDown(Keys.W)) _carPos.Y -= 2;
            if (k.IsKeyDown(Keys.S)) _carPos.Y += 2;
            if (k.IsKeyDown(Keys.A)) _carPos.X -= 2;
            if (k.IsKeyDown(Keys.D)) _carPos.X += 2;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_car, _carPos, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        static void Main()
        {
            using (var game = new GameMain())
                game.Run();
        }
    }
}
