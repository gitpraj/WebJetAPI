import React, { Component } from 'react';
import { Jumbotron } from 'react-bootstrap';

export class Movie extends Component {
    displayName = Movie.name

    constructor(props) {
        super(props);
    }

    render() {
        const title = this.props.movieSummary.title;
        const imgSrc = this.props.movieSummary.poster; // not working
        const year = this.props.movieSummary.year;
        const id = this.props.movieSummary.id;
        const provider = this.props.movieSummary.provider;
        console.log("movie: " + JSON.stringify(this.props.movieSummary));
        return (
            <div id={id}>
                <Jumbotron>
                    <h2>{title}</h2>
                    <p>
                        Year: {year} <br/>
                        Provider: {provider}
                    </p>
                    <p>
                        <em>Price: </em><strong>15$</strong>
                    </p>
                </Jumbotron>
            </div>
        );
    }
}
