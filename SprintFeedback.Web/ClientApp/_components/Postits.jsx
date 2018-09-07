import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import moment from "moment";
import React from "react";
import {
	Button,
	ButtonGroup,
	Card,
	CardBody,
	CardColumns,
	CardFooter,
	CardHeader,
	CardText,
} from "reactstrap";
import cn from "classnames";
import styles from "./Postits.scss";

const Postits = ({ data }) =>
	(
		<CardColumns>
			{
				data && data.rows && data.rows.map(row =>
					(
						<Card
							inverse
							className={row.isPositive
								? styles.positive
								: styles.negative}
						>
							<CardHeader>
								{row.dateCreated && moment(row.dateCreated).format("ddd, MMM Do")}
								<ButtonGroup className="float-sm-right" size="sm">
									<Button
										color="link"
										size="xs"
										className={styles.headerButton}
									>
										<FontAwesomeIcon icon="edit" />
									</Button>
									<Button
										color="link"
										size="xs"
										className={styles.headerButton}
									>
										<FontAwesomeIcon icon="times" />
									</Button>
								</ButtonGroup>
							</CardHeader>
							<CardBody>
								<CardText>{row.comment}</CardText>
							</CardBody>
							<CardFooter>
								{row.displayName}
							</CardFooter>
						</Card>
					))
			}
		</CardColumns>
	);

export default Postits;
