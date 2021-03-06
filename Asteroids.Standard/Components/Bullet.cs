using System;
using System.Collections.Generic;
using System.Drawing;
using Asteroids.Standard.Base;
using Asteroids.Standard.Screen;

namespace Asteroids.Standard.Components
{
    /// <summary>
    /// Bullet is a missile fired by an object (ship or UFO)
    /// </summary>
    class Bullet : ScreenObject
    {
        private int _remainingFrames;
        private const double speedPerSec = 1000 / ScreenCanvas.FPS;

        public Bullet() : base(new Point(0, 0))
        {
            _remainingFrames = 0;
        }

        protected override void InitPoints()
        {
            ClearPoints();
            AddPoints(PointsTemplate);
        }

        /// <summary>
        /// Indicates if the bullet is current shooting.
        /// </summary>
        public bool IsInFlight => _remainingFrames > 0;

        /// <summary>
        /// Prevents the bullet from being redrawn.
        /// </summary>
        public void Disable()
        {
            _remainingFrames = 0;
        }

        /// <summary>
        /// Fire the bullet from a parent ship.
        /// </summary>
        /// <param name="parentShip">Parent <see cref="Ship"/> the bullet was fired from.</param>
        public void Shoot(Ship parentShip)
        {
            _remainingFrames = (int)ScreenCanvas.FPS; // bullets live 1 sec
            currLoc = parentShip.GetCurrLoc();
            radians = parentShip.GetRadians();

            double SinVal = Math.Sin(radians);
            double CosVal = Math.Cos(radians);

            velocityX = (int)(-100 * SinVal) + parentShip.GetVelocityX();
            velocityY = (int)(100 * CosVal) + parentShip.GetVelocityY();
        }

        /// <summary>
        /// Decrement the bullets life and move.
        /// </summary>
        /// <returns></returns>
        public override bool Move()
        {
            // only draw if in flight
            if (IsInFlight)
            {
                _remainingFrames -= 1;
                return base.Move();
            }
            else
            {
                return false;
            }
        }

        //public override void Draw()
        //{
        //    // only draw things that are not available
        //    if (!Available())
        //        DrawPolygons(GetPoints(), GetRandomFireColor());
        //}

        #region Statics

        /// <summary>
        /// Non-transformed point template for creating a new bullet.
        /// </summary>
        private static IList<Point> PointsTemplate = new List<Point>();

        /// <summary>
        /// Setup the point templates.
        /// </summary>
        static Bullet()
        {
            const int bulletSize = 35;

            PointsTemplate.Add(new Point(0, -bulletSize));
            PointsTemplate.Add(new Point(bulletSize, 0));
            PointsTemplate.Add(new Point(0, bulletSize));
            PointsTemplate.Add(new Point(-bulletSize, 0));
        }

        #endregion
    }
}
