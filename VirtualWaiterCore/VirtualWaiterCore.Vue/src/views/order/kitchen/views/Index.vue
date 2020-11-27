<template>

    <div>
        <div class="list-buttons">
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Stolik</th>
                    <th scope="col" class="name-column">Zamówienie</th>
                    <th scope="col">Sugerowana godzina rozpoczęcia</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="order of ordersList" :key="`order-${order.orderItemId}`">
                    <td width="300px">{{order.table}}</td>
                    <td class="name-column">
                        {{order.order}}
                    </td>
                    <td>
                        {{order.timeOfOrder}}
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
    const name = "ordersStore/kitchenStore/indexStore";
    import Vuesax from 'vuesax'
    import Vue from 'vue'
    import 'vuesax/dist/vuesax.css'
    Vue.use(Vuesax)
    const conn = new HubConnectionBuilder().withUrl("https://localhost:44379/kitchen/ordersHub").build();
    conn.start();

    export default {
        name: "OrderList",
        data() {
            return {

            }
        },
        computed: {
            ...mapFields(name, ['ordersList']),
        },
        methods: {
            ...mapGetters(name, ['getOrdersList']),
            ...mapActions(name, ['setOrdersList']),
            readyToPickUp(order) {
                axios.post(`order/setStatus`, { orderId: order.orderId, productType: order.productType })
                    .then(() => {
                        this.ordersList = this.ordersList.filter(orderElement => orderElement !== order);
                    })
            }
        },
        mounted() {
            conn.on("TakeOrders", data => {
                console.log(data);
                this.ordersList = data;
            }) 
        },
        created() {
            this.setOrdersList();
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
