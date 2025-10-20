import './Header.css';

const Header = ( { text }: { text: string } ) => {
    return (
        <header className="App-header">
            {text}
        </header>
    );
}

export default Header;