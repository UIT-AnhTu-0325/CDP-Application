/* eslint-disable import/no-anonymous-default-export */
import {
  USER_FAIL,
  USER_REQUEST,
  USER_SUCCESS,
} from "../constants/userConstant";
const initState = {
  listUser: [],
  loading: false,
  error: null,
};
export default (state = initState, action) => {
  switch (action.type) {
    case USER_SUCCESS:
      state = {
        ...state,
        listUser: action.payload,
      };
      break;
    default:
  }
  return state;
};
