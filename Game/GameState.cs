using ChessAI.Models;

namespace ChessAI.Game
{
    // Represents the current state of the game, such as active color and move counters
    public class GameState
    {
        // Tracks the active player's turn (White or Black)
        public ChessPiece.PieceColor ActiveColor { get; set; } = ChessPiece.PieceColor.White;

        // Tracks the number of halfmoves since the last capture or pawn move (for fifty-move rule)
        public int HalfmoveClock { get; set; }

        // Tracks the total number of full moves (incremented after Black's move)
        public int FullmoveNumber { get; set; } = 1;

        public void ToggleActiveColor()
        {
            ActiveColor = ActiveColor == ChessPiece.PieceColor.White
                ? ChessPiece.PieceColor.Black
                : ChessPiece.PieceColor.White;
        }

        public void UpdateHalfmoveClock(ChessPiece piece, ChessMove move, ChessPiece?[,] pieces)
        {
            // Check if a pawn moved or a capture occurred at the destination square
            if (piece.Type == ChessPiece.PieceType.Pawn || pieces[move.ToRow, move.ToCol] != null)
                HalfmoveClock = 0;
            else
                HalfmoveClock++;
        }

        public void UpdateFullmoveNumber()
        {
            if (ActiveColor == ChessPiece.PieceColor.White)
                FullmoveNumber++;
        }

        public void ResetGame()
        {
            ActiveColor = ChessPiece.PieceColor.White;  
        }
    }
}
