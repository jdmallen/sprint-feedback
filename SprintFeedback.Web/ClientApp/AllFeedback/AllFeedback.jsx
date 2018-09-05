import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Table, LoadingGif } from "../_components";
import { listFetchData } from "../_ducks/allFeedback";

class AllFeedback extends Component
{
	componentDidMount()
	{
		const { fetchData } = this.props;
		fetchData("https://5b8eff6feb676700148a4ca4.mockapi.io/AllFeedback");
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

AllFeedback.propTypes = {
	list: PropTypes.object,
	loading: PropTypes.bool.isRequired,
};

AllFeedback.defaultProps = {
	list: {
		columns: [],
		rows: [],
	},
};

const mapStateToProps = state =>
	({
		list: state.allFeedback.list,
		loading: state.allFeedback.isLoading,
	});

const mapDispatchToProps = dispatch =>
	({
		fetchData: url =>
			dispatch(listFetchData(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(AllFeedback);
