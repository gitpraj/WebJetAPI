import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
      return (
        <div>
            <h1>Hey Guys, Prajith Maniyan here!!</h1>
            <p>First of all, thanks for giving me the opportunity.</p>
            <p>Links to my profiles::</p>
            <ul>
                <li><a href='https://github.com/gitpraj/'>GitHub</a> Check out my projects</li>
                <li><a href='https://www.linkedin.com/in/prajith-maniyan-03291273/'>Linkedin</a> Connect with me if you can</li>
                <li><a href='http://www.prajithmaniyan.com/'>Portfolio</a> You are in for a ride</li>
            </ul>
            <p>Play around with the <strong>app</strong>. And let me know how good it is!!</p>
        </div>
    );
  }
}
