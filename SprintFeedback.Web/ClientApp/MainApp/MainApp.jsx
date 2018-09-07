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
import Feedback from "../Feedback/Feedback";
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
				<Navbar className={styles.navbar} dark expand="md">
					<NavbarBrand tag={Link} to="/">Sprint Feedback</NavbarBrand>
					<NavbarToggler onClick={() =>
						this.toggleNavbar()}
					/>
					<Collapse isOpen={isNavbarOpen} navbar>
						<Nav navbar horizontal="start" className="mr-auto">
							<NavItem>
								<NavLink tag={Link} to="/">Mine</NavLink>
							</NavItem>
							<NavItem>
								<NavLink tag={Link} to="/All">All</NavLink>
							</NavItem>
						</Nav>
						<Nav navbar horizontal="end" className="ml-auto">
							<NavItem>
								<div className="navbar-text text-light">Hello, User</div>
							</NavItem>
						</Nav>
					</Collapse>
				</Navbar>
				<Container>
					<Switch>
						<Route exact path="/" component={Feedback} />
						<Route exact path="/All" component={Feedback} />
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
