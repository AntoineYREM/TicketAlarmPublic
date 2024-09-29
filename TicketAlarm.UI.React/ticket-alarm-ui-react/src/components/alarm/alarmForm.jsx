import React, { Component } from "react";
import MyForm from "../../commun/form";
import Joi from "joi";
import AlarmApi from "./../../client/src/api/AlarmApi";
import AlarmDto from "../../client/src/model/AlarmDto";
import ApiClient from "../../client/src/ApiClient";
import { toast } from "react-toastify";
import config from "../../configuration/config.json";

class AlarmForm extends MyForm {
  state = {
    data: {
      email: "",
    },
    errors: {},
    submitted: false,
  };

  schema = Joi.object({
    email: Joi.string()
      .min(6)
      .required()
      .email({ tlds: { allow: false } }),
  });

  addAlarm() {
    let apiClient = new ApiClient(config.apiEndpoint);
    let alarmApi = new AlarmApi(apiClient);

    alarmApi.apiAlarmsPost(
      {
        alarmDto: {
          idShow: this.props.id,
          mail: this.state.data.email,
          phone: "",
        },
      },
      (error, result) => {
        if(error == null) window.location = "/confirmation";
        toast.error("Une erreur est survenue. Veuillez réessayer plus tard.")
      }
    );
  }

  doSubmit = async () => {
    this.addAlarm();
  };

  render() {
    var { id } = this.props;

    return (
      <form onSubmit={this.handleSubmit}>
        <span>
          <div class="container">
            <div className="row">
              <span class="display-6">Recevoir une alerte &#x23F0;</span>
            </div>
            <div class="row mt-3">
              <input
                onChange={this.handleChange}
                type="text"
                name="email"
                label="email"
                className="form-control form-control-lg"
                placeholder="Email"
              />
            </div>
            <div class="row  mt-3">
              {this.state.errors?.email ? (
                <div className="alert alert-danger">
                  Saisissez une adresse e-mail valide.
                </div>
              ) : (
                ""
              )}
            </div>
            <div class="row ">
              <button class="btn btn-lg btn-primary">Valider</button>
            </div>
          </div>
        </span>
      </form>
    );
  }
}

export default AlarmForm;
