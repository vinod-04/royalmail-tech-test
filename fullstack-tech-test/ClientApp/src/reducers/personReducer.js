import { FETCH_PERSONDETAILS_LOADING, FETCH_PERSONDETAILS_SUCCESS, FETCH_PERSONDETAILS_ERROR } from '../components/people/people-actions';

const initialState = {
    data: {},
    loading: false,
    error: null
};

export default function peopleReducer(state = initialState, action) {
    switch (action.type) {
        case FETCH_PERSONDETAILS_LOADING:
            return {
                ...state,
                loading: true,
                error: null
            };
        case FETCH_PERSONDETAILS_SUCCESS:
            return {
                ...state,
                loading: false,
                data: action.payload
            };
        case FETCH_PERSONDETAILS_ERROR:
            return {
                ...state,
                loading: false,
                error: action.payload,
                data: {}
            };
        default: {
            return state;
        }
    }
}
