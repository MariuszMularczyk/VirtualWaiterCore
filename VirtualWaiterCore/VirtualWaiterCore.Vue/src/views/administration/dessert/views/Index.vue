<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.dessert.add'}" class="btn btn-primary">
                Dodaj deser
            </router-link>
        </div>
        <item-list style=" margin-bottom: 20px" v-for="dessert of getDessertsList()" :key="`dessert-${dessert.id}`" :item="dessert" :category="'Deser'" @editItem="editItem" @deleteItem="deleteDessert"></item-list>
        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
    </div>
</template>

<script>
    import router from '@/router/index';
    import { mapActions, mapGetters } from 'vuex';
    const name = "administrationStore/dessertStore/indexStore";
    import ItemList from "@/components/ItemList"


    export default {
        name: "DessertsList",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            ...mapActions(name,['setDessertsList', 'deleteDessert']),
            ...mapGetters(name, ['getDessertsList']),
            editItem(e) {
                router.push({ name: 'administration.dessert.edit', params: { id: e } });
            }
        },
        mounted() {
            this.setDessertsList();
        },
        components: {
            ItemList
        }
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
