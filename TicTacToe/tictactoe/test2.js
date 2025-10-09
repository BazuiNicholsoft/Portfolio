import React, {useEffect} from 'react';

function Articles(props) {
    const articles = props.articles || [];

    return (
        <div className="card w-50 mx-auto">
            <table>
                <thead>
                <tr>
                    <th>Title</th>
                    <th>Upvotes</th>
                    <th>Date</th>
                </tr>
                </thead>
                <tbody>
                                {articles.map(function(article, idx) {
                                    // Use a stable key so React can correctly track items when
                                    // the list is reordered. If `title` isn't unique in your
                                    // dataset, replace with a unique id instead.
                                    const key = article.title || idx;
                                    return (
                                        <tr data-testid="article" key={key}>
                                            <td data-testid="article-title">{article.title}</td>
                                            <td data-testid="article-upvotes">{article.upvotes}</td>
                                            {/* match the date field name used by the parent ("dates") */}
                                            <td data-testid="article-date">{article.dates || article.date}</td>
                                        </tr>
                                    )
                                })}
                </tbody>
            </table>
        </div>
    );

}

export default Articles;
