namespace ChessAI.Game
{
    // Tracks whether a king or rook has moved (affects castling)
    public class PieceMovementTracker
    {
        public bool KingMoved { get; set; } = false;
        public bool KingsideRookMoved { get; set; } = false;
        public bool QueensideRookMoved { get; set; } = false;

        public bool CanCastleKingside() => !KingMoved && !KingsideRookMoved;
        public bool CanCastleQueenside() => !KingMoved && !QueensideRookMoved;

        public void MarkKingMoved() => KingMoved = true;
        public void MarkRookMoved(bool kingside) => _ = kingside ? KingsideRookMoved = true : QueensideRookMoved = true;
        public void MarkRookMovedByColumn(int col) => _ = col == 0 ? QueensideRookMoved = true : KingsideRookMoved = true;
    }
}
