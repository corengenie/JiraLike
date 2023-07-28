const state = {
	userToken: localStorage.getItem('token') || '',
	username: null,
	userLogin: null,
	isAuthorized: localStorage.getItem('token') != null
}

const mutations = {
	setUsername (state, username) {
		state.username = username
	},
	setUserToken (state, userToken) {
		state.userToken = userToken
	},
	setUserLogin (state, userLogin) {
		state.userLogin = userLogin
	},
	setIsAuthorized (state, isAuthorized) {
		state.isAuthorized = isAuthorized
	}
}

const actions = {
	login({ commit }, user) {
		commit('setUsername', user.username)
		commit('setUserLogin', user.login)
		commit('setUserToken', user.token)
        localStorage.setItem('username', user.username)
        localStorage.setItem('login', user.login)
        localStorage.setItem('token', user.token)
		commit('setIsAuthorized', true)
	},
	logout({ commit }) {
		commit('setUsername', null)
		commit('setUserLogin', null)
		commit('setUserToken', null)
        localStorage.removeItem('username')
        localStorage.removeItem('login')
        localStorage.removeItem('token')
		commit('setIsAuthorized', false)
	}
}

export default {
	namespaced: true,
	state,
	mutations,
	actions
}