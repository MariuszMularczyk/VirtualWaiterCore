<template>
    <div>
        <br />
        <h1 style="text-align:center">Napoje</h1>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.drink.add'}" class="btn btn-primary">
                Dodaj napój
            </router-link>
        </div>
        <item-list style=" margin-bottom: 20px" v-for="drink of getDrinksList()" :key="`drink-${drink.id}`" :item="drink" :category="'Napój'" @editItem="editItem" @deleteItem="deleteDrink"></item-list>

        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
        <br />
        <br />
        <div class="text-center" style=" position: fixed; right:0; bottom: 0;  text-align: center"
             cols="12">
            <div>Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
        </div>
    </div>
</template>

<script>
    import ItemList from "@/components/ItemList"

    import { mapActions, mapGetters } from 'vuex';
    const name = "administrationStore/drinkStore/indexStore";
    const edit = "administrationStore/drinkStore/editStore";
    import router from '@/router/index';
    export default {
        name: "DrinksList",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            ...mapActions(name,['setDrinksList', 'deleteDrink']),
            ...mapGetters(name,['getDrinksList']),
            ...mapActions(edit,['setDrinkForm2',]),
            editItem(e) {
                router.push({ name: 'administration.drink.edit', params: { id: e } });
            }
        },
        components: {
            ItemList
        },
        mounted() {
            this.setDrinksList();
        },
    }
</script>

<style scoped lang="sass">
    .list-buttons
        margin-bottom: 20px
        margin-left: 85%;
        .name-column
            width: 100px

        .buttons-column
            display: flex
            flex-direction: row
            button
                margin-left: 10px
</style>
