import { Link } from "react-router-dom";
export const COLUMN = [
  {
    Header: "NAME",
    accessor: "avatar",
    Cell: (tableProps) => (
      <img src={tableProps.row.original.avatar} width={60} alt="Player" />
    ),
  },
  {
    Header: "",
    accessor: "username",
  },
  {
    Header: "EMAIL",
    accessor: "email",
  },
  {
    Header: "FIRST ACTIVITY",
    accessor: "firstactivity",
  },
  {
    Header: "LAST ACTIVITY",
    accessor: "lastactivity",
  },
  {
    Header: "Detail",
    accessor: "",
    Cell: (tableProps) => (
      <Link className="reset-link" to="/detailuser">
        <i class="detail-user-btn fas fa-info"></i>
      </Link>
    ),
  },
];
