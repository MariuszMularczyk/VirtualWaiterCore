<template>

    <div>
        <div class="list-buttons">
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Stolik</th>
                    <th scope="col" class="name-column">Zamówienie</th>
                    <th scope="col">Sugerowana godzina rozpoczêcia</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="order of getOrdersList()" :key="`category-${order.id}`">
                    <td width="300px">{{order.table}}</td>
                    <td class="name-column">
                        {{order.order}}
                    </td>
                    <td>
                        {{order.timeOfOrder}}
                    </td>
                    <td class="buttons-column">
                        <button class="btn btn-warning">
                            Edytuj
                        </button>

                    </td>
                </tr>
            </tbody>
        </table>
        <router-link :to="{name: 'administrationDashboard'}"><button type="default" class="btn btn-primary">Wróæ</button></router-link>
    </div>

</template>

<script>
    import { mapGetters, mapActions } from 'vuex';
    const name = "ordersStore/kitchenStore/indexStore";
    import Vuesax from 'vuesax'
    import Vue from 'vue'
    import 'vuesax/dist/vuesax.css'
    Vue.use(Vuesax)

    export default {
        name: "OrderList",
        data() {
            return {
                
            }
        },
        computed: {

        },
        methods: {
            ...mapGetters(name, ['getOrdersList']),
            ...mapActions(name, ['setOrdersList']),
        },
        mounted() {

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
