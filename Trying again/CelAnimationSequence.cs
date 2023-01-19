using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trying_again
{
    public class CelAnimationSequence
    {
       
        protected Texture2D texture;

        
        protected float celTime;

       
        protected int celWidth;
        protected int celHeight;

        
        protected int celCount;

               
        public CelAnimationSequence(Texture2D texture, int celWidth, float celTime)
        {
            this.texture = texture;
            this.celWidth = celWidth;
            this.celTime = celTime;

            celHeight = Texture.Height;
            celCount = Texture.Width / celWidth;
        }

        
        public Texture2D Texture
        {
            get { return texture; }
        }

       
        public float CelTime
        {
            get { return celTime; }
        }

        
        public int CelCount
        {
            get { return celCount; }
        }

        
        public int CelWidth
        {
            get { return celWidth; }
        }

        
        public int CelHeight
        {
            get { return celHeight; }
        }
    }
}
