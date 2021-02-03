<template>

    <div id="example" width="1500" style="text-align:center;">
        <form role="form" @submit.prevent="set">
            <br />
            <div class="form-group">
                <h3>Liczba kucharzy</h3>
                <input type="number"  :min="1" style="width:50%; margin-left:25%;" v-model="Coocks" id="table" class="form-control">
            </div>
            <br />
            <button type="submit" class="btn btn-primary">Zapisz</button>
            <br />
            <br />
        </form>
    </div>
    

</template>

<script>
    import axios from 'axios';
    import router from '@/router/index';
    export default {
        name: "AppetizersList",
        data() {
            return {
                Coocks: 1
            }
        },
        computed: {
        },
        methods: {
            set() {
                console.log(this.Coocks)
                axios.post(`order/setCoocks`, { orderId: this.Coocks }).then(() => router.push({ name: 'kitchen.orders' }));
            }
        },
        mounted() {
            this.setAppetizersList();
            this.setDessertsList();
            this.setDrinksList();
            this.setMainCoursesList();
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
</style>
