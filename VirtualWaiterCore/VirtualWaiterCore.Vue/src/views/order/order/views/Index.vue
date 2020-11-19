<template>

    <div id="example" width="1500">

        <div class="center examplex">
            <vs-navbar square center-collapsed v-model="active">
                <template #left>
                    <img width="100px" height="100px" src="@/assets/images/logo.png" alt="">
                </template>
                <vs-navbar-item style="font-size: 1.85rem;" :active="active == 'Appetizers'" id="Appetizers">
                    Przystawki
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" :active="active == 'MainCourses'" id="MainCourses">
                    Dania główne
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" :active="active == 'Desserts'" id="Desserts">
                    Desery
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" :active="active == 'Drinks'" id="Drinks">
                    Drinki
                </vs-navbar-item>
                <template #right>
                    <vs-button style="font-size: 1.00rem;" @click="getWaiter()" >Wezwij kelnera</vs-button>
                    <vs-button  style="font-size: 1.00rem;" color="rgb(59,222,200)" gradient @click="goToCart()" >Zamówienie</vs-button>
                </template>
            </vs-navbar>
        </div>


        <div style="margin-top: 15%">
            <carousel-3d :controls-visible="true" :controls-prev-html="'&#10092; '" :controls-next-html="'&#10093;'"
                         :controls-width="30" :controls-height="60" :clickable="false" width="800" height="470">
                <slide v-for="(item, i) in getMenu()" :index="i" v-bind:key="i">
                    <figure>
                        <img width="800" height="470" :src="`data:image/png;base64,${item.image}`">
                        <figcaption>
                            {{item.name}}<br />
                            {{item.description}}<br />
                            Cena: {{item.price}} zł <br />
                            Czas przygotowania: {{item.timeOfPreparation}} min <br />
                            <svg height="40pt" viewBox="0 0 512 512" width="40pt" xmlns="http://www.w3.org/2000/svg" @click.prevent="addToCart(item)"><path d="m453.332031 0h-394.664062c-32.363281 0-58.667969 26.304688-58.667969 58.667969v394.664062c0 32.363281 26.304688 58.667969 58.667969 58.667969h394.664062c32.363281 0 58.667969-26.304688 58.667969-58.667969v-394.664062c0-32.363281-26.304688-58.667969-58.667969-58.667969zm0 0" fill="#2196f3" /><path d="m368 277.332031h-90.667969v90.667969c0 11.777344-9.535156 21.332031-21.332031 21.332031s-21.332031-9.554687-21.332031-21.332031v-90.667969h-90.667969c-11.796875 0-21.332031-9.554687-21.332031-21.332031s9.535156-21.332031 21.332031-21.332031h90.667969v-90.667969c0-11.777344 9.535156-21.332031 21.332031-21.332031s21.332031 9.554687 21.332031 21.332031v90.667969h90.667969c11.796875 0 21.332031 9.554687 21.332031 21.332031s-9.535156 21.332031-21.332031 21.332031zm0 0" fill="#fafafa" /></svg>
                        </figcaption>
                    </figure>
                </slide>
            </carousel-3d>
        </div>
    </div>

</template>

<script>
    import { Carousel3d, Slide } from 'vue-carousel-3d';
    import { mapGetters, mapActions } from 'vuex';
    const name = "ordersStore/orderStore/indexStore";
    import { mapFields } from 'vuex-map-fields';
    import Vuesax from 'vuesax'
    import Vue from 'vue'
    import 'vuesax/dist/vuesax.css'
    Vue.use(Vuesax)
    import { HubConnectionBuilder } from '@microsoft/signalr';
    const conn = new HubConnectionBuilder().withUrl("https://localhost:44379/kitchen/ordersHub").build();
    conn.start();

    export default {
        name: "AppetizersList",
        data() {
            return {
                menu: null,
                active: 'Appetizers'
            }
        },
        computed: {
            ...mapFields(name, ['cartItems', 'Order.Table']),

        },
        methods: {
            ...mapGetters(name, ['getAppetizersList', 'getDessertsList', 'getDrinksList', 'getMainCoursesList']),
            ...mapActions(name, ['addToCart']),
            getMenu() {
                switch (this.active) {
                    case 'Appetizers':
                        return this.getAppetizersList();
                    case 'MainCourses':
                        return this.getMainCoursesList();
                    case 'Desserts':
                        return this.getDessertsList();
                    case 'Drinks':
                        return this.getDrinksList();
                    default:
                        return null;
                }
            },
            goToCart() {
                this.$router.push({ name: 'order.cart' })
            },
            getWaiter() {
                conn.invoke("GetWaiter", this.Table);
            }
        },
        mounted() {

        },
        components: {
            Carousel3d,
            Slide
        },
    }
</script>

<style >
    .carousel-3d-container figure {
      margin:0;
    }
   .carousel-3d-container figcaption {
      position: absolute;
      background-color: rgba(0, 0, 0, 0.5);
      color: #fff;
      bottom: 0;
      position: absolute;
      bottom: 0;
      padding: 15px;
      font-size: 12px;
      min-width: 100%;
      box-sizing: border-box;
    }

</style>
