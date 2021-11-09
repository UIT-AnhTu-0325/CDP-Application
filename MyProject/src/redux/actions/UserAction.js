//actions

import thunk from 'redux-thunk'
import axios from "axios"

export const onUserLogin = ({ email, password }) => {
    return async (dispatch) => {
        try {
            const response = await axios.post('http://10.0.2.2:2000/api/admin/signin', {
                email, password
            })
            dispatch({ type: 'DO_LOGIN', payload: response.data })

        } catch (error) {
            console.log(error)
            dispatch({ type: 'ON_ERROR', payload: error })
        }
    }
}

export const onFetchInfor = () => {
    return async (dispatch) => {
        try {
            const response = {
                data: [
                    { name: 'Anh Tu', age: '18' },
                    { name: 'lam Hong', age: '17' },
                    { name: 'Ngoc Phuc', age: '16' },
                    { name: 'Tan Hoai', age: '15' },
                ]
            }
            dispatch({ type: 'FECTH_INFOR', payload: response.data })

        } catch (error) {
            dispatch({ type: 'ON_ERROR', payload: error })
        }
    }
}