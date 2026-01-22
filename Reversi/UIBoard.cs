using System.Text;

namespace Reversi
{
    public class UIBoard
    {
        private readonly Panel m_playzone;
        private readonly Panel[] m_board;
        private readonly Bitmap[] m_images = null!;

        public UIBoard(Panel playzone, EventHandler function)
        {
            m_playzone = playzone;
            m_images = new Bitmap[4];
            m_board = new Panel[Constants.BOARD_SIZE.Width * Constants.BOARD_SIZE.Height];

            m_images[(int)CellType.WHITE] = Reversi.Properties.Resources.white;
            m_images[(int)CellType.BLACK] = Reversi.Properties.Resources.black;
            m_images[(int)CellType.EMPTY] = new Bitmap(1, 1);
            m_images[(int)CellType.AVAILABLE] = Reversi.Properties.Resources.available;

            for (int y = 0; y < Constants.BOARD_SIZE.Height; y++)
                for (int x = 0; x < Constants.BOARD_SIZE.Width; x++)
                {
                    int indx = x + y * Constants.BOARD_SIZE.Width;
                    Color cell_color = Color.ForestGreen;

                    if (((x + y) & 1) == 1)
                    {
                        cell_color = Color.DarkGreen;
                    }

                    m_board[indx] = new()
                    {
                        BackColor = cell_color,
                        Location = new Point(Constants.CELL_SIZE.Width * x, Constants.CELL_SIZE.Height * y),
                        Name = $"cell_{indx}",
                        Size = Constants.CELL_SIZE,
                        TabIndex = 0,
                        Tag = CellType.EMPTY,
                        Cursor = Cursors.Cross
                    };
                    m_board[indx].Click += function;
                }

            foreach (Panel cell in m_board)
                m_playzone.Controls.Add(cell);
        }

        public void SetCell(int x, int y, CellType type)
        {
            int indx = x + y * Constants.BOARD_SIZE.Width;

            m_board[indx].Tag = type;
            m_board[indx].BackgroundImage = m_images[(int)type];
            m_board[indx].Cursor = type == CellType.AVAILABLE ? Cursors.Cross : Cursors.No;
        }

        public void Reset()
        {
            for (int y = 0; y < Constants.BOARD_SIZE.Height; y++)
                for (int x = 0; x < Constants.BOARD_SIZE.Width; x++)
                    SetCell(x, y, CellType.EMPTY);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("UIBoard = {");
            for (int y = 0; y < Constants.BOARD_SIZE.Height; y++)
            {
                for (int x = 0; x < Constants.BOARD_SIZE.Width; x++)
                {
                    sb.Append($"{(uint)m_board[x + y * Constants.BOARD_SIZE.Width].Tag!} ");
                }
                sb.AppendLine();
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}