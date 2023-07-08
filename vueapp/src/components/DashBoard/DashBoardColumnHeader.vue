<template>
    <div class="dash-board-column-header">
        {{ title }}
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    name: "dash-board-column-header",
    props: {
        title: String
    }
});
</script>
