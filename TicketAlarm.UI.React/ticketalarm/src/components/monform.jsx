import React, { Component } from 'react';
import Joi from 'joi-browser';
import Form from './common/form';
import AlarmApi from '../client/src/api/AlarmApi';
import ArtistApi from './../client/src/api/ArtistApi';
import ApiClient from '../client/src/ApiClient';
import { GetShows } from './../services/fakeShowService';
import config from "../configuration/config.json"
import { toast } from 'react-toastify'

class MonForm extends Form {
    state = { 
        
        account: {
            username : "",
            password : ""
        },
        errors: { }
    } 

    schema = {
        username: Joi.string().email(),
        password: Joi.string()
    }

    render() { 

      console.log(config.apiEndpoint);

      toast.error("oui ouio ui");
      var a = new ArtistApi(new ApiClient("https://localhost:7015"));
      var result = a.apiArtistsGet((a, b) => console.log("aaaaaaaaaaaaaaa",b));
      console.log(result);

        return (
            <form onSubmit={this.handleSubmit}>
            <div className="form-group">
              <label htmlFor="exampleInputEmail1">Email address</label>
              <input value={this.state.account.email} onChange={this.handleChange} ref={this.username} id="username" name="username" type="email" className="form-control"  aria-describedby="emailHelp" placeholder="Enter email"/>
              <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div className="form-group">
              <label htmlFor="exampleInputPassword1">Password</label>
              <input type="password" id="password" name="password"  className="form-control" onChange={this.handleChange}   placeholder="Password"/>
            </div>
            <div className="form-group form-check">
              <input type="checkbox" className="form-check-input" id="exampleCheck1"/>
              <label className="form-check-label" htmlFor="exampleCheck1">Check me out</label>
            </div>

            <button type="submit" className="btn btn-primary">Submit</button>
          </form>);
    }
}
 
export default MonForm;