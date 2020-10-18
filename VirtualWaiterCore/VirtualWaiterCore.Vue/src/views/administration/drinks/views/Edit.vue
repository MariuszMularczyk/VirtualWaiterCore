<template>
    <form role="form" @submit.prevent="editDrink">
        <div class="form-group" width="500px" height="300px">
            <label for="image">Obraz</label>
            <base64-upload id="image" :imageSrc="`data:image/jpeg;base64,`+ this.Image" @change="onChangeImage"></base64-upload>
        </div>

        <div class="form-group">
            <label for="drinkName">Nazwa</label>
            <input type="text" v-model="Name" class="form-control" id="drinkName">
        </div>

        <div class="form-group">
            <label for="description" class="control-label">Opis</label>
            <textarea v-model="Description" id="description" class="form-control"></textarea>
        </div>
        <div class="form-group">
            <label for="price" class="control-label">cena</label>
            <input type="number" v-model="Price" id="price" class="form-control">
        </div>
        <div class="form-group">
            <label for="timeOfPreparation" class="control-label">Czas przygotowania</label>
            <input type="number" v-model="TimeOfPreparation" id="timeOfPreparation" class="form-control">
        </div>
        <button type="submit" class="btn btn-primary">Zapisz</button>
        <router-link :to="{name: 'administration.drinksList'}"><button type="default" class="btn btn-primary" style="margin-left: 20px;">Wróć</button></router-link>
    </form>
</template>

<script>
    import { mapActions, mapGetters } from "vuex";
    import { mapFields } from 'vuex-map-fields';
    import Base64Upload from 'vue-base64-upload'
    const name = "administrationStore/drinkStore/editStore";
    
    export default {
        name: "DrinkEdit",
        data() {
            return {
                srcImage:  this.getImage()
            }
        },
        computed: {
            ...mapFields(name,['editDrink.Name','editDrink.Description', 'editDrink.Price', 'editDrink.TimeOfPreparation', 'editDrink.Image',]),
        },
        methods: {
            ...mapActions(name,['setDrinkForm','editDrink', 'setImage']),
            ...mapGetters(name,['getImage']),
            onChangeImage(file) {
                this.setImage(file.base64);
            }
        },
        beforeCreate(){
            this.setDrinkForm();
        },
        mounted() {
            
        },
        components: {
            Base64Upload
        },
    }
</script>

<style scoped>
</style>