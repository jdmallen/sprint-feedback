import React, { Component } from "react";
import { connect } from "react-redux";
import {
	Switch,
	Route,
	Link,
} from "react-router-dom";
import PropTypes from "prop-types";
import {
	Collapse,
	Container,
	Navbar,
	NavbarToggler,
	NavbarBrand,
	Nav,
	NavItem,
	NavLink,
} from "reactstrap";
import { toggleNav as toggleNavDuck } from "../_ducks/ui";
import { Footer } from "../_components";
import MyFeedback from "../MyFeedback/MyFeedback";
import styles from "./MainApp.scss";

class App extends Component
{
	componentDidMount()	{}

	toggleNavbar()
	{
		const { isNavbarOpen, toggleNav } = this.props;
		toggleNav(!isNavbarOpen);
	}

	render()
	{
		const { isNavbarOpen } = this.props;
		return (
			<div className={styles.app}>
				<Navbar color="primary" dark expand="md">
					<NavbarBrand tag={Link} to="/">Sprint Feedback</NavbarBrand>
					<NavbarToggler onClick={() =>
						this.toggleNavbar()}
					/>
					<Collapse isOpen={isNavbarOpen} navbar>
						<Nav className="ml-auto" navbar>
							<NavItem>
								<NavLink>Hello, User</NavLink>
							</NavItem>
						</Nav>
					</Collapse>
				</Navbar>
				<Container>
					<Switch>
						<Route exact path="/" component={MyFeedback} />
					</Switch>
				</Container>
				<Footer />
			</div>
		);
	}
}

App.propTypes = {
	isNavbarOpen: PropTypes.bool,
	toggleNav: PropTypes.func.isRequired,
};

App.defaultProps = {
	isNavbarOpen: false,
};

const mapStateToProps = state =>
	({
		isNavbarOpen: state.ui.isNavbarOpen,
	});

const mapDispatchToProps = dispatch =>
	({
		toggleNav: isNavbarOpen =>
			dispatch(toggleNavDuck(isNavbarOpen)),
	});

export default connect(mapStateToProps, mapDispatchToProps)(App);
