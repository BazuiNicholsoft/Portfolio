const { helloWorld } = require('./helloWorld');

test('returns "Hello, World!"', () => {
	expect(helloWorld()).toBe('Hello, World!');
});

test('returns a string', () => {
	expect(typeof helloWorld()).toBe('string');
});