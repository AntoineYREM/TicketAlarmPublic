import React, { Component } from 'react';
import Joi  from 'joi';

class MyForm extends Component {
 

    validate = () => {
        const options = { abortEarly: false };
        // const { error } = Joi.validate(this.state.data, this.schema, options);

        const { error } =   this.schema.validate(this.state.data);
        if (!error) return null;
    
        const errors = {};
        for (let item of error.details) {
          errors[item.path[0]] = item.message;
        }
        return errors;
      };
    
      validateProperty = ({ name, value }) => {
        const obj = { [name]: value };
        const schema = { [name]: this.schema[name] };
        const { error } =  this.schema.validate(obj);
        return error ? error.details[0].message : null;
      };

      handleSubmit = e => {
        e.preventDefault();
    
        this.state.submitted = true;
        const errors = this.validate();
        this.setState({ errors: errors || {} });

        if (errors) return;
    
        this.doSubmit();
      };
    
      handleChange = ({ currentTarget: input }) => {
        //binding view/model
        const data = { ...this.state.data };
        data[input.name] = input.value;
        this.setState({ data });

        // Early return si l'utilisateur n'a pas encore valider le formulaire
        if(!this.state.submitted) return;

        const errorMessage = this.validateProperty(input);
        const errors = { ...this.state.errors };

        //update the state errors
        if (errorMessage) {
          errors[input.name] = errorMessage;
        } else {
          delete errors[input.name];
        }
        this.setState({ errors });
    
        
      };


}
 
export default MyForm;