import React, { Component } from 'react';
import Show from './show';
import { GetShows } from '../services/fakeShowService';
import Pagination from './table';

class Shows extends Component {
    state = {  
        shows : GetShows()
    } 

    handleDelete = () => {
        console.log("le parent");
    }

    handlePageChange(){
        console.log("nouvelle page");
    }

    render() { 
        return (
            <React.Fragment>
                <div className="album py-5 bg-body-tertiary">
                    <div className="container">
                        <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-3">
                            
                                { this.state.shows.map(s => <div className="col"><Show antoine="oui" showInformations={s}></Show></div> ) }
                            
                        </div>
                    </div>
                </div>
                <Pagination count={this.state.shows.count} onPageChange={this.handlePageChange}></Pagination>
            </React.Fragment>

        
        );
    }
}
 
export default Shows;





{/*  */}