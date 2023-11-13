using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp.Views.Windows;
using SkiaSharp;

namespace Testas
{
    class Object
    {
        #region Variables
        public SpriteSheet sheet;
        public Dictionary<string,Animation> animations=new Dictionary<string,Animation>();


        SKMatrix location;
        SKMatrix matrixPostion;
        SKMatrix objectLocation;
        SKMatrix objectScale = SKMatrix.Identity;
        SKMatrix localTrans = SKMatrix.Identity;

        float matrixScaleXnY = 1;
        SKImage image;
        #endregion

        public Object(float x,float y)
        {
            setPositionMatrix(x, y);
        }
        public void setPositionMatrix(float x, float y)
        {
            matrixPostion = new SKMatrix(matrixScaleXnY, 0, x, 0, matrixScaleXnY, y, 0, 0, 1);
            location = matrixPostion;

            localTrans.TransX = x;
            localTrans.TransY = y;



        }
        public void addPosition(float x, float y)
        {
            matrixPostion.TransX += x;
            matrixPostion.TransY += y;

            location.TransX = objectLocation.TransX;
            location.TransY = objectLocation.TransY;
        }
        
        public SKPoint getPosition()
        {
            return new SKPoint(matrixPostion.TransX, matrixPostion.TransY);
        }

        public void setSpriteSheet(string _path, int _vertical, int _horizontal)
        {
            sheet = new SpriteSheet(_path, _vertical, _horizontal);
        }
        
        public SKImage setcollisionImage(string _path)
        {
            image = SKImage.FromEncodedData(AppDomain.CurrentDomain.BaseDirectory + _path);
            return image;

        }//basic test nothing really happens here.
        public void Scaling(SKCanvas _canvas,SKMatrix _currentMatrixLocation,SKImage _img,float _playerScaleX,float _playerScaleY)
        {
            SKMatrix _tempScale = SKMatrix.CreateScale(objectScale.ScaleX + _playerScaleX, objectScale.ScaleY+_playerScaleY);
            _canvas.DrawImage(_img, SKRect.Create(localTrans.TransX,localTrans.TransY, _tempScale.ScaleX, _tempScale.ScaleY));
        }
        public void Scale(float _ScaleX, float _ScaleY)
        {
            objectScale.TransX += _ScaleX;
            objectScale.TransY += _ScaleY;
        }
        public void scaleWithMove(SKImage _img,float _addScaleX,float _addScaleY)
        {
            this.objectScale.ScaleX += _addScaleX;
            this.objectScale.ScaleY += _addScaleY;
        }
        

        public void setAnimation(int row, List<int> col, string name)
        {
            if (sheet != null)
            {
                animations.Add(name, new Animation(sheet, row, col));
            }
        }

        public SKImage playAnimation(string animName)
        {
            return animations[animName].play();
        }


    }
}
