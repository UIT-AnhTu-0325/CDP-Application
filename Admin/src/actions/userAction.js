import axios from "../helpers/axios";
import {
  USER_FAIL,
  USER_REQUEST,
  USER_SUCCESS,
} from "../constants/userConstant";

export const getAllUser = () => {
  return async (dispatch) => {
    dispatch({ type: USER_REQUEST });
    const res = await axios.get(`Profile`);
    dispatch({ type: USER_SUCCESS, payload: res.data });
  };
};
