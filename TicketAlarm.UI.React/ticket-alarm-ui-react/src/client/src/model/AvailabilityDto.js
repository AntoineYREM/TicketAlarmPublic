/**
 * TicketAlarm.API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */

import ApiClient from '../ApiClient';

/**
 * The AvailabilityDto model module.
 * @module model/AvailabilityDto
 * @version 1.0
 */
class AvailabilityDto {
    /**
     * Constructs a new <code>AvailabilityDto</code>.
     * @alias module:model/AvailabilityDto
     */
    constructor() { 
        
        AvailabilityDto.initialize(this);
    }

    /**
     * Initializes the fields of this object.
     * This method is used by the constructors of any subclasses, in order to implement multiple inheritance (mix-ins).
     * Only for internal use.
     */
    static initialize(obj) { 
    }

    /**
     * Constructs a <code>AvailabilityDto</code> from a plain JavaScript object, optionally creating a new instance.
     * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @param {module:model/AvailabilityDto} obj Optional instance to populate.
     * @return {module:model/AvailabilityDto} The populated <code>AvailabilityDto</code> instance.
     */
    static constructFromObject(data, obj) {
        if (data) {
            obj = obj || new AvailabilityDto();

            if (data.hasOwnProperty('idShow')) {
                obj['idShow'] = ApiClient.convertToType(data['idShow'], 'Number');
            }
        }
        return obj;
    }

    /**
     * Validates the JSON data with respect to <code>AvailabilityDto</code>.
     * @param {Object} data The plain JavaScript object bearing properties of interest.
     * @return {boolean} to indicate whether the JSON data is valid with respect to <code>AvailabilityDto</code>.
     */
    static validateJSON(data) {

        return true;
    }


}



/**
 * @member {Number} idShow
 */
AvailabilityDto.prototype['idShow'] = undefined;






export default AvailabilityDto;

