<template>

    <div id="example" width="1500">
        <div class="form-group">
            <label for="table" class="control-label">Ustaw stolik</label>
            <textarea v-model="Table" id="table" class="form-control"></textarea>
        </div>
        <router-link :to="{name: 'order.menu'}"><button type="default" class="btn btn-primary">Dalej</button></router-link>
    </div>

</template>

<script>
    import { mapActions } from 'vuex';
    import { mapFields } from 'vuex-map-fields';
    const name = "ordersStore/orderStore/indexStore";


    export default {
        name: "AppetizersList",
        data() {
            return {
                slides: 7
            }
        },
        computed: {
              ...mapFields(name,['Table']),
        },
        methods: {
            ...mapActions(name,['setAppetizersList']),
        },
        mounted() {
            this.setAppetizersList();
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
