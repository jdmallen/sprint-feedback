import React, { Component } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Table } from "../_components";
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
		const { list } = this.props;
		return (
			<Table data={list} />
		);
	}
}


MyFeedback.propTypes = {
	list: PropTypes.object,
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
	});

const mapDispatchToProps = dispatch =>
	({
		fetchData: url =>
			dispatch(listFetchData(url)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(MyFeedback);
