import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class Show extends Component {
    state = {  } 
    render() { 
        const { show } = this.props;

        return (<h5> {show.title} 
                <a>
                  <Link class="nav-link" to="/alarm/1">{show.id}</Link>
                </a>
         
         </h5>);
    }
}
 
export default Show;