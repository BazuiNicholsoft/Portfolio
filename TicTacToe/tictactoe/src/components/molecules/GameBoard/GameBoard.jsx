import Square from '../Square';
const GameBoard = ({ board, onClickCell }) => {
  return (
    <div className="game-board">
        <div className="board-row">
            {board.slice(0, 3).map((value, index) => (
                <Square key={index} value={value} onClick={() => onClickCell(index)} />
            ))}
        </div>
        <div className="board-row">
            {board.slice(3, 6).map((value, index) => (
                <Square key={index + 3} value={value} onClick={() => onClickCell(index + 3)} />
            ))}
        </div>
        <div className="board-row">
            {board.slice(6, 9).map((value, index) => (
                <Square key={index + 6} value={value} onClick={() => onClickCell(index + 6)} />
            ))}
        </div>
    </div>
  );
};

export default GameBoard;