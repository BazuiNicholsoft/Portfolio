import { render, fireEvent, screen } from '@testing-library/react';
import TicTacToe from './TicTacToe';

describe('TicTacToe component', () => {
  test('renders without crashing', () => {
    const { container } = render(<TicTacToe />);
    expect(container).toBeTruthy();
  });
  
  test('renders header and start button', () => {
    render(<TicTacToe />);
    expect(screen.getByText(/tic tac toe game/i)).toBeInTheDocument();
    expect(screen.getByRole('button', { name: /start game/i })).toBeInTheDocument();
  });

  test('start button changes to restart after click', () => {
    render(<TicTacToe />);
    const startButton = screen.getByRole('button', { name: /start game/i });
    fireEvent.click(startButton);
    expect(screen.getByRole('button', { name: /restart game/i })).toBeInTheDocument();
  });

  test('clicking a cell updates the board', () => {
    render(<TicTacToe />);
    fireEvent.click(screen.getByRole('button', { name: /start game/i }));
    // Assuming GameBoard renders buttons for each cell
    const cells = screen.getAllByRole('button').filter(btn => btn.textContent === '');
    fireEvent.click(cells[0]);
    expect(cells[0].textContent).toBe('X');
  });

  test('calculateWinner returns correct winner', () => {
    // Access the calculateWinner function via the component instance is not possible,
    // but you can test the winning logic by simulating moves.
    render(<TicTacToe />);
    fireEvent.click(screen.getByRole('button', { name: /start game/i }));
    const cells = screen.getAllByRole('button').filter(btn => btn.textContent === '');
    // Simulate X winning on the top row
    fireEvent.click(cells[0]); // X
    fireEvent.click(cells[3]); // O
    fireEvent.click(cells[1]); // X
    fireEvent.click(cells[4]); // O
    fireEvent.click(cells[2]); // X wins
    expect(screen.getByText(/winner/i)).toBeInTheDocument();
  });
});
