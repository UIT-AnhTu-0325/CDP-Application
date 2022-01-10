import React from "react";
import { Tabs, TabNav, TabNavItem, TabContent, TabPanel } from "react-smarttab";
import "react-smarttab/dist/index.css";
import { Tab1Component } from "../components/Tab1Component";
import { Link } from "react-router-dom";

// csc
import "./homepage.css";
import { Table1 } from "../components/table/Table1";
import { Table2 } from "../components/table/Table2";
import { IdentityTab } from "../components/identity/IdentityTab";
/**
 * @author
 * @function DetailUser
 **/

export const DetailUser = (props) => {
  return (
    <div>
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#">
          User Analysic
        </a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <Link to="/" class="nav-link">
                Home <span class="sr-only">(current)</span>
              </Link>
            </li>
            <li class="nav-item">
              <Link class="nav-link" to="/user">
                User Explorer
              </Link>
            </li>
          </ul>
          <form class="form-inline my-2 my-lg-0">
            <input
              class="form-control mr-sm-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">
              Search
            </button>
          </form>
        </div>
      </nav>
      <div className="row user">
        <div className="topbar">
          <div className="user-name-avatar vertical">
            <Link className="back-btn-link" to="/user">
              <i class="back-btn fas fa-arrow-left"></i>
            </Link>
            <img
              src="https://robohash.org/idrerumquasi.png?size=50x50&set=set1"
              alt=""
            />
            <h2 className="name-user-detail">Iron Man </h2>
          </div>
          <div className="search-pannel vertical mr-5">
            ironman.5ting@gmail.com
          </div>
        </div>
      </div>
      <div className="tab tab-detail-user">
        <Tabs selected="4">
          <TabNav>
            <TabNavItem>Trails</TabNavItem>
            <TabNavItem>Audiences</TabNavItem>
            <TabNavItem>Journeys</TabNavItem>
            <TabNavItem>Events</TabNavItem>
            <TabNavItem>Identities</TabNavItem>
          </TabNav>

          <TabContent>
            <TabPanel></TabPanel>
            <TabPanel></TabPanel>
            <TabPanel></TabPanel>
            <TabPanel></TabPanel>
            <TabPanel>
              {" "}
              <IdentityTab />
            </TabPanel>
          </TabContent>
        </Tabs>
      </div>
    </div>
  );
};
