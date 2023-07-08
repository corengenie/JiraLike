<template>
  <div class="d-flex flex-column justify-content-between bg-light sidebar" style="width: 4.5rem;">
    <ul class="nav nav-pills nav-flush flex-column mb-auto text-center">
      <li class="nav-item">
        <router-link to="/" class="nav-link py-3 border-bottom" aria-current="page" title="Главная" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Home">
            <span class="material-symbols-rounded">home</span>
        </router-link>
      </li>
      <li>
        <router-link to="/dashboard" class="nav-link py-3 border-bottom" title="Дэшборд" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-original-title="Dashboard">
            <span class="material-symbols-rounded">space_dashboard</span>
        </router-link>
      </li>
    </ul>
    <div class="dropdown border-top">
      <a href="#" class="d-flex align-items-center justify-content-center p-3 link-dark text-decoration-none dropdown-toggle" id="dropdownUser3" data-bs-toggle="dropdown" aria-expanded="false">
        <img src="https://github.com/mdo.png" alt="mdo" width="24" height="24" class="rounded-circle">
      </a>
      <ul class="dropdown-menu text-small shadow" aria-labelledby="dropdownUser3">
        <li><a class="dropdown-item" href="#">Настройки</a></li>
        <li><a class="dropdown-item" href="#">Профиль</a></li>
        <li><hr class="dropdown-divider"></li>
        <li><a class="dropdown-item" href="#">Выйти</a></li>
      </ul>
    </div>
  </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
        },
        watch: {
        },
        methods: {
        },
    });
</script>

<style>
  .sidebar {
    height: 100vh;
  }
</style>