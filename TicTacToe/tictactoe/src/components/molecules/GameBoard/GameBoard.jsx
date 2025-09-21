import Square from '../Square';
import styles from '../../atoms/Button/Button.module.css';
import './GameBoard.css';
const GameBoard = ({ board, onClickCell }) => {
  return (
    <div className="gameBoard">
        <div className="boardRow">
            {board.slice(0, 3).map((value, index) =>
                index === 1 ? (
                    <Square key={index} value={value} className={styles.TopMiddleButton} onClick={() => onClickCell(index)} />
                ) : (
                    <Square key={index} value={value} onClick={() => onClickCell(index)} />
                )
            )}
        </div>
        <div className="boardRow">
            {board.slice(3, 6).map((value, index) => (
                index === 0 ? (
                    <Square key={index + 3} value={value} className={styles.MiddleLeftButton} onClick={() => onClickCell(index + 3)} />
                ) :
                index === 2 ? (
                    <Square key={index + 3} value={value} className={styles.MiddleRightButton} onClick={() => onClickCell(index + 3)} />
                ) : (
                    <Square key={index + 3} value={value} className={styles.MiddleButton} onClick={() => onClickCell(index + 3)} />
                )
            ))}
        </div>
        <div className="boardRow">
            {board.slice(6, 9).map((value, index) => (
                index === 1 ? (
                    <Square key={index + 6} value={value} className={styles.BottomMiddleButton} onClick={() => onClickCell(index + 6)} />
                ) : (   
                <Square key={index + 6} value={value} onClick={() => onClickCell(index + 6)} />
                )
            ))}            
        </div>
    </div>
  );
};

export default GameBoard;