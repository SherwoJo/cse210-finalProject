using System;
using cse210_finalProject.Game.Casting;

namespace cse210_finalProject
{
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Ultra Lasagna Dudes";

        public static int BOTTOM_PLATFORM_LENGTH = 7;
        public static int MIDDLE_PLATFORM_LENGTH = 20;
        public static int TOP_PLATFORM_LENGTH = 7;
        public static int JUMP_HEIGHT = 5;
        public static int GRAVITY = 100;

        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color BLUE = new Color(0, 0, 255);
    }
}
