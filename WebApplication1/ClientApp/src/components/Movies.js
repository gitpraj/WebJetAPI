import React, { Component } from 'react';
import { Movie } from './Movie';
import { Form, FormGroup, ControlLabel, FormControl } from 'react-bootstrap';
import '../index.css';

export class Movies extends Component {
    displayName = Movies.name

    constructor(props) {
        super(props);
        this.state = { movies: [], noResult: false, errors: "" };

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
                    this.setState({ movies: data.message, noResult: true });
                }

                if (data.length > 0) {
                    this.setState({ movies: data, noResult: false });
                } else {
                    console.log("the mjovie is not found")
                    this.setState({ movies: data, noResult: true });
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
            ? <div className="no-res"><h1>Movie Not Found</h1></div>
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
