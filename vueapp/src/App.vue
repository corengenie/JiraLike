<template>
	<div class="app-wrapper d-flex">
		<SideBar />
		<auth-form v-if="!isAuthorized"/>
		<router-view v-else />
	</div>
</template>

<script>

import SideBar from './components/Shared/SideBar.vue';
import AuthForm from './components/AuthForm.vue';
import { mapState } from 'vuex'

export default {
	name: 'App',
		computed: mapState({
				isAuthorized: state => state.auth.isAuthorized
			}),
	components: {
		SideBar,
		AuthForm
	},
	mounted(){
		console.log('mounted')
	}
}
</script>

<style>
@font-face {
	font-family: 'Material Symbols Rounded';
	font-style: normal;
	src: url(./fonts/MaterialSymbolsRounded[FILL\,GRAD\,opsz\,wght].woff2) format('woff2');
}

.material-symbols-rounded {
	font-family: 'Material Symbols Rounded';
	font-weight: normal;
	font-style: normal;
	font-size: 24px;
	/* Preferred icon size */
	display: inline-block;
	line-height: 1;
	text-transform: none;
	letter-spacing: normal;
	word-wrap: normal;
	white-space: nowrap;
	direction: ltr;
}

#app {
	font-family: Avenir, Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	background-color: #F4F7FD;
}
</style>
