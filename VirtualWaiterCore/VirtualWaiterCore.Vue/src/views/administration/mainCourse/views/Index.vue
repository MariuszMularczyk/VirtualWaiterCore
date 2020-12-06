<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.mainCourse.add'}" class="btn btn-primary">
                Dodaj danie główne
            </router-link>
        </div>

        <item-list style=" margin-bottom: 20px" v-for="mainCourse of getMainCoursesList()" :key="`drink-${mainCourse.id}`" :item="mainCourse" :category="'Danie główne'" @editItem="editItem" @deleteItem="deleteMainCourse"></item-list>

        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
    </div>
</template>

<script>
    import router from '@/router/index';
    import { mapActions, mapGetters } from 'vuex';
    const name = "administrationStore/mainCourseStore/indexStore";
    import ItemList from "@/components/ItemList"


    export default {
        name: "MainCoursesList",
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            ...mapActions(name,['setMainCoursesList', 'deleteMainCourse']),
            ...mapGetters(name, ['getMainCoursesList']),
            editItem(e) {
                router.push({ name: 'administration.mainCourse.edit', params: { id: e } });
            }
        },
        components: {
            ItemList
        },
        mounted() {
            this.setMainCoursesList();
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
