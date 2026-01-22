namespace Reversi
{
    public static class Constants
    {
        public static readonly Size BOARD_SIZE = new(8, 8);
        public static readonly Size CELL_SIZE  = new(100, 100);
        public static readonly int[] DIFFICULTY_DEPTH = [1, 3, 4];
    }

    public enum CellType : uint
    {
        WHITE = 0,
        BLACK = 1,
        EMPTY = 2,
        AVAILABLE = 3
    }

    public enum Mode
    {
        PVP,
        PVE
    }

    public enum Difficulty : uint
    {
        BEGINNER = 0,
        STANDARD,
        ADVANCED
    }
}