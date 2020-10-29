<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.mainCourse.add'}" class="btn btn-primary">
                Dodaj danie główne
            </router-link>
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Obraz</th>
                    <th scope="col" class="name-column">Nazwa</th>
                    <th scope="col">Opis</th>
                    <th scope="col">Cena</th>
                    <th scope="col">Czas przygotowania</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="mainCourse of getMainCoursesList()" :key="`category-${mainCourse.id}`">
                    <td width="300px"><img width="300px" :src= "`data:image/png;base64,${mainCourse.image}`"/></td>
                    <td class="name-column">{{ mainCourse.name }}</td>
                    <td>{{ mainCourse.description }}</td>
                    <td>{{ mainCourse.price }}</td>
                    <td>{{ mainCourse.timeOfPreparation }}</td>
                    <td class="buttons-column">
                        <router-link :to="{name: 'administration.mainCourse.edit', params: {id: mainCourse.id}}" class="btn btn-warning">
                            Edytuj
                        </router-link>
                        <button class="btn btn-danger" @click.prevent="deleteMainCourse(mainCourse.id)">
                            Usuń
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
    </div>
</template>

<script>

    import { mapActions, mapGetters } from 'vuex';
    const name = "administrationStore/mainCourseStore/indexStore";


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
            ...mapGetters(name,['getMainCoursesList'])
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
