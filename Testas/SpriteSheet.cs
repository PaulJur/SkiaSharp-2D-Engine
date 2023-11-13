using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Windows;
using Microsoft.UI.Xaml.Shapes;
using System.Runtime.InteropServices;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Input;

namespace Testas
{
    public class SpriteSheet
    {
        #region Variables
        SKImage img;
        int cellWidthX, cellHeightY;

        #endregion

        public SpriteSheet(string _path, int _vertical, int _horizontal)
        {
            img = SKImage.FromEncodedData(AppDomain.CurrentDomain.BaseDirectory + _path);
            cellWidthX = img.Width / _horizontal;
            cellHeightY = img.Height / _vertical;
        }
        public SKImage cutOut(int _verticalSpriteY, int _horizontalSpriteX)
        {
            SKRectI bounds = new SKRectI(_verticalSpriteY * cellWidthX, _horizontalSpriteX * cellHeightY, (_verticalSpriteY + 1) * cellWidthX, (_horizontalSpriteX + 1) * cellHeightY);
            SKImage cutout = img.Subset(bounds);

            return cutout;
            
        }
        public SKImage getSKImage()
        {
            return img;
        }
        public SKPoint getSize()
        {
            return new SKPoint(cellWidthX, cellHeightY);
        }
    }


}
