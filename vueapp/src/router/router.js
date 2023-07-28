import { createRouter, createWebHistory } from "vue-router";

import HelloWorld from "@/HelloWorld.vue";
import DashBoard from "@/DashBoard/DashBoard.vue";

const routes = [
  {
    path: "/",
    name: "main",
    component: HelloWorld,
    default: true,
  },
  {
    path: "/dashboard",
    name: "dashboard",
    component: DashBoard,
  },
];

export default createRouter({
  history: createWebHistory(),
  routes,
  linkActiveClass: "active",
});