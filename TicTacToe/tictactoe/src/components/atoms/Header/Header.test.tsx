import { render, screen } from '@testing-library/react';
import Header from './Header';
import '@testing-library/jest-dom/extend-expect';

describe('renders Header component', () => {
    it('renders with correct text', () => {
        render(<Header text="Welcome to Tic Tac Toe" />);
        expect(screen.getByText('Welcome to Tic Tac Toe')).toBeInTheDocument();
    });
});