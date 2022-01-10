import React from "react";
import { Tabs, TabNav, TabNavItem, TabContent, TabPanel } from "react-smarttab";
import "react-smarttab/dist/index.css";
import { Tab1Component } from "../components/Tab1Component";
import { Link } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Table } from "../components/table/Table";

// csc
import "./homepage.css";
import { Table1 } from "../components/table/Table1";
import { Table2 } from "../components/table/Table2";
import { getAllUser } from "../actions/userAction";

/**
 * @author
 * @function UserExplorer
 **/

export const UserExplorer = (props) => {
  const state_user = useSelector((state) => state.user.listUser);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllUser());
  }, []);

  //const state_user = [];
  const users = {
    header: [
      "No",
      "Name",
      "Address",
      "Email",
      "Phone Number",
      "Gender",
      "Dob",
      "Last Activity",
      "Options",
    ],
    body: [],
  };
  const renderHead = (item, ind) => {
    return <th key={ind}>{item}</th>;
  };
  const renderEmployees = (employees) => {
    let myEmployees = [];
    for (let i = 1; i <= employees.length; i++) {
      let emp = employees[i - 1];
      myEmployees.push(
        <tr>
          <td>{i}</td>
          <td>{emp.name}</td>
          <td>{emp.address}</td>
          <td>{emp.email}</td>
          <td>{emp.phoneNumber}</td>
          <td>{emp.gender}</td>
          <td>{emp.dob}</td>
          <td>{emp.lastActivity}</td>
          <td>
            <button className="edit">Sửa</button>
            <button className="delete">Xóa</button>
          </td>
        </tr>
      );
    }
    return myEmployees;
  };

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
          <h1>User Explorer</h1>
          <div className="search-pannel vertical mr-5">
            <div className="input-wrap">
              <input type="text" placeholder="Type to search..." />
            </div>
            <div className="custom-btn ml-2">Search</div>
          </div>
        </div>
      </div>
      <div className="row usertable">
        <div className="col-11">
          <Table
            headData={users.header}
            renderHead={(item, ind) => renderHead(item, ind)}
            render2Body={() =>
              // renderUsers(
              //   searchTerm.length < 1 ? listUser.listAdmin : searchResults
              // ).length > 0
              //   ? renderUsers(
              //       searchTerm.length < 1 ? listUser.listAdmin : searchResults
              //     )
              //   : "Không tìm thấy kết quả"
              renderEmployees(state_user)
            }
          />
        </div>
      </div>{" "}
    </div>
  );
};
