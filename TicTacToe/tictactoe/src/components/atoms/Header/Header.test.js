import { render } from '@testing-library/react';
import Header from './Header';
import '@testing-library/jest-dom/extend-expect';

test('renders Header component', () => {
    const { getByText } = render(<Header />);
    expect(getByText('Tic Tac Toe Game')).toBeInTheDocument();
});

