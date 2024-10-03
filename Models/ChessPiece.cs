using ChessAI.Models;

namespace ChessAI.Models;

public class ChessPiece
{
    public enum PieceColor
    {
        White,
        Black
    }

    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    public ChessPiece(PieceType type, PieceColor color, int row, int col)
    {
        Type = type;
        Color = color;
        Row = row;
        Col = col;
    }

    public PieceType Type { get; set; }
    public PieceColor Color { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }

    // TODO: Implement GetValidMoves() method
    public List<(int, int)> GetValidMoves(ChessBoard board)
    {
        // This method should return a list of valid moves for this piece
        // based on its type and the current board state
        throw new NotImplementedException();
    }
}