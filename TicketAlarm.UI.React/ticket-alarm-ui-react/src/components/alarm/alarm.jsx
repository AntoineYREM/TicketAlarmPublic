import React, { Component } from "react";
import ApiClient from "../../client/src/ApiClient";
import ShowApi from "../../client/src/api/ShowApi";
import config from "../../configuration/config.json";
import { toast } from "react-toastify";
import AlarmForm from "./alarmForm";
import ShowInfo from "../show/showInfo";

class Alarm extends Component {
  state = {
    show: null,
  };

  componentDidMount() {
    this.getShow(this.props.id);
  }

  getShow(id) {
    let apiClient = new ApiClient(config.apiEndpoint);
    let showApi = new ShowApi(apiClient);
    showApi.apiShowsIdShowGet(id, (error, show) => {
      if (error == null) this.setState({ show: show });
      else
        toast.error("Une erreur est survenue, veuillez réessayer plus tard.");
    });
  }

  render() {
    var { id } = this.props;

    return (
      <div class="container">
        <div class="row">
          <div class="col-4">
            <ShowInfo show={this.state.show}></ShowInfo>
          </div>
          <div class="col-8">
            <AlarmForm id={id}></AlarmForm>
          </div>
        </div>
      </div>
    );
  }
}

export default Alarm;
