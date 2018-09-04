import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Table } from "../_components";
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
		const { list } = this.props;
		return (
			<Table data={list} />
		);
	}
}


AllFeedback.propTypes = {
	list: PropTypes.object,
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
	});

const mapDispatchToProps = dispatch =>
	({
		fetchData: url =>
			dispatch(listFetchData(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(AllFeedback);
