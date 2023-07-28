<template>
	<div class="w-100 d-flex align-items-center justify-content-center container">
		<div class="form-wrapper">
			<form v-on:submit="auth">
				<h3>Войти</h3>
				<div class="form-group login-group">
					<!-- <label for="loginInput">Логин:</label> -->
					<input v-model="loginString" type="login" class="form-control" id="loginInput" placeholder="Введите логин">
				</div>
				<div class="form-group password-group">
					<!-- <label for="passwordInput">Пароль:</label> -->
					<input v-model="passwordString" type="password" class="form-control" id="passwordInput" placeholder="Введите пароль">
				</div>
				<button type="submit" class="btn btn-primary btn-login">Войти</button>
			</form>
		</div>
	</div>
</template>

<style scoped>
.form-wrapper {
	border-radius: 20px;
	box-shadow: 0px 0px 8px 4px #0d6dfd40;
	padding: 40px 40px;
}

h3 {
	margin-bottom: 20px;
}

.login-group{
	margin-bottom: 20px;
}

.password-group{
	margin-bottom: 30px;
}

.btn-login {
	width: 100%;
}
</style>

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