import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Table, LoadingGif } from "../_components";
import { listFetchData } from "../_ducks/myFeedback";

class MyFeedback extends Component
{
	componentDidMount()
	{
		const { fetchData } = this.props;
		fetchData("https://5b8eff6feb676700148a4ca4.mockapi.io/MyFeedback");
	}

	render()
	{
		const { list, loading } = this.props;

		return (
			<div>
				{loading && <LoadingGif />}
				{!loading && <Table data={list} />}
			</div>
		);
	}
}


MyFeedback.propTypes = {
	list: PropTypes.object,
	loading: PropTypes.bool.isRequired,
};

MyFeedback.defaultProps = {
	list: {
		columns: [],
		rows: [],
	},
};

const mapStateToProps = state =>
	({
		list: state.myFeedback.list,
		loading: state.myFeedback.isLoading,
	});

const mapDispatchToProps = dispatch =>
	({
		fetchData: url =>
			dispatch(listFetchData(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(MyFeedback);
