<template>

    <div>
        <div class="list-buttons">
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Stolik</th>
                    <th scope="col" class="name-column">Zamówienie</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="drink of drinksOrderList" :key="`drink-${drink.orderItemId}`">
                    <td width="300px">{{drink.table}}</td>
                    <td class="name-column">
                        {{drink.order}}
                    </td>
                    <td class="buttons-column">
                        <button class="btn btn-warning" @click.prevent="readyToPickUp(order)">
                            Wydano
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróć</button></router-link>
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

    Vue.use(Vuesax)
    const conn = new HubConnectionBuilder().withUrl("https://localhost:44379/kitchen/ordersHub").build();
    conn.start();

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
            conn.on("SendWaiter", data => {
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
