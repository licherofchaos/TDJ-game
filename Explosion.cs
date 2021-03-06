using System;
using System.Linq;
using IPCA.MonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDJ
{
    public class Explosion : AnimatedSprite, ITempObject
    {
        private bool cycled = false;
        public bool IsDead() => _currentTexture == 0 && cycled;

        public Explosion(Game game, Vector2 position) : base(
            "explosion", position,
            Enumerable
                .Range(1, 3)
                .Select(
                    n => game.Content.Load<Texture2D>($"explosion{n}")
                )
                .ToArray()
        )
        {
            _fps = 20;
        }


        public override void Update(GameTime gameTime)
        {
            if (_currentTexture > 0) cycled = true;
            base.Update(gameTime);
        }
    }
}