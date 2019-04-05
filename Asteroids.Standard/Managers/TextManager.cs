using System;
using System.Drawing;
using Asteroids.Standard.Screen;

namespace Asteroids.Standard.Managers
{
    /// <summary>
    /// Converts and draws text to a <see cref="ScreenCanvas"/>.
    /// </summary>
    public class TextManager
    {
        private readonly ScreenCanvas _screenCanvas;

        /// <summary>
        /// Creates a new instance of <see cref="TextManager"/>.
        /// </summary>
        /// <param name="canvas"><see cref="ScreenCanvas"/> to draw text on.</param>
        public TextManager(ScreenCanvas canvas)
        {
            _screenCanvas = canvas;
        }

        /// <summary>
        /// Text horizontal justification.
        /// </summary>
        public enum Justify { LEFT, CENTER, RIGHT };

        /// <summary>
        /// Coverts text to vector and draws on the <see cref="ScreenCanvas"/>.
        /// </summary>
        /// <param name="text">String to draw.</param>
        /// <param name="justification">Horizontal <see cref="Justify"/>.</param>
        /// <param name="locationTop">Top position to draw from.</param>
        /// <param name="letterWidth">Width of each letter.</param>
        /// <param name="letterHeight">Height of each letter.</param>
        public void DrawText(string text, Justify justification, int locationTop, int letterWidth, int letterHeight)
        {
            int printStart;
            const int width = ScreenCanvas.CANVAS_WIDTH;
            const int height = ScreenCanvas.CANVAS_HEIGHT;

            switch (justification)
            {
                case Justify.LEFT:
                    printStart = 100;
                    break;
                case Justify.CENTER:
                    printStart = (int)((width - text.Length * letterWidth) / 2.0);
                    break;
                case Justify.RIGHT:
                    printStart = height - 100 - text.Length * letterWidth;
                    break;
                default:
                    return;
            }

            var x = _screenCanvas.Size.Width;
            var y = _screenCanvas.Size.Height;

            for (int i = 0; i < text.Length; i++)
                DrawLetter(
                    text[i]
                    , (int)((printStart + i * letterWidth) / (double)width * x)
                    , (int)(locationTop / (double)height * y)
                    , (int)(letterWidth / (double)width * x)
                    , (int)(letterHeight / (double)height * y)
                );
        }

        /// <summary>
        /// Converts and draws a single character to the <see cref="ScreenCanvas"/>.
        /// </summary>
        /// <param name="character">Single <see langword="char"/> to draw.</param>
        /// <param name="letterLeft">Left position.</param>
        /// <param name="letterTop">Top position.</param>
        /// <param name="letterWidth">Letter width.</param>
        /// <param name="letterHeight">Letter height.</param>
        private void DrawLetter(char character, int letterLeft, int letterTop, int letterWidth, int letterHeight)
        {
            int newLeft = (int)(letterLeft + letterWidth * .2);
            int newTop = (int)(letterTop + letterHeight * .1);
            int halfRight = (newLeft + letterLeft + letterWidth) / 2;
            int halfDown = (newTop + letterTop + letterHeight) / 2;
            int rightSide = letterLeft + letterWidth;
            int bottomSide = letterTop + letterHeight;

            switch (character)
            {
                case '^':/* Ship */
                    int pointInUp = (int)(bottomSide - letterHeight * .2);
                    int pointInLeft = (int)(newLeft + letterWidth * .25);
                    int pointInRight = (int)(rightSide - letterWidth * .25);
                    _screenCanvas.AddLine(new Point(halfRight, newTop), new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(pointInRight, pointInUp));
                    _screenCanvas.AddLineTo(new Point(pointInLeft, pointInUp));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(halfRight, newTop));
                    break;
                case 'O':
                case '0':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, newTop));
                    break;
                case '1':
                case 'I':
                    _screenCanvas.AddLine(new Point(halfRight, newTop), new Point(halfRight, bottomSide));
                    break;
                case '2':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case '3':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    break;
                case '4':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(rightSide, bottomSide));
                    break;
                case '5':
                case 'S':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    break;
                case '6':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    break;
                case '7':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case '8':
                case 'B':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, newTop));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    break;
                case '9':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    break;
                case 'x':
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, bottomSide));
                    _screenCanvas.AddLine(new Point(rightSide, halfDown), new Point(newLeft, bottomSide));
                    break;
                case 'A':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(halfRight, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    break;
                // case 'B' handled by '8'
                case 'C':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case 'D':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(halfRight, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(halfRight, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, newTop));
                    break;
                case 'E':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    break;
                case 'F':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    break;
                case 'G':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(halfRight, halfDown));
                    break;
                case 'H':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, bottomSide));
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(rightSide, bottomSide));
                    _screenCanvas.AddLine(new Point(newLeft, halfDown), new Point(rightSide, halfDown));
                    // case 'I' handled by '1'
                    break;
                case 'J':
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(halfRight, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    break;
                case 'K':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, newTop));
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case 'L':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case 'M':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(halfRight, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                case 'N':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    break;
                // case 'O' handled by '0'
                case 'P':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    break;
                case 'Q':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(newLeft, newTop));
                    _screenCanvas.AddLine(new Point(halfRight, halfDown), new Point(rightSide, bottomSide));
                    break;
                case 'R':
                    _screenCanvas.AddLine(new Point(newLeft, bottomSide), new Point(newLeft, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(rightSide, halfDown));
                    _screenCanvas.AddLineTo(new Point(newLeft, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
                // case 'S' handled by '5'
                case 'T':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLine(new Point(halfRight, newTop), new Point(halfRight, bottomSide));
                    break;
                case 'U':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    break;
                case 'V':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(halfRight, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    break;
                case 'W':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(halfRight, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    break;
                case 'X':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, bottomSide));
                    _screenCanvas.AddLine(new Point(rightSide, newTop), new Point(newLeft, bottomSide));
                    break;
                case 'Y':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(halfRight, halfDown));
                    _screenCanvas.AddLineTo(new Point(rightSide, newTop));
                    _screenCanvas.AddLine(new Point(halfRight, halfDown), new Point(halfRight, bottomSide));
                    break;
                case 'Z':
                    _screenCanvas.AddLine(new Point(newLeft, newTop), new Point(rightSide, newTop));
                    _screenCanvas.AddLineTo(new Point(newLeft, bottomSide));
                    _screenCanvas.AddLineTo(new Point(rightSide, bottomSide));
                    break;
            }
        }

        internal void DrawText(string title, Justify cENTER, string v1, int v2, int letterSize, int v3)
        {
            throw new NotImplementedException();
        }
    }
}
