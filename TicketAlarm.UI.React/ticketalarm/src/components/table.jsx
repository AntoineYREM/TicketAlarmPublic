import React, { Component } from 'react';
import PropTypes from 'prop-types'

const Pagination = (props) => {
    
    return <button onClick={props.onPageChange} className='btn btn-primary'>{ props.test }</button>;
}

Pagination.propTypes = {
   count: PropTypes.number.isRequired
};

Pagination.defaultProps = {
    test: "bonjour"
}
 
export default Pagination;