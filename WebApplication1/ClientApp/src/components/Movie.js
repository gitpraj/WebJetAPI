import React, { Component } from 'react';
import { Jumbotron } from 'react-bootstrap';

export class Movie extends Component {
    displayName = Movie.name  

    constructor(props) {
        super(props);
        this.state = { price: '', errors: ""};
    }

    componentDidMount() {
        console.log("fetch the price of movie")
        const id = this.props.movieSummary.id;
        const provider = this.props.movieSummary.provider;
        fetch('api/Movies/GetMoviePrice/?provider='+provider+'&id=' + id)
            .then(response => response.json())
            .then(data => {
                if (!data.ok) {
                    this.setState({ errors: data.message});
                }

                if (data > 0) {
                    this.setState({ price: data });
                } else {
                    console.log("price not there")
                    this.setState({ price: "Not Available" });
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

        return (
            <div id={id}>
                <Jumbotron>
                    <h2>{title}</h2>
                    <p>
                        Year: {year} <br/>
                        Provider: {provider}
                    </p>
                    <p>
                        <em>Price: </em><strong>{price}</strong>
                    </p>
                </Jumbotron>
            </div>
        );
    }
}
