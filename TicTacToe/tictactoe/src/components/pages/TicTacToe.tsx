import { useState } from 'react';
import { Header, Button } from '../atoms';
import { GameInfo } from '../molecules';
import { GameBoard } from '../molecules';
import ticTacToeStyles from './TicTacToe.module.css';
import ButtonStyles from '../atoms/Button/Button.module.css';


const TicTacToe = () => {
  const [inprogress, setInProgress] = useState(false);
  const [board, setBoard] = useState(Array(9).fill(null as string | null));
  const [wins, setWins] = useState(0);
  const [draws, setDraws] = useState(0);
  const [losses, setLosses] = useState(0);
  const [currPlayer, setCurrPlayer] = useState('X');
  const [winner, setWinner] = useState(null as string | null);

  const onClickStart = () => {
    if (inprogress !== true) {
      setInProgress(true);
    }
    setBoard(Array(9).fill(null));
    setCurrPlayer('X');
    setWinner(null);  
  }

  const onClickCell = (index: number) => {
    if (!inprogress || board[index] || winner) return;

    const newBoard: string[] = [...board];
    newBoard[index] = currPlayer;
    setBoard(newBoard);

    // Check for a winner
    const newWinner: string | null = calculateWinner(newBoard);
    if (newWinner) {
      setWinner(newWinner);
      if (newWinner === 'X') {
        setWins(wins + 1);
      } else {
        setLosses(losses + 1);
      }
      setInProgress(false);
    } else if (newBoard.every(cell => cell)) {
      setDraws(draws + 1);
      setInProgress(false);
    } else {
      setCurrPlayer(currPlayer === 'X' ? 'O' : 'X');
    }
  }
  const calculateWinner = (board: string[]) => {
    const lines = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8],
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8],
      [0, 4, 8],
      [2, 4, 6],
    ];
    for (let [a, b, c] of lines) {
      if (board[a] && board[a] === board[b] && board[a] === board[c]) {
        return board[a];
      }
    }
    return null;
  }

  return (
  <div className={ticTacToeStyles.MainContainer}>
    <Header text="Tic Tac Toe Game" />
    <div className={ticTacToeStyles.GameContainer}>
      <div className={ticTacToeStyles.ButtonContainer}>
        <Button label={inprogress ? "Restart Game" : "Start Game"} className={ButtonStyles.button} onClick={onClickStart} />
      </div>
      <div className={ticTacToeStyles.InfoBoardContainer}>
        <GameInfo wins={wins} draws={draws} losses={losses} currPlayer={currPlayer} winner={winner} />
      </div>
      <div className={ticTacToeStyles.GameBoardContainer}>
        <GameBoard board={board} onClickCell={onClickCell} />
      </div>
    </div>
  </div>
  );
};
export default TicTacToe;
