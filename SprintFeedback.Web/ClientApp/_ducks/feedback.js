﻿import axios from "axios";

// Actions
const ERRORED = "sprint-feedback/feedback/HAS_ERRORED";
const LOADING = "sprint-feedback/feedback/IS_LOADING";
const FETCH_DATA_SUCCESS = "sprint-feedback/feedback/FETCH_DATA_SUCCESS";

// Reducer
export default (
	state = {
		hasErrored: false,
		isLoading: false,
		list: {},
	},
	action
) =>
{
	switch (action.type)
	{
	case ERRORED:
		return {
			...state,
			hasErrored: action.payload,
		};

	case LOADING:
		return {
			...state,
			isLoading: action.payload,
		};

	case FETCH_DATA_SUCCESS:
		return {
			...state,
			list: action.payload,
		};

	default:
		return state;
	}
};

// Action Creators

export function listHasErrored(boolValue)
{
	return {
		type: ERRORED,
		payload: boolValue,
	};
}

export function listIsLoading(boolValue)
{
	return {
		type: LOADING,
		payload: boolValue,
	};
}

export function listFetchDataSuccess(list)
{
	return {
		type: FETCH_DATA_SUCCESS,
		payload: list,
	};
}

export function listFetchData(url, data)
{
	return (dispatch) =>
	{
		dispatch(listIsLoading(true));

		axios
			.get(url,
				{
					params: data,
				})
			.then((response) =>
			{
				dispatch(listIsLoading(false));
				return response;
			})
			.then(response =>
				dispatch(listFetchDataSuccess(response.data)))
			.catch(() =>
				dispatch(listHasErrored(true)))
			.finally(() =>
				dispatch(listIsLoading(false)));
	};
}
