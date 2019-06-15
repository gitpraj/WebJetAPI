import React, { Component } from 'react';
import { Jumbotron } from 'react-bootstrap';

export class Movie extends Component {
    displayName = Movie.name  

    constructor(props) {
        super(props);
        this.state = { price: '', noResult: true};
    }

    componentDidMount() {
        const id = this.props.movieSummary.id;
        const provider = this.props.movieSummary.provider;
        fetch('api/Movies/GetMoviePrice/?provider='+provider+'&id=' + id)
            .then(response => response.json())
            .then(data => {
                if (!data.ok) {
                    this.setState({ price: data, noResult: true});
                }

                if (data > 0) {
                    this.setState({ price: data, noResult: false});
                } else {
                    this.setState({ price: "Not Available", noResult: true});
                }
            });
    }

    render() {
        const title = this.props.movieSummary.title;
        const imgSrc = this.props.movieSummary.poster; // not working
        const year = this.props.movieSummary.year;
        const id = this.props.movieSummary.id;
        const provider = this.props.movieSummary.provider;
        const { price } = this.state;

        let loading = this.state.noResult ? "Loading" : price

        return (
            <div id={id}>
                <Jumbotron>
                    <h2>{title}</h2>
                    <p>
                        Year: {year} <br/>
                        Provider: {provider}
                    </p>
                    <p>
                        <em>Price: </em><strong>{loading}</strong>
                    </p>
                </Jumbotron>
            </div>
        );
    }
}
