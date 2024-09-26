import React, { Component } from 'react';

class Counter extends Component {
    state = {
        count : 1,
        imgUrl : "https://picsum.photos/200",
        tags: ['tag1', 'tag2', 'tag3']
    };

    styles = {
        fontSize : 150,
        fontWeight: "bold"
    };

    constructor(){
        super();
        this.handleIncrement = this.handleIncrement.bind(this);
    }

    renderTags(){
        if(this.state.tags.length === 0) return <p>No tag</p>
        return this.state.tags.map(tag => <li key={tag}>{tag}</li>);
    };

    handleIncrement(){
        this.setState({
            count: this.state.count +1
        });
        console.log("BOnjour", this.state.count);
    }

    render() { 
        return <React.Fragment>
            <img src={this.state.imgUrl}></img>
            <span style={this.styles} className={this.getBadgeClasses()}> {this.formatCount()}</span>
            <button onClick={this.handleIncrement} class="btn btn-primary btm-sm">Button</button>
            <ul>
                { this.renderTags() }
            </ul>
        </React.Fragment>;
        
    }

    getBadgeClasses() {
        let classes = "btn m-2 btn-";
        classes += (this.state.count === 0) ? "warning" : "primary";
        return classes;
    }

    formatCount(){
        const { count } = this.state;
        return count == 0 ? "Zéro" : count;
    }
}
 
export default Counter;