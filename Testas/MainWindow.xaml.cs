using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using SkiaSharp;
using SkiaSharp.Views.Windows;
using Microsoft.UI.Xaml.Shapes;
using System.Runtime.InteropServices;
using Microsoft.UI.Composition;
using System.Runtime;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Testas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        #region Variables
        SKCanvas canvas;
        TimeSpan rTime;
        SpriteSheet spriteSheet;
        Object player = new Object(100, 100);
        Object basicCollisionimage = new Object(0, 0);
        int x = 0,y = 0;

        static List<int> anim = new List<int>() { 1, 2, 3, 4 };
        string current_animation = "";
        SKImage scaleImg = SKImage.FromEncodedData(AppDomain.CurrentDomain.BaseDirectory + "Assets\\scale.jpg");





        #endregion 
        // List<int> items = new List<int>();
        //Random rand = new Random();
        //int spawnTime = 20;

        
       //Color[] itemColor = {Color.Red, Color.Green, Color.Blue,Color.Orange};


        //^^ random rectangle spawner(not done)

        

        public MainWindow()
        {

            this.InitializeComponent();
            gameObjects();
            CompositionTarget.Rendering += update;
            Chad.KeyDown += keystroke;
            Chad.IsHitTestVisible = true;
            Chad.IsTabStop = true;
            AllocConsole();

        }


        private void gameObjects()
        {
            player.setSpriteSheet("Assets\\Char2.png", 4, 4);
            player.setAnimation(1, anim, "walk_up");
            player.setAnimation(2, anim, "walk_left");
            player.setAnimation(3, anim, "walk_down");
            player.setAnimation(4, anim, "walk_right");
            


        }

        //TODO::::colission, rotation and scale

        void paisome(object sender, SKPaintSurfaceEventArgs e)
        {

            canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Gray);
            canvas.Translate(150, 150);
           // canvas.DrawImage(basicCollisionimage.setcollisionImage("Assets\\scale.jpg"), 100, 100);
            //Scale
            player.Scaling(canvas, SKMatrix.Identity,scaleImg , 50, 50);
 

            #region animation
            if (current_animation == "up")
            {
                canvas.DrawImage(player.playAnimation("walk_up"), player.getPosition());
            }
            else if (current_animation == "down")
            {
                canvas.DrawImage(player.playAnimation("walk_down"), player.getPosition());
            }
            else if (current_animation == "right")
            {
                canvas.DrawImage(player.playAnimation("walk_right"), player.getPosition());
            }
            else
            {
                canvas.DrawImage(player.playAnimation("walk_left"), player.getPosition());
            }
            #endregion

        }


        void update(object a, object b)
        {
            Chad.Invalidate();

        }
        void keystroke(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.W)
            {

                player.addPosition(0, -10);
                current_animation = "up";
                player.animations["walk_up"].Frames();

            }
            if (e.Key == Windows.System.VirtualKey.S)
            {
                player.addPosition(0, 10);
                current_animation = "down";
                player.animations["walk_down"].Frames();
            }
            if (e.Key == Windows.System.VirtualKey.A)
            {

                player.addPosition(-10, 0);
                current_animation = "left";
                player.animations["walk_left"].Frames();

            }
            if (e.Key == Windows.System.VirtualKey.D)
            {

                player.addPosition(10, 0);
                current_animation = "right";
                player.animations["walk_right"].Frames();

            }
            if(e.Key == Windows.System.VirtualKey.M)
            {
              player.scaleWithMove(scaleImg, 10, 10);
            }
            if (e.Key == Windows.System.VirtualKey.N)
            {
                player.scaleWithMove(scaleImg, -10, -10);
            }

        }

    }
}


