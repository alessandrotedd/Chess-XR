using UnityEngine;

public class ChessBoard
{
    private ChessPiece[,] board = new ChessPiece[8, 8];

    public ChessPiece GetPieceAt(int x, int y)
    {
        return board[x, y];
    }

    public void SetPieceAt(int x, int y, ChessPiece piece)
    {
        board[x, y] = piece;
        piece.MoveTo(x, y);
    }

    public static bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }

    public void MovePiece(int fromX, int fromY, int toX, int toY)
    {
        ChessPiece piece = board[fromX, fromY];
        RemovePiece(fromX, fromY);
        SetPieceAt(toX, toY, piece);
    }

    public void RemovePiece(int x, int y)
    {
        board[x, y] = null;
    }

    public void SetupBoard()
    {
        board = new ChessPiece[8, 8];
        SetPieceAt(0, 0, new ChessPiece(ChessType.Rook, ChessColor.Black, 0, 0));
        SetPieceAt(1, 0, new ChessPiece(ChessType.Knight, ChessColor.Black, 1, 0));
        SetPieceAt(2, 0, new ChessPiece(ChessType.Bishop, ChessColor.Black, 2, 0));
        SetPieceAt(3, 0, new ChessPiece(ChessType.Queen, ChessColor.Black, 3, 0));
        SetPieceAt(4, 0, new ChessPiece(ChessType.King, ChessColor.Black, 4, 0));
        SetPieceAt(5, 0, new ChessPiece(ChessType.Bishop, ChessColor.Black, 5, 0));
        SetPieceAt(6, 0, new ChessPiece(ChessType.Knight, ChessColor.Black, 6, 0));
        SetPieceAt(7, 0, new ChessPiece(ChessType.Rook, ChessColor.Black, 7, 0));
        for (int x = 0; x < 8; x++)
        {
            SetPieceAt(x, 1, new ChessPiece(ChessType.Pawn, ChessColor.Black, x, 1));
            SetPieceAt(x, 6, new ChessPiece(ChessType.Pawn, ChessColor.White, x, 6));
        }
        SetPieceAt(0, 7, new ChessPiece(ChessType.Rook, ChessColor.White, 0, 7));
        SetPieceAt(1, 7, new ChessPiece(ChessType.Knight, ChessColor.White, 1, 7));
        SetPieceAt(2, 7, new ChessPiece(ChessType.Bishop, ChessColor.White, 2, 7));
        SetPieceAt(3, 7, new ChessPiece(ChessType.Queen, ChessColor.White, 3, 7));
        SetPieceAt(4, 7, new ChessPiece(ChessType.King, ChessColor.White, 4, 7));
        SetPieceAt(5, 7, new ChessPiece(ChessType.Bishop, ChessColor.White, 5, 7));
        SetPieceAt(6, 7, new ChessPiece(ChessType.Knight, ChessColor.White, 6, 7));
        SetPieceAt(7, 7, new ChessPiece(ChessType.Rook, ChessColor.White, 7, 7));
    }

    public void PrintBoard()
    {
        string boardString = "";
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                ChessPiece piece = GetPieceAt(x, y);
                boardString += (piece == null) ? "□" : piece.GetSymbol();
            }
            boardString += "\n";
        }
        Debug.Log(boardString);
    }
}
