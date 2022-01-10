import React from "react";
import { Tabs, TabNav, TabNavItem, TabContent, TabPanel } from "react-smarttab";
import "react-smarttab/dist/index.css";
import { Tab1Component } from "../components/Tab1Component";
import { Link } from "react-router-dom";
// csc
import "./homepage.css";
/**
 * @author
 * @function HomePage
 **/

export const HomePage = (props) => {
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
              <Link to="/" class="nav-link" href="#">
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
      <div className="row top-nav">
        <div className="break-crumb">Sources / Web (EComerce Websites)</div>

        <div className="list-func">
          <div className="func-btn search">
            <i class="fas fa-search"></i>
          </div>
          <div className="func-btn message">
            <i class="far fa-comments"></i>
          </div>
          <div className="func-btn bell">
            <i class="fas fa-bell"></i>
          </div>
          <div className="func-btn user">
            <i class="fas fa-user"></i>
          </div>
        </div>
      </div>
      <div className="row tab">
        <Tabs selected="0">
          <TabNav>
            <TabNavItem>Overview</TabNavItem>
            <TabNavItem>Debugger</TabNavItem>
            <TabNavItem>Schema</TabNavItem>
            <TabNavItem>Setting</TabNavItem>
          </TabNav>

          <TabContent>
            <TabPanel>
              <Tab1Component />
            </TabPanel>
            <TabPanel></TabPanel>
            <TabPanel></TabPanel>
            <TabPanel></TabPanel>
          </TabContent>
        </Tabs>
      </div>
    </div>
  );
};
