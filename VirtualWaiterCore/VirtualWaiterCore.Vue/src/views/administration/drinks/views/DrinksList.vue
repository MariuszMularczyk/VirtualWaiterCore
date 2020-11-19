<template>
    <div>
        <div class="list-buttons">
            <router-link :to="{name: 'administration.drink.add'}" class="btn btn-primary">
                Dodaj napój
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
                <tr v-for="drink of getDrinksList()" :key="`category-${drink.id}`">
                    <td width="300px"><img width="300px" :src= "`data:image/png;base64,${drink.image}`"/></td>
                    <td class="name-column">{{ drink.name }}</td>
                    <td>{{ drink.description }}</td>
                    <td>{{ drink.price }}</td>
                    <td>{{ drink.timeOfPreparation }}</td>
                    <td class="buttons-column">
                        <button class="btn btn-warning" @click.prevent="goToEdit(drink.id)">
                            Edytuj
                        </button>
                        <button class="btn btn-danger" @click.prevent="deleteDrink(drink.id)">
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
    const name = "administrationStore/drinkStore/indexStore";
    const edit = "administrationStore/drinkStore/editStore";

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
            goToEdit(id) {
                this.setDrinkForm2(id).then(this.$router.push({name: 'administration.drink.edit', params: {id: id}}))
                
            }
        },
        mounted() {
            this.setDrinksList();
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
