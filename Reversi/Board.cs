using System.Text;

namespace Reversi
{
    public class BoardUpdateEventArgs : EventArgs
    {
        public Point Point { get; set; }
        public CellType Type { get; set; }
    }

    public class Board
    {
        private readonly CellType[] m_board;
        private readonly List<Point>[] m_valid_moves;
        private readonly int[] m_player_score;

        private readonly EventHandler ui_update_trigger;

        public List<Point>[] ValidMoves
        {
            get { return [m_valid_moves[0], m_valid_moves[1]]; }
        }

        public int[] Score
        {
            get { return [m_player_score[0], m_player_score[1]]; }
        }

        private readonly static Point[] s_directions = [
            new( -1, -1 ),   new( 0, -1 ),    new( 1, -1 ),
            new( -1,  0 ),                    new( 1,  0 ),
            new( -1, 1 ),    new( 0,  1 ),    new( 1,  1 )
        ];

        public Board(EventHandler function)
        {
            int size = Constants.BOARD_SIZE.Width * Constants.BOARD_SIZE.Height;
            m_board = [.. Enumerable.Repeat(CellType.EMPTY, size)];
            m_valid_moves = [[], []];
            ui_update_trigger = function;
            m_player_score = [0, 0];
        }

        public void SetCell(int x, int y, CellType player, bool minimax = false)
        {
            int index = x + y * Constants.BOARD_SIZE.Width;
            m_board[index] = player;

            if (!minimax)
            {
                BoardUpdateEventArgs args = new()
                {
                    Point = new(x, y),
                    Type = player
                };
                ui_update_trigger.Invoke(this, args);
            }
        }

        public List<Point> FlipLines(int x, int y, CellType player, bool minimax = false)
        {
            CellType opponent = player == CellType.WHITE ? CellType.BLACK : CellType.WHITE;

            List<Point> Flipped = [];

            foreach (Point dir in s_directions)
            {
                int nx = x + dir.X, ny = y + dir.Y;
                List<Point> toFlip = [];

                while (nx >= 0 && nx < Constants.BOARD_SIZE.Width &&
                       ny >= 0 && ny < Constants.BOARD_SIZE.Height)
                {
                    int index = nx + ny * Constants.BOARD_SIZE.Width;
                    CellType type = m_board[index];

                    if (type == opponent)
                    {
                        toFlip.Add(new (nx, ny));
                    }
                    else if (type == player)
                    {
                        foreach (Point cell in toFlip)
                        {
                            SetCell(cell.X, cell.Y, player, minimax);
                        }
                        Flipped.AddRange(toFlip);
                        break;
                    }
                    else break;

                    nx += dir.X;
                    ny += dir.Y;
                }
            }

            return Flipped;
        }

        public bool IsValidMove(int x, int y, CellType player)
        {
            int index = x + y * Constants.BOARD_SIZE.Width;
            CellType type = m_board[index];
            if (type != CellType.EMPTY && type != CellType.AVAILABLE)
                return false;

            CellType opponent = player == CellType.WHITE ? CellType.BLACK : CellType.WHITE;

            foreach (Point dir in s_directions)
            {
                int nx = x + dir.X;
                int ny = y + dir.Y;

                bool hasOpponentBetween = false;

                while (nx >= 0 && nx < Constants.BOARD_SIZE.Width &&
                       ny >= 0 && ny < Constants.BOARD_SIZE.Height)
                {
                    index = nx + ny * Constants.BOARD_SIZE.Width;
                    type = m_board[index];

                    if (type == opponent)
                    {
                        hasOpponentBetween = true;
                    }
                    else if (type == player)
                    {
                        if (hasOpponentBetween)
                            return true;
                        else
                            break;
                    }
                    else break;

                    nx += dir.X;
                    ny += dir.Y;
                }
            }

            return false;
        }

        public void Update(CellType player)
        {
            Console.WriteLine("Update Called");
            CellType opponent = player == CellType.WHITE? CellType.BLACK : CellType.WHITE;
            int player_index = (int)player % 2;
            int opponent_index = (int)opponent % 2;

            m_valid_moves[player_index].Clear();
            m_valid_moves[opponent_index].Clear();
            Array.Fill(m_player_score, 0);

            for (int x = 0; x < Constants.BOARD_SIZE.Width; x++)
                for (int y = 0; y < Constants.BOARD_SIZE.Height; y++)
                {
                    int index = x + y * Constants.BOARD_SIZE.Width;
                    CellType type = m_board[index];

                    if (type == CellType.AVAILABLE || type == CellType.EMPTY)
                    {
                        SetCell(x, y, CellType.EMPTY);
                        
                        if (IsValidMove(x, y, player))
                        {
                            m_valid_moves[player_index].Add(new(x, y));
                        }
                        else if (IsValidMove(x, y, opponent))
                        {
                            m_valid_moves[opponent_index].Add(new(x, y));
                        }
                    }
                    else
                    {
                        int score_index = (int)type % 2;
                        m_player_score[score_index]++;
                    }
                }

                Console.Write("Moves: ");
            foreach (Point move in m_valid_moves[player_index])
            {
                SetCell(move.X, move.Y, CellType.AVAILABLE);
                Console.Write($"({move.X}, {move.Y}) ");
            }

            Console.WriteLine();
        }

        public void Reset()
        {
            Array.Fill(m_board, CellType.EMPTY);
            m_valid_moves[0].Clear();
            m_valid_moves[1].Clear();
            Array.Fill(m_player_score, 0);
        }

        public void UnFlipLines(CellType player, List<Point> toUnFlip)
        {
            CellType opponent = player == CellType.WHITE ? CellType.BLACK : CellType.WHITE;

            foreach (Point cell in toUnFlip)
            {
                SetCell(cell.X, cell.Y, opponent, true);
            }
        }

        public CellType this[int index]
        {
            get { return m_board[index]; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Board = {");
            for (int y = 0; y < Constants.BOARD_SIZE.Height; y++)
            {
                for (int x = 0; x < Constants.BOARD_SIZE.Width; x++)
                {
                    sb.Append($"{(uint)m_board[x + y * Constants.BOARD_SIZE.Width]} ");
                }
                sb.AppendLine();
            }
            sb.AppendLine("}");
            
            return sb.ToString();
        }
    }
}