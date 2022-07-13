using System;
using cse210_finalProject.Game.Casting;

namespace cse210_finalProject
{
    public class Constants
    {
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;
        public static int COLUMNS = MAX_X / CELL_SIZE;
        public static int ROWS = MAX_Y / CELL_SIZE;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Ultra Jumper Dude";

        public static int MAX_PLATFORM_LENGTH = 30;
        public static int MIN_PLATFORM_LENGTH = 15;
        public static int JUMP_HEIGHT = 30;
        public static int GRAVITY = 5;
        public static int NUMBER_OF_SPIKES = 15;

        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color BLUE = new Color(0, 0, 255);
    }
}
