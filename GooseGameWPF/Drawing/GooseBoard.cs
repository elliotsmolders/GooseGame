using System;
using System.Drawing;

namespace GooseGameWPF.Drawing
{
    public static class GooseBoard
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="playerIndex">1 to 4</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Point GetStartPosition(int playerIndex)
        {
            if (playerIndex == 1)
                return new Point(56, 660);
            else if (playerIndex == 2)
                return new Point(92, 660);
            else if (playerIndex == 3)
                return new Point(128, 660);
            else if (playerIndex == 4)
                return new Point(164, 660);
            else
                throw new ArgumentOutOfRangeException(nameof(playerIndex), "Enkel 1 t.e.m. 4 zijn geldig.");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldNumber">1 to 63</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Point GetFieldPosition(int fieldNumber)
        {
            if (fieldNumber == 1)
                return new Point(252, 660);
            else if (fieldNumber == 2)
                return new Point(314, 660);
            else if (fieldNumber == 3)
                return new Point(374, 660);
            else if (fieldNumber == 4)
                return new Point(438, 660);
            else if (fieldNumber == 5)
                return new Point(504, 660);
            else if (fieldNumber == 6)
                return new Point(580, 660);
            else if (fieldNumber == 7)
                return new Point(646, 660);
            else
                throw new ArgumentOutOfRangeException(nameof(fieldNumber), "Enkel 1 t.e.m. 63 zijn geldig.");
        }
    }
}