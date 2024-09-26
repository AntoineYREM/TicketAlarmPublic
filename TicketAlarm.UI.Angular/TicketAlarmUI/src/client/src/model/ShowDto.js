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

import ApiClient from '../ApiClient';
import BaseArtistDto from './BaseArtistDto';

/**
 * The ShowDto model module.
 * @module model/ShowDto
 * @version v1
 */
class ShowDto {
    /**
     * Constructs a new <code>ShowDto</code>.
     * @alias module:model/ShowDto
     */
    constructor() { 
        
        ShowDto.initialize(this);
    }

    /**
     * Initializes the fields of this object.
     * This method is used by the constructors of any subclasses, in order to implement multiple inheritance (mix-ins).
     * Only for internal use.
     */
    static initialize(obj) { 
    }

    /**
     * Constructs a <code>ShowDto</code> from a plain JavaScript object, optionally creating a new instance.
     * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @param {module:model/ShowDto} obj Optional instance to populate.
     * @return {module:model/ShowDto} The populated <code>ShowDto</code> instance.
     */
    static constructFromObject(data, obj) {
        if (data) {
            obj = obj || new ShowDto();

            if (data.hasOwnProperty('id')) {
                obj['id'] = ApiClient.convertToType(data['id'], 'Number');
            }
            if (data.hasOwnProperty('idArtist')) {
                obj['idArtist'] = ApiClient.convertToType(data['idArtist'], 'Number');
            }
            if (data.hasOwnProperty('title')) {
                obj['title'] = ApiClient.convertToType(data['title'], 'String');
            }
            if (data.hasOwnProperty('dateTimeShow')) {
                obj['dateTimeShow'] = ApiClient.convertToType(data['dateTimeShow'], 'Date');
            }
            if (data.hasOwnProperty('idFnac')) {
                obj['idFnac'] = ApiClient.convertToType(data['idFnac'], 'Number');
            }
            if (data.hasOwnProperty('city')) {
                obj['city'] = ApiClient.convertToType(data['city'], 'String');
            }
            if (data.hasOwnProperty('arena')) {
                obj['arena'] = ApiClient.convertToType(data['arena'], 'String');
            }
            if (data.hasOwnProperty('url')) {
                obj['url'] = ApiClient.convertToType(data['url'], 'String');
            }
            if (data.hasOwnProperty('available')) {
                obj['available'] = ApiClient.convertToType(data['available'], 'Boolean');
            }
            if (data.hasOwnProperty('artist')) {
                obj['artist'] = BaseArtistDto.constructFromObject(data['artist']);
            }
        }
        return obj;
    }

    /**
     * Validates the JSON data with respect to <code>ShowDto</code>.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @return {boolean} to indicate whether the JSON data is valid with respect to <code>ShowDto</code>.
     */
    static validateJSON(data) {
        // ensure the json data is a string
        if (data['title'] && !(typeof data['title'] === 'string' || data['title'] instanceof String)) {
            throw new Error("Expected the field `title` to be a primitive type in the JSON string but got " + data['title']);
        }
        // ensure the json data is a string
        if (data['city'] && !(typeof data['city'] === 'string' || data['city'] instanceof String)) {
            throw new Error("Expected the field `city` to be a primitive type in the JSON string but got " + data['city']);
        }
        // ensure the json data is a string
        if (data['arena'] && !(typeof data['arena'] === 'string' || data['arena'] instanceof String)) {
            throw new Error("Expected the field `arena` to be a primitive type in the JSON string but got " + data['arena']);
        }
        // ensure the json data is a string
        if (data['url'] && !(typeof data['url'] === 'string' || data['url'] instanceof String)) {
            throw new Error("Expected the field `url` to be a primitive type in the JSON string but got " + data['url']);
        }
        // validate the optional field `artist`
        if (data['artist']) { // data not null
          BaseArtistDto.validateJSON(data['artist']);
        }

        return true;
    }


}



/**
 * @member {Number} id
 */
ShowDto.prototype['id'] = undefined;

/**
 * @member {Number} idArtist
 */
ShowDto.prototype['idArtist'] = undefined;

/**
 * @member {String} title
 */
ShowDto.prototype['title'] = undefined;

/**
 * @member {Date} dateTimeShow
 */
ShowDto.prototype['dateTimeShow'] = undefined;

/**
 * @member {Number} idFnac
 */
ShowDto.prototype['idFnac'] = undefined;

/**
 * @member {String} city
 */
ShowDto.prototype['city'] = undefined;

/**
 * @member {String} arena
 */
ShowDto.prototype['arena'] = undefined;

/**
 * @member {String} url
 */
ShowDto.prototype['url'] = undefined;

/**
 * @member {Boolean} available
 */
ShowDto.prototype['available'] = undefined;

/**
 * @member {module:model/BaseArtistDto} artist
 */
ShowDto.prototype['artist'] = undefined;






export default ShowDto;

