import { render, screen } from '@testing-library/react';
import App from './App';

test('Renders App component', () => {
  it('renders TicTacToe component', () => {
    render(<App />);
    expect(screen.getByText('Tic Tac Toe Game')).toBeInTheDocument();
  });
});
