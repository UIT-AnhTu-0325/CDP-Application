import React, { useMemo } from "react";
import { useTable } from "react-table";
import Data1 from "../../asset/JsonData/data1.json";
import { COLUMN } from "../../asset/JsonData/Column1";

import "./table1.css";
/**
 * @author
 * @function Table1
 **/

export const Table1 = (props) => {
  const columns = useMemo(() => COLUMN, []);
  const data = useMemo(() => Data1, []);
  const tableInstance = useTable({
    columns,
    data,
  });
  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } =
    tableInstance;
  return (
    <div>
      <table {...getTableProps()}>
        {/* <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps()}>{column.render("Header")}</th>
              ))}
            </tr>
          ))}
        </thead> */}
        <tbody {...getTableBodyProps()}>
          {rows.map((row) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => {
                  return (
                    <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                  );
                })}
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};
