//reducers

export const userReducer = (state = {}, action) => {
    switch (action.type) {
        case 'DO_LOGIN':
            return {
                ...state,
                user: action.payload
            }
        case 'FECTH_INFOR':
            return {
                ...state,
                infors: action.payload
            }
        case 'FECTH_INFOR':
            return {
                ...state,
                appError: action.payload
            }
        default:
            return state
    }
}