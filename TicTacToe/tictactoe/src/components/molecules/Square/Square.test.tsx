import { render, screen } from '@testing-library/react';
import Square from "./Square";

describe('Square renders correctly', () => {
  it('displays the correct value', () => {
    render(<Square value="X" onClick={() => {}} />);
    expect(screen.getByText("X")).toBeInTheDocument();
  });
});