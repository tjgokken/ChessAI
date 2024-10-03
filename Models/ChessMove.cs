namespace ChessAI.Models;

public class ChessMove(int fromRow, int fromCol, int toRow, int toCol)
{
    public int FromRow { get; set; } = fromRow;
    public int FromCol { get; set; } = fromCol;
    public int ToRow { get; set; } = toRow;
    public int ToCol { get; set; } = toCol;

    public static ChessMove FromUci(string uci)
    {
        var fromCol = uci[0] - 'a';
        var fromRow = uci[1] - '1';
        var toCol = uci[2] - 'a';
        var toRow = uci[3] - '1';
        return new ChessMove(fromRow, fromCol, toRow, toCol);
    }
}