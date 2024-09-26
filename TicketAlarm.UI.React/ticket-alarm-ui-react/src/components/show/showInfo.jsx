import { link } from "joi";
import React, { Component } from "react";

class ShowInfo extends Component {
  state = {
    date: "",
  };

  fixDate(number){
    return (number < 10 ? "0" + number : number) ;
  }

  render() {
    const { show, home = false } = this.props;
    console.log(this.props);
    if (show == null) return;

    let linkPart = "";
    if (home) {
      linkPart = (
        <span>
          <a href={"/alarm/" + show.id}>
            Recevoir une alerte
          </a>{" "}
          &#x23F0;
        </span>
      );
    } else {
      linkPart = (
        <span>
          <a href={show.url} target="_blank" >
            Lien évènement
          </a>
          &nbsp;&nbsp;&nbsp;
          <a href="/" >
            Retour
          </a>
        </span>
      );
    }

    console.log("---------------------",show);
    console.log("oui");
    this.state.date =  `${this.fixDate(show.dateTimeShow.getDate()) }/${
      this.fixDate(show.dateTimeShow.getMonth()+1)  
    }/${show.dateTimeShow.getFullYear()} ${this.fixDate(show.dateTimeShow.getHours()) }h${
      this.fixDate(show.dateTimeShow.getMinutes()) 
    } `;

    return (
      <span>
        <div class="card">
          <img className="img-thumbnail" src={show.artist.urlPhoto}></img>
          <div class="card-body">
            <h5 class="card-title">{show.artist.name}</h5>
            <p class="card-text">{show.title}</p>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">
              {show.city} - {show.arena}
            </li>
            <li class="list-group-item font-italic"> {this.state.date} </li>
          </ul>
          <div class="card-body">{linkPart}</div>
        </div>
      </span>
    );
  }
}

export default ShowInfo;
