<template>
    <div class="container dash-board-root">
        <div class="d-flex justify-content-around flex-nowrap">
            <div class="d-flex flex-column">
                <dash-board-column-header title="Идея"/>
                <dash-board-card title="Разработать дизайн" date_day="5" date_month="мая" />
                <dash-board-card/>
                <dash-board-card/>
            </div>
            <div class="d-flex flex-column">
                <dash-board-column-header title="В работе"/>
                <dash-board-card/>
                <dash-board-card/>
                <dash-board-card/>
            </div>
            <div class="d-flex flex-column">
                <dash-board-column-header title="Готово"/>
                <dash-board-card/>
                <dash-board-card/>
                <dash-board-card/>
            </div>
        </div>
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import DashBoardCard from './DashBoardCard.vue'
import DashBoardColumnHeader from './DashBoardColumnHeader.vue';

export default defineComponent({
    name: "dash-board",
    components: {
        DashBoardCard,
        DashBoardColumnHeader
    },
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

<style scoped>
.dash-board-root {
    margin-top: 20px;
}
</style>