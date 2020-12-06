<template>

    <div>
        <item-list style=" margin-bottom: 20px" v-for="order of ordersList" :key="`order-${order.orderItemId}`" :item="order" :category="order.productType" ></item-list>
    </div>

</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    import { HubConnectionBuilder } from '@microsoft/signalr';
    import { mapFields } from 'vuex-map-fields';
    import ItemList from "./ItemList";
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
