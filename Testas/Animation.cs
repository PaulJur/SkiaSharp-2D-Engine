using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace Testas
{
    public class Animation
    {
        #region Variables
        SpriteSheet sheet;
        int row;
        List<int> colm;
        int frame;
        #endregion

        public Animation(SpriteSheet _spriteSheet, int _row, List<int> _col)
        {
            row = _row;
            colm = _col;
            sheet = _spriteSheet;
        }
        public SKImage play()
        {
            return sheet.cutOut(colm[frame] - 1, row - 1);
        }
        public void Frames()
        {
            frame = frame % (colm.Count - 1);
            frame++;
        }
    }
}
