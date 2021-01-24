<template>
    <form role="form" @submit.prevent="editDessertValidation">
        <br />
        <div v-if="this.validation">
            <h2 style="color: red">Musisz wypełnić wszystkie pola aby edytować produkt!</h2>
        </div>
        <div class="form-group" width="500px" height="300px">
            <label for="image">Obraz</label>
            <file-uploader id="image" @change="onChangeImage"></file-uploader>
        </div>

        <div class="form-group">
            <label for="name">Nazwa</label>
            <input type="text" v-model="Name" class="form-control" id="name">
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
        <router-link :to="{name: 'administration.dessertsList'}"><button type="default" class="btn btn-primary" style="margin-left: 20px;">Wróć</button></router-link>
        <br />
        <br />
    </form>
</template>

<script>
    import { mapActions } from "vuex";
    import { mapFields } from 'vuex-map-fields';
    import FileUploader from '../views/FileUploaderEdit'
    const name = "administrationStore/dessertStore/editStore";
    
    export default {
        name: "DessertEdit",
        data() {
            return {
                validation: false
            }
        },
        computed: {
            ...mapFields(name,['Dessert.Name','Dessert.Description', 'Dessert.Price', 'Dessert.TimeOfPreparation', 'Dessert.Image',]),
        },
        methods: {
            ...mapActions(name,['setDessertForm','editDessert', 'setImage']),
            onChangeImage(file) {
                this.setImage(file.base64);
            },
            editDessertValidation() {
                if (this.Name == '' || this.Description == '' || this.Image == '' || this.Price == 0 || this.TimeOfPreparation == 0) {
                    this.validation = true
                }
                else {
                    this.editDessert();
                }
            }
        },
        mounted() {
           this.setDessertForm();
        },
        components: {
            FileUploader
        },
    }
</script>

<style scoped>
</style>