import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Movies } from './components/Movies';
import { Movie } from './components/Movie';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/movies' component={Movies} />
        <Route path='/movie' component={Movie} />
      </Layout>
    );
  }
}
