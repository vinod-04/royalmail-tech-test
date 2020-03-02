import { FETCH_PEOPLE_LOADING, FETCH_PEOPLE_SUCCESS, FETCH_PEOPLE_ERROR } from '../components/people/people-actions';

const initialState = {
    data: [],
    loading: false,
    error: null
};

export default function peopleReducer(state = initialState, action) {
    switch (action.type) {
        case FETCH_PEOPLE_LOADING:
            return {
                ...state,
                loading: true,
                error: null
            };
        case FETCH_PEOPLE_SUCCESS:
            return {
                ...state,
                loading: false,
                data: action.payload
            };
        case FETCH_PEOPLE_ERROR:
            return {
                ...state,
                loading: false,
                error: action.payload,
                data: []
            };
        default: {
            return state;
        }
    }
}
