import PeopleApi from '../people/people-api';
import filter from 'lodash/filter';

export const FETCH_PEOPLE_LOADING = 'FETCH_PEOPLE_LOADING';
export const FETCH_PEOPLE_SUCCESS = 'FETCH_PEOPLE_SUCCESS';
export const FETCH_PEOPLE_ERROR = 'FETCH_PEOPLE_ERROR';

export const FETCH_PERSONDETAILS_LOADING = 'FETCH_PERSONDETAILS_LOADING';
export const FETCH_PERSONDETAILS_SUCCESS = 'FETCH_PERSONDETAILS_SUCCESS';
export const FETCH_PERSONDETAILS_ERROR = 'FETCH_PERSONDETAILS_ERROR';

export const loadPeople = () => dispatch => {
    dispatch({ type: FETCH_PEOPLE_LOADING });

    PeopleApi.getPeople()
        .then(res => res.json())
        .then((res) => {
                dispatch({
                    type: FETCH_PEOPLE_SUCCESS,
                    payload: res
                })
        }).catch((err) => {
            console.log(err)

            if (err.message === "Unexpected token P in JSON at position 0") {
                window.location.href = "/api-offline";
            }

            dispatch({
                type: FETCH_PEOPLE_ERROR,
                payload: err
            })
        })
};

export const fetchPersonDetails = (id, state) => dispatch => {
    dispatch({ type: FETCH_PERSONDETAILS_LOADING });

    PeopleApi.getPersonDetails(id)
        .then(res => res.json())
        .then((res) => {
            setStateForPersonSkills(res, state);
            dispatch({  
                type: FETCH_PERSONDETAILS_SUCCESS,
                payload: res
            })
        }).catch((err) => {
            console.log(err)
            dispatch({
                type: FETCH_PERSONDETAILS_ERROR,
                payload: err
            })
        })
};

function setStateForPersonSkills(data, state) {
    state.personId = data.personId;
    state.isAdmin = data.isAdmin;
    state.isEnabled = data.isEnabled;
    state.formLoaded = true;
    state.loading = false;

    state.csharp = filter(data.personSkills, ['skillId', 1]).length > 0;
    state.javascript = filter(data.personSkills, ['skillId', 2]).length > 0;
    state.java = filter(data.personSkills, ['skillId', 3]).length > 0;
}