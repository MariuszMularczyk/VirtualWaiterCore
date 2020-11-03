<template>

    <div id="example" width="1500">
        <carousel-3d :controls-visible="true" :controls-prev-html="'&#10092; '" :controls-next-html="'&#10093;'"
                     :controls-width="30" :controls-height="60" :clickable="false" width="800" height="470">
            <slide v-for="(item, i) in getAppetizersList()" :index="i" v-bind:key="i">
                <figure>
                    <img width="800" height="470" :src="`data:image/png;base64,${item.image}`">
                    <figcaption>
                        {{item.name}}<br />
                        {{item.description}}<br />
                        Cena: {{item.price}} z³ <br />
                        Czas przygotowania: {{item.timeOfPreparation}} min <br/>
                        <svg height="40pt" viewBox="0 0 512 512" width="40pt" xmlns="http://www.w3.org/2000/svg"  @click.prevent="addToCart(item.id)" ><path d="m453.332031 0h-394.664062c-32.363281 0-58.667969 26.304688-58.667969 58.667969v394.664062c0 32.363281 26.304688 58.667969 58.667969 58.667969h394.664062c32.363281 0 58.667969-26.304688 58.667969-58.667969v-394.664062c0-32.363281-26.304688-58.667969-58.667969-58.667969zm0 0" fill="#2196f3" /><path d="m368 277.332031h-90.667969v90.667969c0 11.777344-9.535156 21.332031-21.332031 21.332031s-21.332031-9.554687-21.332031-21.332031v-90.667969h-90.667969c-11.796875 0-21.332031-9.554687-21.332031-21.332031s9.535156-21.332031 21.332031-21.332031h90.667969v-90.667969c0-11.777344 9.535156-21.332031 21.332031-21.332031s21.332031 9.554687 21.332031 21.332031v90.667969h90.667969c11.796875 0 21.332031 9.554687 21.332031 21.332031s-9.535156 21.332031-21.332031 21.332031zm0 0" fill="#fafafa" /></svg>
                    </figcaption>
                </figure>
            </slide>
        </carousel-3d>
        {{Products}}
    </div>

</template>

<script>
    import { Carousel3d, Slide } from 'vue-carousel-3d';
    import { mapGetters , mapActions} from 'vuex';
    const name = "ordersStore/orderStore/indexStore";
    import { mapFields } from 'vuex-map-fields';


    export default {
        name: "AppetizersList",
        data() {
            return {
                slides: 7
            }
        },
        computed: {
            ...mapFields(name, ['Products']),
        },
        methods: {
            ...mapGetters(name, ['getAppetizersList']),
            ...mapActions(name,['addToCart']),
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
