<template>
    <form role="form" @submit.prevent="editMainCourseValidation">
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
        <router-link :to="{name: 'administration.mainCoursesList'}"><button type="default" class="btn btn-primary" style="margin-left: 20px;">Wróć</button></router-link>
        <br />
        <br />
    </form>
</template>

<script>
    import { mapActions } from "vuex";
    import { mapFields } from 'vuex-map-fields';
    import FileUploader from '../views/FileUploaderEdit'
    const name = "administrationStore/mainCourseStore/editStore";
    
    export default {
        name: "MainCourseEdit",
        data() {
            return {     
                validation: false
            }
        },
        computed: {
            ...mapFields(name,['MainCourse.Name','MainCourse.Description', 'MainCourse.Price', 'MainCourse.TimeOfPreparation', 'MainCourse.Image',]),
        },
        methods: {
            ...mapActions(name,['setMainCourseForm','editMainCourse', 'setImage']),
            onChangeImage(file) {
                this.setImage(file.base64);
            },
            editMainCourseValidation() {
                if (this.Name == '' || this.Description == '' || this.Image == '' || this.Price == 0 || this.TimeOfPreparation == 0) {
                    this.validation = true
                }
                else {
                    this.editMainCourse();
                }
            }
        },
        mounted() {
            this.setMainCourseForm();
        },
        components: {
            FileUploader
        },
    }
</script>

<style scoped>
</style>