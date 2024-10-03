let stockfish;

function initializeStockfish() {
    return new Promise((resolve) => {
        stockfish = new Worker('stockfish.js');
        stockfish.onmessage = function (event) {
            if (event.data.startsWith("readyok")) {
                resolve();
            }
        };
        stockfish.postMessage('uci');
        stockfish.postMessage('isready');
    });
}

function getBestMove(fen, depth) {
    return new Promise((resolve) => {
        stockfish.onmessage = function (event) {
            if (event.data.startsWith("bestmove")) {
                resolve(event.data.split(" ")[1]);
            }
        };
        stockfish.postMessage(`position fen ${fen}`);
        stockfish.postMessage(`go depth ${depth}`);
    });
}

window.initializeStockfish = initializeStockfish;
window.getBestMove = getBestMove;