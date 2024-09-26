import React, { Component } from "react";
import { useSearchParams } from "react-router-dom";
import { useParams } from "react-router-dom";
import Alarm from "./alarm";

function AlarmPage() {
  let [searchParams, setSearchParams] = useSearchParams();
  let { id } = useParams();

  return (
    <div className="m-3">
      {" "}
      <Alarm id={id}></Alarm>
    </div>
  );
}

export default AlarmPage;
