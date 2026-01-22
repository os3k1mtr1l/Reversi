namespace Reversi
{
    public struct MinimaxRetValue
    {
        public float Score { get; set; }
        public Point Move { get; set; }
    };

    public static class Minimax
    {
        private static readonly int[,] s_weights = {
            { 100, -20,  10,   5,   5,  10, -20, 100 },
            { -20, -50,  -2,  -2,  -2,  -2, -50, -20 },
            {  10,  -2,   5,   1,   1,   5,  -2,  10 },
            {   5,  -2,   1,   0,   0,   1,  -2,   5 },
            {   5,  -2,   1,   0,   0,   1,  -2,   5 },
            {  10,  -2,   5,   1,   1,   5,  -2,  10 },
            { -20, -50,  -2,  -2,  -2,  -2, -50, -20 },
            { 100, -20,  10,   5,   5,  10, -20, 100 }
        };

        private static float Evaluate(Board board)
        {
            float score = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    int index = x + y * Constants.BOARD_SIZE.Height;
                    CellType cell = board[index];
                    if (cell == CellType.BLACK)
                        score += s_weights[y, x];
                    else if (cell == CellType.WHITE) 
                        score -= s_weights[y, x];
                }
            }

            var moves = board.ValidMoves;
            score += (moves[1].Count - moves[0].Count) * 5;

            return score;
        }

        private static int ScoreMove(Board board, Point move, CellType player)
        {
            int player_index = (int)player % 2;
            int opponent_index = ((int)player + 1) % 2;

            int[] score = board.Score;
            return s_weights[move.Y, move.X] + (score[player_index] - score[opponent_index]);
        }

        public static MinimaxRetValue GetMove(Board board, CellType player, float alpha, float beta, int depth)
        {
            CellType opponent = player == CellType.BLACK? CellType.WHITE : CellType.BLACK;
            
            var moves = board.ValidMoves;
            int player_index = (int)player % 2;
            
            MinimaxRetValue retValue = new()
            {
                Score = Evaluate(board),
                Move = new(-1, -1)
            };

            if (depth == 0 || (moves[0].Count == 0 && moves[1].Count == 0))
            {
                return retValue;
            }

            if (moves[player_index].Count == 0)
            {
                return GetMove(board, opponent, alpha, beta, depth - 1);
            }

            var sortedMoves = moves[player_index].OrderByDescending(move => ScoreMove(board, move, player)).ToList();
            retValue.Score = player == CellType.BLACK? float.NegativeInfinity : float.PositiveInfinity;

            foreach (Point move in sortedMoves)
            {
                board.SetCell(move.X, move.Y, player, true);
                var unflip = board.FlipLines(move.X, move.Y, player, true);
                var recursiveRet = GetMove(board, opponent, alpha, beta, depth - 1);

                board.UnFlipLines(player, unflip);
                board.SetCell(move.X, move.Y, CellType.EMPTY, true);
                

                if (player == CellType.BLACK)
                {
                    if (recursiveRet.Score > retValue.Score)
                    {
                        retValue.Score = recursiveRet.Score;
                        retValue.Move = move;
                    }

                    alpha = Math.Max(alpha, retValue.Score);
                }
                else
                {
                    if (recursiveRet.Score < retValue.Score)
                    {
                        retValue.Score = recursiveRet.Score;
                        retValue.Move = move;
                    }

                    beta = Math.Min(beta, retValue.Score);
                }

                if (beta <= alpha) break;
            }

            return retValue;
        }
    }
}