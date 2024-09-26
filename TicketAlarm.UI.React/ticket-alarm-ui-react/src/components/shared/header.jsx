import React, { Component } from "react";

class Header extends Component {
  state = {};
  render() {
    return (
      <nav class="navbar navbar-dark bg-header">
        <span className="m-2">
          <a class="navbar-brand text-header" href="/">
            Ticket Alarm ⏰
          </a>{" "}
        </span>
      </nav>
    );
  }
}

export default Header;
