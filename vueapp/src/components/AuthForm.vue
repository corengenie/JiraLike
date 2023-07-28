<template>
	<form v-on:submit="auth">
		<div class="form-group">
			<label for="loginInput">Логин:</label>
			<input v-model="loginString" type="login" class="form-control" id="loginInput" placeholder="Введите логин">
		</div>
		<div class="form-group">
			<label for="passwordInput">Пароль</label>
			<input v-model="passwordString" type="password" class="form-control" id="passwordInput" placeholder="Введите пароль">
		</div>
		<button type="submit" class="btn btn-primary">Войти</button>
	</form>
</template>

<script>
import axios from 'axios';
import { defineComponent } from 'vue';
import { mapActions } from 'vuex';

export default defineComponent({
	name: 'auth-form',
	props: ['onLogin'],
	data() {
		return {
			API_URL: '',
			token: '',
			loginString: '',
			passwordString: ''
		};
	},
	methods:{
		...mapActions('auth', ['login']),
		async auth(e) {
			e.preventDefault()
			this.isLoading = true
			await axios({
				method: 'post',
				url: 'api/users',
				headers: { 'Content-Type': 'application/json' },
				data: JSON.stringify({ login : this.loginString, password: this.passwordString })
			})
			.then((response) => {
				this.login({
					username: response.data.username,
					login: response.data.login,
					token: response.data.access_token
				})
			})
			.catch((error) => {
				console.log(error)
				if (error?.response?.status == 400){
					alert("Неправильно введен логин или пароль")
				}
				else {
					alert("Произошла непредвиденная ошибка")
				}
			})
			.finally(() => {
				this.isLoading = false
			})
		}
	}
});
</script>