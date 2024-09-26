import React, { Component } from 'react';
import { Link } from 'react-router-dom';


class Navbar extends Component {
    state = {  } 
    render() { 
        return (<nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="#">Navbar</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
              <ul class="navbar-nav">
                <li class="nav-item active">
                  <Link class="nav-link" to="/">Home <span class="sr-only">(current)</span></Link>
                </li>
                <li class="nav-item">
                  <Link class="nav-link" to="/bonjour">Features</Link>
                </li>
                <li class="nav-item">
                  <Link class="nav-link" to="/">Pricing</Link>
                </li>
                <li class="nav-item">
                  <Link class="nav-link" to="/bonjour/1">Disabled</Link>
                </li>
                <li class="nav-item">
                  <Link class="nav-link" to="/monform">monform</Link>
                </li>

                
              </ul>
            </div>
          </nav>);
    }
}
 
export default Navbar;