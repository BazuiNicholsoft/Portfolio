import { render } from "@testing-library/react";
import Label from "./Label";
import '@testing-library/jest-dom/extend-expect';

test("Label renders with correct text", () => {
  const { getByText } = render(<Label text="Test Label" />);    
  expect(getByText("Test Label")).toBeInTheDocument();
});
