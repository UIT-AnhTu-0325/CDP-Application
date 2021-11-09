//root reducers
import { combineReducers, createStore, applyMiddleware } from 'redux'
import { userReducer } from './UserReducer'
export const rootReducer = combineReducers({
    userReducer
})
