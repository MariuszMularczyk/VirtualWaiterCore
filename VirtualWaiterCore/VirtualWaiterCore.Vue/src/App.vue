<template>
    <div class="container app " v-bind:class="swapColor">
        <router-view />
    </div>
</template>

<script>

  export default {
        name: 'App',
        data() {
            return {
            }
        }, 
        computed: {
            swapColor: function () {
                if (this.$route.name == 'order.menu') {
                    return { app1: true}
                }
                else {
                    return { app1: false }
                }

            }
        }
  }
</script>

<style >
    .app {
        background-color: white;
        margin-top: 5%;
        margin-bottom: 5%;
    }
    .app1 {
        background-color: rgba(0,0,0,0.0) !important;
    }
</style>
