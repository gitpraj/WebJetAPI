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
                <li><a href='https://github.com/gitpraj/' target="_blank">GitHub</a> Check out my projects</li>
                <li><a href='https://www.linkedin.com/in/prajith-maniyan-poosappadi-03291273/' target="_blank">Linkedin</a> Connect with me if you can</li>
                <li><a href='http://www.prajithmaniyan.com/' target="_blank">Portfolio</a> You are in for a ride</li>
            </ul>
              <p>Play around with the <strong>app</strong>. And let me know how good it is!!</p>

              <p>App Description</p>

              <p>This is a demo app for WebJetTestAPI. I am sure I have done a good job to demonstrate my web app development skills.</p>

              <ul>
                  <li>The external API response is as quick as possible. </li>
                  <li>Two different API's are being handled asynchrnously.</li>
                  <li>The results are cached. The app would still be functioning even if the API fails.</li>
                  <li>I have made sure the App follows the SOLID prinicples as much as possible.</li>
                  <li>Unit testing done for the web api controllers</li>
              </ul>

              <p>Improvements to be done:</p>
              <ul>
                  <li>The entire front end needs to be improved, I did not spend a lot of time on the UI.</li>
                  <li>Authentication/Authorization for the the API's</li>
                  <li>Pagination can be implemented</li>
              </ul>

         </div>
    );
  }
}
