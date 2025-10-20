import {render, screen, fireEvent} from '@testing-library/react';
import GameBoard from './GameBoard';

describe('GameBoard Component', () => {
  const mockOnClickCell = jest.fn();
  const board = ['X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', 'X'];
    beforeEach(() => {
        render(<GameBoard board={board} onClickCell={mockOnClickCell} />);
    });

    it('renders all squares with correct values', () => {
        board.forEach((value) => {
            expect(screen.getByText(value)).toBeInTheDocument();
        });
    });
    it('calls onClickCell with correct index when a square is clicked', () => {
        const squares = screen.getAllByRole('button');
        squares.forEach((square, index) => {
            fireEvent.click(square);
            expect(mockOnClickCell).toHaveBeenCalledWith(index);
        });
    });
});