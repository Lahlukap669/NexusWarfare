using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Lang.Annotation;
using Microsoft.Xna.Framework.Content;
using static Android.Icu.Text.Transliterator;
using static Android.Widget.GridLayout;
using System;
using Android.Bluetooth;
using Nexus_Warfare.Source.Controller;

namespace Nexus_Warfare.Source.Graphics
{
    public class Monster : Sprite
    {
        public float Speed { get; set; }
        public bool IsActive { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int DamageTaken { get; set; }
        public bool Move { get; set; }
        public int Value { get; set; }
        private SoundManager soundManager;
        private ContentManager content;

        public Monster(ContentManager content, string assetName, Vector2 position, float speed = 0, int damage = 0, int health = 0, int value = 0)
            : base(content, assetName)
        {
            Position = position;
            Speed = speed;
            IsActive = true;
            Health = 100;
            Damage = damage;
            DamageTaken = 0;
            Move  = true;
            Value = value;
            this.content = content;
            soundManager = Game1.Instance.soundManager;
            soundManager.LoadSound(content, "47356__fotoshop__oof", "MonsterDie");
        }
        public int GetDamage()
        {
            return Damage;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health <= 0)
            {
                DamageTaken =+ damage;
                IsActive = false;
                soundManager.PlaySound("MonsterDie");
                DropCoin(); // Call DropCoin when the monster dies
            }
        }
        private void DropCoin()
        {
            Vector2 coinPosition = this.Position;
            Coin coin = new Coin(content, coinPosition, this.Value);
            Game1.Instance.coinManager.AddCoin(coin);
        }
        public virtual void Update(GameTime gameTime)
        {
            if(Position.Y < 1200 && Move)
            {
                Position += new Vector2(0, Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
        public virtual void ActivateAbility()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
