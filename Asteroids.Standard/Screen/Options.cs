using System.Collections.Generic;
using Asteroids.Standard.Components;
using Asteroids.Standard.Helpers;
using Asteroids.Standard.Managers;

namespace Asteroids.Standard.Screen
{
    public class Options
    {
        // What does Options need?
        // Mixing Volume
        // Change of Key binds
        // Change of Colors
        // Change of Background?

        private const string Title = "OPTIONS";
        private const int titleSize = 500;
        private const int titleOffset = titleSize * 3;

        private const string Color = "PRESS C TO CHANGE COLOR OF SPACESHIP";
        private const int colorSize = 250;
        private const int colorOffset = escapeSize * 3;

        private const string Background = "PRESS B TO CHANGE BACKGROUND";
        private const int backgroundSize = 250;
        private const int backgroundOffset = escapeSize * 3;

        private const string Escape = "PRESS ESC TO RETURN TO MAIN MENU";
        private const int escapeSize = 200;
        private const int escapeOffset = escapeSize * 3;

        private const string Test = "TEST";
        private const int testSize = 200;
        private const int testOffset = escapeSize * 3;

        private string _title;
        private int _letterSize;
        private int _increment;

        private readonly TextManager _textManager;
        private readonly ScreenCanvas _canvas;
        private readonly CacheManager _cache;

        public Options(TextManager textManager, ScreenCanvas canvas)
        {
            _textManager = textManager;
            _canvas = canvas;

            _cache = new CacheManager(
                new ScoreManager(new TextManager(_canvas))
                , null
                , new AsteroidBelt(15, Asteroid.ASTEROID_SIZE.SMALL)
                , new List<Bullet>()
            );
        }

        public void InitOptions()
        {
            _letterSize = 40;
            _increment = (int)(1000 / ScreenCanvas.FPS);
            _title = "OPTIONS";
        }

        public void DrawScreen()
        {
            // Draw Options Title
            _textManager.DrawText(
                Title
                , TextManager.Justify.CENTER
                , 1000
                , titleSize, titleSize
            );

             // Draw Color option instructions
            _textManager.DrawText(
                Color
                , TextManager.Justify.CENTER
                , 2500
                , colorSize, colorSize
            );

              // Draw Background option instructions
            _textManager.DrawText(
                Background
                , TextManager.Justify.CENTER
                , 3500
                , backgroundSize, backgroundSize
            );

            // Draw Escape instructions
            _textManager.DrawText(
                Escape
                , TextManager.Justify.CENTER
                , 6500
                , escapeSize, escapeSize
               );

            // Draw Astroid belt
            _cache.Repopulate();
            foreach (var asteroid in _cache.Asteroids)
            {
                asteroid.ScreenObject.Move();
                _canvas.LoadPolygon(asteroid.PolygonPoints, ColorHexStrings.DarkOrangeHex);
            }
        }
        public void shipColorChange()
        {
            // Draw TEST
            _textManager.DrawText(
                Test
                , TextManager.Justify.CENTER
                , 5000
                , testSize, testSize
            );
        }
        
    }
}
