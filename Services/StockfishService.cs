using Microsoft.JSInterop;

namespace ChessAI.Services;

public class StockfishService
{
    private readonly IJSRuntime _jsRuntime;

    public StockfishService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeEngine()
    {
        await _jsRuntime.InvokeVoidAsync("initializeStockfish");
    }

    public async Task<string> GetBestMove(string fen, int depth = 10)
    {
        return await _jsRuntime.InvokeAsync<string>("getBestMove", fen, depth);
    }

    public async Task SetDifficulty(int elo)
    {
        await _jsRuntime.InvokeVoidAsync("setEngineOption", "UCI_Elo", elo.ToString());
        await _jsRuntime.InvokeVoidAsync("setEngineOption", "UCI_LimitStrength", "true");
    }

    public async Task SetThreads(int threads)
    {
        await _jsRuntime.InvokeVoidAsync("setEngineOption", "Threads", threads.ToString());
    }

    public async Task SetHashSize(int mb)
    {
        await _jsRuntime.InvokeVoidAsync("setEngineOption", "Hash", mb.ToString());
    }

    public async Task<string> AnalyzePosition(string fen, int depth)
    {
        return await _jsRuntime.InvokeAsync<string>("analyzePosition", fen, depth);
    }

    public async Task<List<string>> GetTopMoves(string fen, int numMoves, int depth)
    {
        return await _jsRuntime.InvokeAsync<List<string>>("getTopMoves", fen, numMoves, depth);
    }

    public async Task StopAnalysis()
    {
        await _jsRuntime.InvokeVoidAsync("stopAnalysis");
    }
}