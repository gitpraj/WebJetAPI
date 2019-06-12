import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MovieList extends Component {
    displayName = MovieList.name

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div class="well">
                <strong>John Wick 4</strong>
                <p>IMDB rating: <strong>7.8</strong></p>
                <Link to={'/movie'}>Check Price</Link>
            </div>
        );
    }
}
