import React, { Component } from 'react';
import { Movie } from './Movie';
import { Form, FormGroup, FormControl } from 'react-bootstrap';
import '../index.css';

export class Movies extends Component {
    displayName = Movies.name

    constructor(props) {
        super(props);
        this.state = { movies: [], noResult: true, errorMessage : "", loading: false};

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.setState({ loading: true, errorMessage: "Loading....."});
        const str = this.state.value;
        fetch('api/Movies/GetMovie/?searchTerm=' + str)
            .then(response => response.json())
            .then(data => {
                if (!data.ok) {
                    this.setState({ movies: [], noResult: true, errorMessage: "Movie Not Available", loading: false});
                }

                if (data.length > 0) {
                    this.setState({ movies: data, noResult: false, errorMessage: "", loading: false});
                } else {
                    this.setState({ movies: [], noResult: true, errorMessage: "Movie Not Available", loading: false});
                }
            });
    }

  static moviesDisplay(movies, searchStr) {
      return (
          <div>
              {movies.map(movie =>
                  <Movie key={movie.id} movieSummary={movie} />)}
          </div>
     );
  }

    render() {
        let contents = this.state.noResult
            ? <div className="no-res">{this.state.errorMessage}</div>
            : Movies.moviesDisplay(this.state.movies);

    return (
      <div>
        <h1 className="movies-head">Search for Movies</h1>
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
