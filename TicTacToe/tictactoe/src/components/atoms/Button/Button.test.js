import { render } from '@testing-library/react';
import Button from './components/atoms/Button';

test('Button renders with correct label', () => {
  const { getByText } = render(<Button label="Click Me" />);
  expect(getByText('Click Me')).toBeInTheDocument();
});
