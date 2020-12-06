<template>
    <div id="example" style="text-align:center" width="1500">
        <br />
        <h1>Twoje zamówienie jest właśnie przygotowywane</h1>
        <img class="imgsize" src="@/assets/images/preparingOrder.gif">
        <h1>Zapomiałeś czegoś?</h1>
        <router-link :to="{name: 'order.menu'}"><h1 style="text-decoration: underline;">Wroć do menu</h1></router-link>
    </div>

</template>

<script>

    export default {
        name: "CompleteOrder",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
        },
        mounted() {

        },
        components: {

        },
    }
</script>

<style scoped lang="sass">
    .list-buttons
        margin-bottom: 20px

        .name-column
            width: 100px

        .buttons-column
            display: flex
            flex-direction: row
            button
                margin-left: 10px
    .imgsize
        width: 90%
        margin-left: 5%
</style>
