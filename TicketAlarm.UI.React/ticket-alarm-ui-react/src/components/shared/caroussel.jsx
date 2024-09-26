import React, { Component } from "react";

class Caroussel extends Component {
  state = {};
  render() {
    return (
      <div class="jumbotron p-3 p-md-5 text-white rounded bg-header">
        <div class="col-md-6 px-0">
          <h3 class="display-4 font-italic">
            Trouvez des billets pour les événements sold-out &#x1F3AB;
          </h3>
          <p class="lead my-3">
            TicketAlarm recherche à votre place des billets pour les événements
            sold-out. Nos robots fonctionnent jour et nuit, 24h/24h. &#x1F916;
          </p>
        </div>
      </div>
    );
  }
}

export default Caroussel;
