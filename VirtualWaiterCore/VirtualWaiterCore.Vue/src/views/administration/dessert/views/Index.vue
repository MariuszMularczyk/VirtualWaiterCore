<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.dessert.add'}" class="btn btn-primary">
                Dodaj deser
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
                <tr v-for="dessert of getDessertsList()" :key="`category-${dessert.id}`">
                    <td width="300px"><img width="300px" :src= "`data:image/png;base64,${dessert.image}`"/></td>
                    <td class="name-column">{{ dessert.name }}</td>
                    <td>{{ dessert.description }}</td>
                    <td>{{ dessert.price }}</td>
                    <td>{{ dessert.timeOfPreparation }}</td>
                    <td class="buttons-column">
                        <router-link :to="{name: 'administration.dessert.edit', params: {id: dessert.id}}" class="btn btn-warning">
                            Edytuj
                        </router-link>
                        <button class="btn btn-danger" @click.prevent="deleteDessert(dessert.id)">
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
    const name = "administrationStore/dessertStore/indexStore";


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
            ...mapGetters(name,['getDessertsList'])
        },
        mounted() {
            this.setDessertsList();
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
