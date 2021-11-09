import React from 'react'
import { View, Text, StyleSheet, TouchableOpacity } from 'react-native'
import { connect } from 'react-redux'

import { onFetchInfor, onUserLogin } from '../redux'
const _LoginScreen = (props) => {

    const { userReducer, onUserLogin, onFetchInfor } = props

    const { user, infors } = userReducer

    console.log(user, infors)

    return (
        <View style={styles.container}>
            <Text>Hello World</Text>
            <TouchableOpacity
                style={{
                    height: 50,
                    width: 220,
                    marginTop: 10,
                    backgroundColor: '#FF5733',
                    borderRadius: 30,
                    justifyContent: 'center',
                    alignItems: 'center'
                }}
                onPress={() => {
                    onUserLogin({ email: 'dat2@gmail.com', password: '123456' })
                }}>
                <Text style={{ color: '#FFF', fontSize: 18 }}>User Login</Text>
            </TouchableOpacity>

            {user !== undefined && <Text style={{ marginTop: 20 }}>{user.user.firstName}</Text>}
            <TouchableOpacity
                style={{
                    height: 50,
                    width: 220,
                    marginTop: 10,
                    backgroundColor: '#FF5733',
                    borderRadius: 30,
                    justifyContent: 'center',
                    alignItems: 'center'
                }}
                onPress={() => {
                    onFetchInfor()
                }}>
                <Text style={{ color: '#FFF', fontSize: 18 }}>Fecth Infors</Text>
            </TouchableOpacity>
            {infors !== undefined && <Text style={{ marginLeft: 20, marginRight: 20, marginTop: 20, fontSize: 16 }}>{JSON.stringify(infors)}</Text>}

        </View >
    )
}
const styles = StyleSheet.create({
    container: {
        flex: 1, justifyContent: 'center', alignItems: 'center'
    }
})

const mapStateToProps = (state) => ({
    userReducer: state.userReducer
})

const LoginScreen = connect(mapStateToProps, { onUserLogin, onFetchInfor })(_LoginScreen)
export { LoginScreen }