import { render, screen } from "@testing-library/react";
import Label from "./Label";
import '@testing-library/jest-dom/extend-expect';

test("Label renders with correct text", () => {
  it('renders with correct text', () => {
    render(<Label text="Test Label" />);
    expect(screen.getByText("Test Label")).toBeInTheDocument();
  });
});
