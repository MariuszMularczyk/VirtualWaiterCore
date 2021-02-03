<template>

    <div>
        <div v-if="!drinksOrderList.length" style="text-align: center;">
            <svg id="Layer_1" height="512" viewBox="0 0 150 150" width="512" xmlns="http://www.w3.org/2000/svg" data-name="Layer 1"><circle cx="75" cy="75" fill="#21b3a9" r="64" /><path d="m115.63 82.2a4.94 4.94 0 0 0 -4.94-4.94 4.94 4.94 0 0 0 4.92-5.42 5.09 5.09 0 0 0 -5.13-4.46h-17.09l-.39-2 5-5.38a21.15 21.15 0 0 0 4.64-7.78 6.68 6.68 0 0 0 .37-1.45c.26-5.71-2.64-8.5-5.31-8.72-.72-.06-1.4-.29-1.83.29-2.39 6.7-5.77 11-9.94 13.44l-13.16 11.73-12.09 6.72-.74 28.77 14.06 3.9.5-.21v.21h36a5.09 5.09 0 0 0 5.13-4.46 4.94 4.94 0 0 0 -4.94-5.44 4.94 4.94 0 0 0 0-9.88 4.94 4.94 0 0 0 4.94-4.92z" fill="#fcd462" /><path d="m34.37 69.09h32.49v39.01h-32.49z" fill="#3a556a" /></svg>
            <h1 style="text-align:center">Wszystkie zamówienia wydane</h1>
        </div>
        <br />
        <item-list style=" margin-bottom: 20px" v-for="drink of drinksOrderList" :key="`drink-${drink.orderItemId}`" :item="drink" @done="done"></item-list>
        <br />
        <div class="text-center" style=" position: fixed; bottom: 0; left:0; text-align: center"
             cols="12">
            <div>Icons made by <a href="https://www.flaticon.com/authors/dinosoftlabs" title="DinosoftLabs">DinosoftLabs</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
            <div>Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
        </div>
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
            done(order) {
                axios.post(`order/setStatusDrinks`, { orderId: order.orderId, productType: order.productType })
                   
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
