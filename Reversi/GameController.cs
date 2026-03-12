using System.Diagnostics;
using System.Security.Cryptography;

namespace Reversi
{
    public partial class GameController
    {
        private readonly Board m_board;
        private readonly UIBoard m_uiboard;

        private readonly Label m_score_text;
        private readonly Label m_turn_indendification;
        
        private CellType m_turn;
        private int m_player_index;
        private int[] m_player_score;
        private readonly int[] m_valid_moves;
        
        private Mode m_mode;
        private Difficulty m_difficulty;

        private CancellationTokenSource? m_cancellationToken;
        private object m_lock;

        public GameController(Label turn_indendification, Label score_text, Panel playzone)
        {
            m_player_score = new int[2];
            m_valid_moves = new int[2];
            m_lock = new object();

            m_board = new Board(UIUpdate_Trigger);
            m_uiboard = new UIBoard(playzone, Move_OnClick);
            m_turn_indendification = turn_indendification;
            m_score_text = score_text;
        }

        private async void TBotPlay(CancellationToken ct)
        {
            Console.WriteLine($"BotThread::Thread started: {Thread.CurrentThread.ThreadState}");

            var watch = new Stopwatch();

            watch.Start();
            MinimaxRetValue retValue = Minimax.GetMove(m_board, m_turn, float.NegativeInfinity, float.PositiveInfinity, Constants.DIFFICULTY_DEPTH[(int)m_difficulty]);
            Point move = retValue.Move;
            watch.Stop();

            Console.WriteLine($"BotThread::Minimax time: {watch.Elapsed.TotalSeconds} s");

            int remainingDelay = Math.Max(0, 500 - (int)watch.ElapsedMilliseconds);
            Console.WriteLine("BotThread::Thinking");

            try
            {
                await Task.Delay(remainingDelay, ct);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("BotThread::Thinking cancelled safely.");
                return;
            }

            Console.WriteLine("BotThread::Thinking ended succesfully");

            if (move.X != -1)
            {
                Console.WriteLine($"BotThread::AI MOVE: ({move.X}, {move.Y}) {m_turn}");
                MakeMove(move.X, move.Y);
                Update();
                ProcessTurn();
            }
            else Console.WriteLine("BotThread::No moves are taken");

            Console.WriteLine("BotThread::Thread exiting...");
        }

        private bool IsAgainstBot()
        {
            return m_mode == Mode.PVE && m_turn == CellType.BLACK;
        }

        private void UIUpdate_Trigger(object? sender, EventArgs e)
        {
            BoardUpdateEventArgs args = (BoardUpdateEventArgs)e;
            m_uiboard.SetCell(args.Point.X, args.Point.Y, args.Type);
        }

        private void Move_OnClick(object? sender, EventArgs e)
        {
            if(IsAgainstBot() || sender is null)
            {
                return;
            }

            Panel cell = (Panel)sender;
            Console.WriteLine($"{cell.Name}: ({cell.Location.X}, {cell.Location.Y}) {cell.Tag}");

            int x = cell.Location.X / 100;
            int y = cell.Location.Y / 100;

            if (m_board[x + y * Constants.BOARD_SIZE.Height] != (CellType)cell.Tag!)
            {
                Console.WriteLine("Desync error");
                return;
            }

            if ((CellType)cell.Tag! != CellType.AVAILABLE)
                return;

            MakeMove(x, y);
            Update();
            ProcessTurn();
        }

        private void Update()
        {
            SwitchTurn();
            m_board.Update(m_turn);

            m_player_score = m_board.Score;
            m_valid_moves[m_player_index] = m_board.ValidMoves[m_player_index].Count;

            m_score_text.Text = $"{m_player_score[0],2} : {m_player_score[1],2}";
            Console.WriteLine($"Valid moves for player {m_turn}: {m_valid_moves[m_player_index]}");
        }

        private void MakeMove(int x, int y)
        {
            m_board.SetCell(x, y, m_turn);
            m_board.FlipLines(x, y, m_turn);
        }

        private void SwitchTurn()
        {
            m_turn = (CellType)(((int)m_turn + 1) % 2);
            m_player_index = (int)m_turn;

            m_turn_indendification.Text = $"Player {m_turn} turn";
            Console.WriteLine(m_turn_indendification.Text);
        }

        private void ProcessTurn()
        {
            if (m_valid_moves[m_player_index] == 0)
            {
                MessageBox.Show($"Player {m_turn + 1} has no valid moves. PASS.");
                Update();

                if (m_valid_moves[m_player_index] == 0)
                {
                    ShowWinnerMessage();
                }
            }

            if (IsAgainstBot())
            {
                Task.Run(() => TBotPlay(m_cancellationToken.Token));
            }

            Console.WriteLine(m_board);
            Console.WriteLine(m_uiboard);
        }

        private void SetStartPosition()
        {
            int midx = Constants.BOARD_SIZE.Width / 2;
            int midy = Constants.BOARD_SIZE.Height / 2;

            m_board.SetCell(midx, midy, m_turn);
            m_board.SetCell(midx - 1, midy - 1, m_turn);
            SwitchTurn();

            m_board.SetCell(midx - 1, midy, m_turn);
            m_board.SetCell(midx, midy - 1, m_turn);
            SwitchTurn();
        }

        public void Restart()
        {
            lock (m_lock)
            {
                if (m_cancellationToken != null)
                {
                    m_cancellationToken.Cancel();
                    m_cancellationToken.Dispose();
                }

                m_cancellationToken = new CancellationTokenSource();

                m_turn = (CellType)(RandomNumberGenerator.GetInt32(0, 100) % 2);

                m_mode = Settings.GetMode();
                m_difficulty = Settings.GetDifficulty();

                Array.Fill(m_player_score, 0);

                m_board.Reset();
                m_uiboard.Reset();

                SetStartPosition();
                Update();
                ProcessTurn();
            }
        }

        private void ShowWinnerMessage()
        {
            string message;
            if (m_player_score[0] > m_player_score[1])
                message = $"Winner: Player 1 (WHITE): {m_player_score[0]} : {m_player_score[1]}";
            else if (m_player_score[1] > m_player_score[0])
                message = $"Winner: Player 2 (BLACK): {m_player_score[0]}  :  {m_player_score[1]}";
            else
                message = $"Draw: {m_player_score[0]}  :  {m_player_score[1]}";

            MessageBox.Show(message, "Summary");
        }
    }
}