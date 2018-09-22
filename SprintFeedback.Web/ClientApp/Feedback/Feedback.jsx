import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import {
	Switch,
	Route,
	Link,
} from "react-router-dom";
import { Postits, LoadingGif } from "../_components";
import { listFetchData as fetchFeedback } from "../_ducks/feedback";
import styles from "./Feedback.scss";

class Feedback extends Component
{
	componentDidMount()
	{
		const { getFeedback } = this.props;
		getFeedback("/api/Feedback");
	}

	render()
	{
		const { allFeedback, myFeedback, loading } = this.props;

		return (
			<div className={styles.cards}>
				{loading && <LoadingGif />}
				<Route
					exact
					path="/"
					render={() =>
						(
							!loading && <Postits data={myFeedback} />
						)}
				/>
				<Route
					exact
					path="/All"
					render={() =>
						(
							!loading && <Postits data={allFeedback} />
						)}
				/>
			</div>
		);
	}
}


Feedback.propTypes = {
	feedback: PropTypes.object,
	loading: PropTypes.bool.isRequired,
};

Feedback.defaultProps = {
	feedback: {
		columns: [],
		rows: [],
	},
};

const mapStateToProps = state =>
	({
		feedback: state.feedback.list,
		loading: state.feedback.isLoading,
	});

const mapDispatchToProps = dispatch =>
	({
		getFeedback: url =>
			dispatch(fetchFeedback(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(Feedback);
