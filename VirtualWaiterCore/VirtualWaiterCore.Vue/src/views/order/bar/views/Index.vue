<template>

    <div>
        <item-list style=" margin-bottom: 20px" v-for="drink of drinksOrderList" :key="`drink-${drink.orderItemId}`" :item="drink"></item-list>
    </div>

</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    import { HubConnectionBuilder } from '@microsoft/signalr';
    import { mapFields } from 'vuex-map-fields';
    import axios from 'axios';
    const name = "ordersStore/barStore/indexStore";
    import Vuesax from 'vuesax'
    import Vue from 'vue'
    import 'vuesax/dist/vuesax.css'
    import iziToast from 'izitoast'
    import 'izitoast/dist/css/iziToast.min.css'
    import ItemList from "./ItemList";

    Vue.use(Vuesax)
    const conn = new HubConnectionBuilder().withUrl("https://localhost:44379/kitchen/ordersHub").build();
    conn.start();
    const conn2 = new HubConnectionBuilder().withUrl("https://localhost:44379/bar/waiterHub").build();
    conn2.start();

    export default {
        name: "DrinkList",
        data() {
            return {

            }
        },
        computed: {
            ...mapFields(name, ['drinksOrderList']),

        },
        methods: {
            ...mapGetters(name, ['getDrinksOrdersList']),
            ...mapActions(name, ['setDrinksOrderList']),
            readyToPickUp(order) {
                axios.post(`order/setStatus`, { orderId: order.orderId, productType: order.productType })
                    .then(() => {
                        this.ordersList = this.ordersList.filter(orderElement => orderElement !== order);
                    })
            }
        },
        mounted() {
            conn.on("TakeDrinks", data => {
                this.drinksOrderList = data;
            })
            conn2.on("SendWaiter", data => {
                iziToast.error({
                    title: 'Wezwano kelnera!',
                    message: 'Stolik ' + data + ' - wzywa kelnera',
                    timeout: false,
                    messageSize: '24',
                    titleSize: '25',
                    targetFirst: false
                });
            })
        },
        created() {
            this.setDrinksOrderList();
        },
        components: {
            ItemList
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
