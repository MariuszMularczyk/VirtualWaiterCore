<template>
    <div id="example" style="text-align:center" width="1500">
        <br />
        <h1>Twoje zamówienie jest właśnie przygotowywane</h1>
        <img class="imgsize" src="@/assets/images/preparingOrder.gif">
        <h1>Zapomiałeś czegoś?</h1>

       <h1 style="text-decoration: underline; cursor: pointer;" @click.prevent="returnToMenu()">Wroć do menu</h1>
    </div>

</template>

<script>
    import { mapActions } from "vuex";

    const name = "ordersStore/orderStore/indexStore";
    export default {
        name: "CompleteOrder",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            ...mapActions(name, ['cancelOrder']),
            returnToMenu() {
                this.cancelOrder()
                this.$router.push({ name: 'order.menu' });
            },
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
