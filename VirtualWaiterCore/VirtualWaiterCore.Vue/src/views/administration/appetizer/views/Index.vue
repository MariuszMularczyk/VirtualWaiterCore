<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.appetizer.add'}" class="btn btn-primary">
                Dodaj przystawkę
            </router-link>
        </div>
        <item-list style=" margin-bottom: 20px" v-for="appetizer of getAppetizersList()" :key="`appetizer-${appetizer.id}`" :item="appetizer" :category="'Przystawka'" @editItem="editItem" @deleteItem="deleteAppetizer"></item-list>
        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
    </div>
</template>

<script>
    import router from '@/router/index';
    import { mapActions, mapGetters } from 'vuex';
    const name = "administrationStore/appetizerStore/indexStore";
    import ItemList from "@/components/ItemList"

    export default {
        name: "AppetizersList",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            ...mapActions(name,['setAppetizersList', 'deleteAppetizer']),
            ...mapGetters(name, ['getAppetizersList']),
            editItem(e) {
                router.push({ name: 'administration.appetizer.edit', params: { id: e } });
            }
        },
        mounted() {
            this.setAppetizersList();
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
