import { combineReducers } from "redux";
import { default as peopleData } from '../reducers/peopleReducer';
import { default as personData } from '../reducers/personReducer';

const reducers = combineReducers({
    peopleData,
    personData
});

export default reducers;
