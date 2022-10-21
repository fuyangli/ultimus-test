import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Ultimus Test</h1>
        <ul>
          <li><a href='/swagger'>Swagger</a></li>
          <li><a href='/orders'>Orders System</a></li>
        </ul>
      </div>
    );
  }
}
