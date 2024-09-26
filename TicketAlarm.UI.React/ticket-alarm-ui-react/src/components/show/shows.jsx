import React, { Component } from "react";
import ApiClient from "../../client/src/ApiClient";
import ShowApi from "../../client/src/api/ShowApi";
import Show from "./show";
import ShowInfo from "./showInfo";
import Caroussel from "../shared/caroussel";

class Shows extends Component {
  state = {
    shows: [],
  };

  async componentDidMount() {
    this.getShows();
  }

  getShows() {
    let apiClient = new ApiClient("https://localhost:7015/");
    let showApi = new ShowApi(apiClient);
    let that = this;
    showApi.apiShowsGet(null, (error, result) => {
      this.shows = result;
      this.setState({ shows: this.shows });
    });
    console.log(this.shows);
  }

  getQuarterShow(quarter){
    quarter = quarter;
    let quartierSize = this.state.shows.length / 4;
    console.log("quartierSizequartierSizequartierSize",quartierSize);

    let res =  this.state.shows.filter((elem, index) =>  (index >= (quarter - 1) * quartierSize) && (index < quarter * quartierSize)  ); 
    console.log(res);

    return res;
  }

  render() {
    // this.getShows();
    console.log(this.shows);
    let resut = null;

    let separator = this.state.shows.length / 4 ;
   
console.log("------9999999999-----",this.getQuarterShow(1));
    return (
      <span>
        <div class="container">
          <span className="p-3">
            <Caroussel></Caroussel>
          </span>
          <div class="row p-2">
            <h5>Événements disponibles :</h5>
          </div>
          <div class="row">
            <div class="col-3">
              {this.getQuarterShow(1).map((s) => (
                <div class="p-2">
                  <ShowInfo show={s} home={true}></ShowInfo>
                </div>
              ))}
            </div>
            <div class="col-3">
              {this.getQuarterShow(2).map((s) => (
                <div class="p-2">
                  <ShowInfo show={s} home={true}></ShowInfo>
                </div>
              ))}
            </div>
            <div class="col-3">
              {this.getQuarterShow(3).map((s) => (
                <div class="p-2">
                  <ShowInfo show={s} home={true}></ShowInfo>
                </div>
              ))}
            </div>
            <div class="col-3">
              {this.getQuarterShow(4).map((s) => (
                <div class="p-2">
                  <ShowInfo show={s} home={true}></ShowInfo>
                </div>
              ))}
            </div>
          </div>
        </div>
      </span>
    );
  }
}

export default Shows;
