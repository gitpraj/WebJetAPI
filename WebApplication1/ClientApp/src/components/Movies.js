import React, { Component } from 'react';
import { Movie } from './Movie';
import { Form, FormGroup, ControlLabel, FormControl } from 'react-bootstrap';
import '../index.css';

export class Movies extends Component {
    displayName = Movies.name

    constructor(props) {
        super(props);
        this.state = { movies: [], noResult: true, errorMessage : ""};

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        const str = this.state.value;
        fetch('api/Movies/GetMovie/?searchTerm=' + str)
            .then(response => response.json())
            .then(data => {
                if (!data.ok) {
                    this.setState({ movies: [], noResult: true, errorMessage: "Movie Not Available"});
                }

                if (data.length > 0) {
                    this.setState({ movies: data, noResult: false, errorMessage: ""});
                } else {
                    this.setState({ movies: [], noResult: true, errorMessage: "Movie Not Available"});
                }
            });
    }

  static moviesDisplay(movies) {
      return (

          movies.map(movie =>
              <Movie key={movie.id} movieSummary={movie} />
        )
     );
  }

    render() {
        let contents = this.state.noResult
            ? <div className="no-res"><h1>{this.state.errorMessage}</h1></div>
        : Movies.moviesDisplay(this.state.movies);

    return (
      <div>
        <h1>Search for Movies</h1>
            <Form onSubmit={this.handleSubmit}>
                <FormGroup controlId="templateTitle">
                    <FormControl type="text" placeholder="Enter a Movie Title and press Enter"
                        value={this.state.value} onChange={this.handleChange} />
                </FormGroup>
            </Form>
            <div>
                {contents}
            </div>
      </div>
    );
  }
}
