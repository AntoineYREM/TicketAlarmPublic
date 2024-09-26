import React, { Component } from "react";

class AlarmConfirmation extends Component {
  state = {};
  render() {
    return (
      <div class="container">
        <div className="row text-center m-5">
          <h1>&#x1F4E3;</h1>
        </div>
        <div className="row text-center">
          <div className="col-3"></div>
          <div className="col-6">
            <h1>Félicitations, pour votre inscription à la liste d'attente.</h1>
          </div>
          <div className="col-3"></div>
        </div>
        <div className="row text-center m-5">
          <h3>Merci pour votre inscription !</h3>
          <a href="/" class="card-link">
            Retour à l'accueil
          </a>
        </div>

        <div className="row text-center m-5">
          <h1>&#128131; &#x1F389; &#x1F38A; &#128378;</h1>
        </div>
      </div>
    );
  }
}

export default AlarmConfirmation;
