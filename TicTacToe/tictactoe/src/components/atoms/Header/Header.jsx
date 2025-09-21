import React from 'react';
import './Header.css';

const Header = ( { text } ) => {
    return (
        <header className="App-header">
            {text}
        </header>
    );
}

export default Header;