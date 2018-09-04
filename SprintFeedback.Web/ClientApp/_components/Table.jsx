import React from "react";
import { Table as TableStrap } from "reactstrap";

const Table = ({ data }) =>
	(
		<TableStrap size="sm" hover responsive>
			<thead>
				<tr>
					{
						data.columns && data.columns.map(col =>
							(
								<th key={col}>{col}</th>
							))
					}
				</tr>
			</thead>
			<tbody>
				{
					data.rows && data.rows.map(row =>
						(
							<tr key={row.id}>
								{
									data.columns.map((col, i) =>
										(
											<td key={`${row.id}_${i}`}>{row[col]}</td>
										))
								}
							</tr>
						))
				}
			</tbody>
		</TableStrap>
	);

export default Table;
