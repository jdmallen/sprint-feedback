import React from "react";
import { Table as TableStrap } from "reactstrap";

const Table = ({ data }) =>
	(
		<TableStrap>
			<thead>
				<tr>
					{
						data.columns && data.columns.map(col =>
							(
								<th>{col}</th>
							))
					}
				</tr>
			</thead>
			<tbody>
				{
					data.rows && data.rows.map(row =>
						(
							<tr>
								{
									data.columns.map(col =>
										(
											<td>{row[col]}</td>
										))
								}
							</tr>
						))
				}
			</tbody>
		</TableStrap>
	);

export default Table;
