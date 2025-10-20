import { render, screen } from '@testing-library/react';
import Button from './Button';

describe('Button Component', () => {
  it('Button renders with correct label', () => {
    render(<Button label="Click Me" onClick={() => {}}/>);
    expect(screen.getByText('Click Me')).toBeInTheDocument();
  });
});
