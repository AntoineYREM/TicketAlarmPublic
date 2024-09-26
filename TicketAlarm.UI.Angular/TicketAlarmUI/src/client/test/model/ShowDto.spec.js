/**
 * TicketAlarm
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */

(function(root, factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD.
    define(['expect.js', process.cwd()+'/src/index'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    factory(require('expect.js'), require(process.cwd()+'/src/index'));
  } else {
    // Browser globals (root is window)
    factory(root.expect, root.TicketAlarm);
  }
}(this, function(expect, TicketAlarm) {
  'use strict';

  var instance;

  beforeEach(function() {
    instance = new TicketAlarm.ShowDto();
  });

  var getProperty = function(object, getter, property) {
    // Use getter method if present; otherwise, get the property directly.
    if (typeof object[getter] === 'function')
      return object[getter]();
    else
      return object[property];
  }

  var setProperty = function(object, setter, property, value) {
    // Use setter method if present; otherwise, set the property directly.
    if (typeof object[setter] === 'function')
      object[setter](value);
    else
      object[property] = value;
  }

  describe('ShowDto', function() {
    it('should create an instance of ShowDto', function() {
      // uncomment below and update the code to test ShowDto
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be.a(TicketAlarm.ShowDto);
    });

    it('should have the property id (base name: "id")', function() {
      // uncomment below and update the code to test the property id
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property idArtist (base name: "idArtist")', function() {
      // uncomment below and update the code to test the property idArtist
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property title (base name: "title")', function() {
      // uncomment below and update the code to test the property title
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property dateTimeShow (base name: "dateTimeShow")', function() {
      // uncomment below and update the code to test the property dateTimeShow
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property idFnac (base name: "idFnac")', function() {
      // uncomment below and update the code to test the property idFnac
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property city (base name: "city")', function() {
      // uncomment below and update the code to test the property city
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property arena (base name: "arena")', function() {
      // uncomment below and update the code to test the property arena
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property url (base name: "url")', function() {
      // uncomment below and update the code to test the property url
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property available (base name: "available")', function() {
      // uncomment below and update the code to test the property available
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

    it('should have the property artist (base name: "artist")', function() {
      // uncomment below and update the code to test the property artist
      //var instance = new TicketAlarm.ShowDto();
      //expect(instance).to.be();
    });

  });

}));
