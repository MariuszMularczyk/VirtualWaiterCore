<template>

    <div id="example" width="1500" >

        <div class="center examplex">
            <vs-navbar square center-collapsed v-model="active">
                <template #left>
                    <img width="100px" height="100px" src="@/assets/images/logo.png" alt="">
                </template>
                <vs-navbar-item style="font-size: 1.85rem;" @click="forceRerender()" :active="active == 'Appetizers'" id="Appetizers">
                    Przystawki
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" @click="forceRerender()" :active="active == 'MainCourses'" id="MainCourses">
                    Dania główne
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" @click="forceRerender()"  :active="active == 'Desserts'" id="Desserts">
                    Desery
                </vs-navbar-item>
                <vs-navbar-item style="font-size: 1.85rem;" @click="forceRerender()" :active="active == 'Drinks'" id="Drinks">
                    Napoje
                </vs-navbar-item>
                <template #right>
                    <vs-button style="font-size: 1.00rem;" gradient @click="getWaiter()">Wezwij kelnera</vs-button>
                    <vs-button style="font-size: 1.00rem;" color="rgb(59,222,200)" gradient @click="goToCart()">Zamówienie <div style="font-size: large; margin-right: 10px;">
                        <svg height="15pt" width="15pt" version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 55 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve">
                            <g>
                                <g>
                                    <path style="fill:#FFFFFF;" d="M458.732,422.212l-22.862-288.109c-1.419-18.563-17.124-33.098-35.737-33.098h-45.164v66.917c0,8.287-6.708,14.995-14.995,14.995c-8.277,0-14.995-6.708-14.995-14.995v-66.917H187.028v66.917c0,8.287-6.718,14.995-14.995,14.995c-8.287,0-14.995-6.708-14.995-14.995v-66.917h-45.164c-18.613,0-34.318,14.535-35.737,33.058L53.265,422.252c-1.769,23.082,6.238,46.054,21.962,63.028C90.952,502.253,113.244,512,136.386,512h239.236c23.142,0,45.434-9.747,61.159-26.721C452.505,468.305,460.512,445.333,458.732,422.212z M323.56,275.493l-77.553,77.553c-2.929,2.929-6.768,4.398-10.606,4.398c-3.839,0-7.677-1.469-10.606-4.398l-36.347-36.347c-5.858-5.858-5.858-15.345,0-21.203c5.858-5.858,15.355-5.858,21.203,0l25.751,25.741l66.956-66.956c5.848-5.848,15.345-5.848,21.203,0C329.418,260.139,329.418,269.635,323.56,275.493z" />
                                </g>
                          </g>
                        <g>
                                <g>
                                    <path style="fill:#FFFFFF;" d="M256.004,0c-54.571,0-98.965,44.404-98.965,98.975v2.029h29.99v-2.029c0-38.037,30.939-68.986,68.976-68.986s68.976,30.949,68.976,68.986v2.029h29.989v-2.029C354.969,44.404,310.575,0,256.004,0z" />
                                </g>
                            </g>
                        </svg>
                        <strong>{{cartTotal()}}zł</strong>
                    </div></vs-button>
                </template>
            </vs-navbar>
        </div>


        <div style="margin-top: 15% ;">
            <carousel-3d :controls-visible="true" :controls-prev-html="'&#10092; '" :controls-next-html="'&#10093;'"
                         :controls-width="30" :controls-height="60" :clickable="false" width="800" height="470" :key="componentKey">
                <slide v-for="(item, i) in getMenu()" :index="i" v-bind:key="i">
                    <figure>
                        <img width="800" height="470" :src="`data:image/png;base64,${item.image}`">
                        <figcaption>
                            <div style="float: left; width: 80%;">
                                <h3>{{item.name}}</h3>
                                <div style="font-size: large;">
                                    {{item.description}}<br />
                                    Cena: {{item.price}} zł <br />
                                    Czas przygotowania: {{item.timeOfPreparation}} min <br />
                                </div>
                            </div>

                            <!--<svg height="40pt" viewBox="0 0 512 512" width="40pt" xmlns="http://www.w3.org/2000/svg" @click.prevent="addToCart(item)"><path d="m453.332031 0h-394.664062c-32.363281 0-58.667969 26.304688-58.667969 58.667969v394.664062c0 32.363281 26.304688 58.667969 58.667969 58.667969h394.664062c32.363281 0 58.667969-26.304688 58.667969-58.667969v-394.664062c0-32.363281-26.304688-58.667969-58.667969-58.667969zm0 0" fill="#2196f3" /><path d="m368 277.332031h-90.667969v90.667969c0 11.777344-9.535156 21.332031-21.332031 21.332031s-21.332031-9.554687-21.332031-21.332031v-90.667969h-90.667969c-11.796875 0-21.332031-9.554687-21.332031-21.332031s9.535156-21.332031 21.332031-21.332031h90.667969v-90.667969c0-11.777344 9.535156-21.332031 21.332031-21.332031s21.332031 9.554687 21.332031 21.332031v90.667969h90.667969c11.796875 0 21.332031 9.554687 21.332031 21.332031s-9.535156 21.332031-21.332031 21.332031zm0 0" fill="#fafafa" /></svg>-->
                            <svg  height="40pt" width="40pt" version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"  @click.prevent="addToCart(item)"
                                 viewBox="0 0 455.431 455.431" style="enable-background:new 0 0 455.431 455.431; float: right;margin-top: 4%;cursor: pointer;" xml:space="preserve">
                                    <path style="fill:#9fa19c;" d="M405.493,412.764c-69.689,56.889-287.289,56.889-355.556,0c-69.689-56.889-62.578-300.089,0-364.089s292.978-64,355.556,0S475.182,355.876,405.493,412.764z" />

                                    <g style="opacity:0.2;">
                                                                <path style="fill:#FFFFFF;" d="M229.138,313.209c-62.578,49.778-132.267,75.378-197.689,76.8c-48.356-82.489-38.4-283.022,18.489-341.333c51.2-52.622,211.911-62.578,304.356-29.867C377.049,112.676,330.116,232.142,229.138,313.209z" />
                                    </g>
                                    <path style="fill:#FFFFFF;" d="M362.827,227.876c0,14.222-11.378,25.6-25.6,25.6h-85.333v85.333c0,14.222-11.378,25.6-25.6,25.6c-14.222,0-25.6-11.378-25.6-25.6v-85.333H115.36c-14.222,0-25.6-11.378-25.6-25.6c0-14.222,11.378-25.6,25.6-25.6h85.333v-85.333c0-14.222,11.378-25.6,25.6-25.6c14.222,0,25.6,11.378,25.6,25.6v85.333h85.333C351.449,202.276,362.827,213.653,362.827,227.876z" />
                                    </svg>
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
    const conn = new HubConnectionBuilder().withUrl("https://localhost:44379/bar/waiterHub").build();
    conn.start();

    export default {
        name: "AppetizersList",
        data() {
            return {
                menu: null,
                active: 'Appetizers',
                componentKey: 0,
            }
        },
        computed: {
            ...mapFields(name, ['cartItems', 'Order.Table']),

        },
        methods: {
            ...mapGetters(name, ['getAppetizersList', 'getDessertsList', 'getDrinksList', 'getMainCoursesList', 'cartTotal']),
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
            forceRerender() {
                this.componentKey += 1;
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
      background-color: rgba(0, 0, 0, 0.3);
      color: #fff;
      bottom: 0;
      position: absolute;
      bottom: 0;
      padding: 15px;
      font-size: 12px;
      min-width: 100%;
      box-sizing: border-box;
    }
   .next{
       color: white !important
   }
    .prev {
        color: white !important
    }
   

</style>
