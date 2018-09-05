import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";
import styles from "./LoadingGif.scss";

const LoadingGif = () =>
	(
		<div className={styles.loading}>
			<FontAwesomeIcon icon="spinner" size="3x" spin />
		</div>
	);

export default LoadingGif;
