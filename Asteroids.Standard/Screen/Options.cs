using System;
using System.Collections.Generic;
using Asteroids.Standard.Components;
using Asteroids.Standard.Helpers;
using Asteroids.Standard.Managers;


namespace Asteroids.Standard.Screen
{
    public class Options
    {
        private const string instructions = "OPTIONS";
        private const int instructionSize = 500;
        private const int instructionOffset = instructionSize * 3;

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

        public void DrawOptions()
        {
            //Draw Options Title
            _textManager.DrawText(
                instructions
                , TextManager.Justify.CENTER
                , instructionOffset
                , instructionSize, instructionSize
            );
        }

    }
}
