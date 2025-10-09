import React, {useEffect, useState} from 'react';
import './App.css';
import 'h8k-components';

import Articles from './components/Articles';

const title = "Sorting Articles";

function App({articles}) {
    const [articleState, setArticleState] = useState(null);

    useEffect(() => {
    }, [articleState])

    const sortMostUpvotes = () => {
        const stateArticles = articleState ? [...articleState] : [...articles];
        const sortedArticles = stateArticles.sort((a, b) =>
        {
            const artA = a.upvotes;
            const artB = b.upvotes;
            if(artA < artB)
                return 1
            if(artA > artB)
                return -1
        })
        setArticleState(sortedArticles);
    }
    const sortMostRecent = () => {
        const stateArticles = articleState ? [...articleState] : [...articles];
        let sortedArticles = stateArticles.sort((a, b) =>
        {
            const artA = new Date(a.date);
            const artB = new Date(b.date);
            return artB - artA;
        })
        setArticleState(sortedArticles);
    }

    const articlesReturned = () => {
        if(articleState != null)
            return articleState
        else
            return articles
    }

    return (
        <div className="App">
            <h8k-navbar header={title}></h8k-navbar>
            <div className="layout-row align-items-center justify-content-center my-20 navigation">
                <label className="form-hint mb-0 text-uppercase font-weight-light">Sort By</label>
                <button data-testid="most-upvoted-link" className="small" onClick={sortMostUpvotes}>Most Upvoted</button>
                <button data-testid="most-recent-link" className="small" onClick={sortMostRecent}>Most Recent</button>
            </div>
            <Articles articles={articlesReturned()}/>
        </div>
    );

}

export default App;
