import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import {
	Switch,
	Route,
	Link,
} from "react-router-dom";
import { Postits, LoadingGif } from "../_components";
import { listFetchData as fetchAllFeedback } from "../_ducks/allFeedback";
import { listFetchData as fetchMyFeedback } from "../_ducks/myFeedback";
import styles from "./Feedback.scss";

class Feedback extends Component
{
	componentDidMount()
	{
		const { getAllFeedback, getMyFeedback } = this.props;
		getAllFeedback("https://5b8eff6feb676700148a4ca4.mockapi.io/AllFeedback");
		getMyFeedback("https://5b8eff6feb676700148a4ca4.mockapi.io/MyFeedback");
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
	myFeedback: PropTypes.object,
	allFeedback: PropTypes.object,
	loading: PropTypes.bool.isRequired,
};

Feedback.defaultProps = {
	allFeedback: {
		columns: [],
		rows: [],
	},
	myFeedback: {
		columns: [],
		rows: [],
	},
};

const mapStateToProps = state =>
	({
		allFeedback: state.allFeedback.list,
		myFeedback: state.myFeedback.list,
		loading: state.myFeedback.isLoading,
	});

const mapDispatchToProps = dispatch =>
	({
		getAllFeedback: url =>
			dispatch(fetchAllFeedback(url)),
		getMyFeedback: url =>
			dispatch(fetchMyFeedback(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(Feedback);
