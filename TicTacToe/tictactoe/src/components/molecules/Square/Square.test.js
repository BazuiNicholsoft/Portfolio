test('Square renders correctly', () => {
  const { getByText } = render(<Square value="X" onClick={() => {}} />);
  expect(getByText("X")).toBeInTheDocument();
});