<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.appetizer.add'}" class="btn btn-primary">
                Dodaj przystawkę
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
                <tr v-for="appetizer of getAppetizersList()" :key="`appetizer-${appetizer.id}`">
                    <td width="300px"><img width="300px" :src= "`data:image/png;base64,${appetizer.image}`"/></td>
                    <td class="name-column">{{ appetizer.name }}</td>
                    <td>{{ appetizer.description }}</td>
                    <td>{{ appetizer.price }}</td>
                    <td>{{ appetizer.timeOfPreparation }}</td>
                    <td class="buttons-column">
                        <router-link :to="{name: 'administration.appetizer.edit', params: {id: appetizer.id}}" class="btn btn-warning">
                            Edytuj
                        </router-link>
                        <button class="btn btn-danger" @click.prevent="deleteAppetizer(appetizer.id)">
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
    const name = "administrationStore/appetizerStore/indexStore";


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
            ...mapGetters(name,['getAppetizersList'])
        },
        mounted() {
            this.setAppetizersList();
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
