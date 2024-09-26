import React, { Component } from 'react';
import { useSearchParams } from 'react-router-dom';



function ShowPage(){
    const [searchParams, setSearchParams] = useSearchParams();
    console.log(searchParams.get("id"))
    return (<h1>ABCD</h1>);
}

// class ShowPage extends Component {

    
//     state = {  } 

    


//     render() { 
//         console.log(this.props);
//         console.log(this);

//     //    this.getInfo();

        
//     }
// }
 
export default ShowPage;