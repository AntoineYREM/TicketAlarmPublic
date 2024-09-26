import React, { Component, PureComponent } from 'react';
import { GetShows } from '../services/fakeShowService';

class Show extends Component {
    state = { 
        shows : GetShows()
    };

    GetTableShowElements () {
      
    }

    DeleteShow(id){
        this.state.shows = this.state.shows.filter(s => s.id != id);
        this.setState({
            shows: this.state.shows
        });
        console.log(this.state.shows );
    }

    render(){
        console.log(this.props);
        // this.props.onDelete();

        const { title, img } = this.props.showInformations;

        return <React.Fragment>

<div className="card shadow-sm">
<img className="card-img-top" src={img} alt="Card image cap"/>
{/* <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"></rect><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg> */}
<div className="card-body">
  <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
  <div className="d-flex justify-content-between align-items-center">
    <div className="btn-group">
      <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
      <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
    </div>
    <small className="text-body-secondary">9 mins</small>
  </div>
</div>
</div>
            {/* <div className="card" style={{ width: '18rem' }}>
              <img className="card-img-top" src={img} alt="Card image cap"/>
              <div className="card-body">
                <h5 className="card-title">{ title }</h5>
                <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div> */}
        </React.Fragment>;
    }
}

export default Show;