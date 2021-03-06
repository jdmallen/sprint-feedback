import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { Router, Route } from "react-router";
import { library } from "@fortawesome/fontawesome-svg-core";
import {
	faEdit,
	faSpinner,
	faUser,
	faTimes,
} from "@fortawesome/free-solid-svg-icons";
import store from "./store";
import App from "./MainApp/MainApp";
import { getBrowserInfo, history } from "./_helpers";
import "./index.scss";
import "../Styles/customBootstrap.scss";

getBrowserInfo();

library.add(faEdit, faSpinner, faUser, faTimes);

// pass initialState to store() once you have it
const reduxStore = store();

const router = (
	<Provider store={reduxStore}>
		<Router history={history}>
			<Route path="/" component={App} />
		</Router>
	</Provider>
);

render(router, document.getElementById("root"));
