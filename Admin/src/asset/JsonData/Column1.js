export const COLUMN = [
  {
    Header: "ID",
    accessor: "month",
    Cell: (tableProps) => {
      return <i class="green-color far fa-check-circle"></i>;
    },
  },
  {
    Header: "ID",
    accessor: "title",
  },
  {
    Header: "ID",
    accessor: "content",
  },
  {
    Header: "Date",
    accessor: "date",
    Cell: (tableProps) => {
      var localDate = new Date(tableProps.row.original.date.toString());

      localDate = localDate.toLocaleDateString("en-US");
      var initial = localDate.split(/\//);
      if (initial[1] && initial[0]) {
        if (initial[1].length === 1) initial[1] = "0" + initial[1];
        if (initial[0].length === 1) initial[0] = "0" + initial[0];
      }
      return [initial[1], initial[0], initial[2]].join("-");
    },
  },
];
