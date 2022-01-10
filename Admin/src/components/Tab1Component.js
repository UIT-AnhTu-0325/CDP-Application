import React from "react";
import "./tab1component.css";
import { Table1 } from "./table/Table1";
import JSONPretty from "react-json-pretty";
const JSONPrettyMon = require("react-json-pretty/dist/monikai");
/**
 * @author
 * @function Tab1Component
 **/

export const Tab1Component = (props) => {
  var data = {
    glossary: {
      title: "example glossary",

      GlossEntry: {
        ID: "SGML",
        SortAs: "SGML",
        GlossTerm: "Standard Generalized Markup Language",
        Acronym: "SGML",
        Abbrev: "ISO 8879:1986",
        GlossDef: {
          para: "A meta-markup language, used to create",
          GlossSeeAlso: ["GML", "XML"],
        },
        GlossSee: "markup",
      },
    },
  };
  return (
    <div>
      <div class="row debugger">
        <div className="col-6 left-bar">
          <input type="radio" name="hong" id="hong" />{" "}
          <input type="radio" name="hong" id="hong2" className="pause" />
          <div className="input-wrap">
            <i class="fas fa-search"></i>
            <input type="text" placeholder="Type to search..." />
          </div>
          <div className="custom-btn">Advanced</div>
        </div>
        <div className="col-6 vertical right-bar">
          <i class="far fa-check-circle"></i>
          <div className="product-add">
            <span>Product Added</span>
            <span className="allow">Allowed</span>
          </div>
          <div className="two-func vertical">
            <div className="custom-btn">View in Schema</div>
            <div className="custom-btn">Validate...</div>
          </div>
        </div>
      </div>

      <div className="row table">
        <div className="col-6 left-table">
          <Table1 />
        </div>
        <div className="col-6 right-table">
          <div className="top-select vertical">
            <div className="item select">Pretty</div>
            <div className="item">Raw</div>
            <div className="item">Violations</div>
          </div>

          <div className="content">
            <div>
              <pre>{JSON.stringify(data, null, 2)}</pre>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
