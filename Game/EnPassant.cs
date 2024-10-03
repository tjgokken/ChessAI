using ChessAI.Models;

namespace ChessAI.Game
{
    // Represents the en passant target square, or "-" if not available
    public class EnPassant
    {
        public string EnPassantTarget { get; set; } = "-";

        /// <summary>
        ///     Updates the en passant target when a pawn moves two squares forward.
        /// </summary>
        public void UpdateTarget(ChessPiece piece, ChessMove move)
        {
            if (piece.Type == ChessPiece.PieceType.Pawn && Math.Abs(move.ToRow - move.FromRow) == 2)
            {
                var enPassantRow = (move.FromRow + move.ToRow) / 2;
                var enPassantCol = (char)('a' + move.FromCol);
                EnPassantTarget = $"{enPassantCol}{enPassantRow + 1}";
            }
            else
            {
                EnPassantTarget = "-";
            }
        }
    }
}
