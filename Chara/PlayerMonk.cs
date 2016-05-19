using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmCr48hGameJam2016_5.Chara
{
    class PlayerMonk : Player
    {
        public PlayerMonk(
            asd.MapObject2D map,
            asd.Vector2DF position,
            Status status,
            List<Chara.Cloud> clouds) : base(map, position, status)
        {
            this.Src = Data.rect(Data.GraphType.PlayerMonk);
            this.clouds = clouds;
        }

        protected override void Move()
        {
            this.speed.X = 0;

            this.speed.Y += 0.3F;

            if (this.speed.Y > 12.0F)
                this.speed.Y = 12.0F;

            foreach (var cloud in clouds)
            {
                bool yMatch = cloud.Position.Y -16 - 16 < Position.Y && Position.Y < cloud.Position.Y -16 + 16;
                bool xMatch = cloud.Position.X - 32 < Position.X && Position.X < cloud.Position.X + 32;
                if (xMatch && yMatch && this.speed.Y >= 0)
                {
                    if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                    {
                        cloud.Position = new asd.Vector2DF(cloud.Position.X - 6, cloud.Position.Y);
                    }
                    if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                    {
                        cloud.Position = new asd.Vector2DF(cloud.Position.X + 6, cloud.Position.Y);
                    }
                    this.speed = new asd.Vector2DF(cloud.Position.X, cloud.Position.Y - 16) - this.Position;
                    this.IsOnGround = true;
                    break;
                }
            }
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push && this.IsOnGround)
            {
                this.speed.Y = -9.0F;
                this.IsOnGround = false;
            }

        }
        private List<Cloud> clouds;
    }
}
