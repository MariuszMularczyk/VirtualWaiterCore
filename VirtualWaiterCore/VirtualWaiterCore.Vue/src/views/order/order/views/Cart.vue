<template>
    <div class="cart">


        <div class="cart__wrapper">
            <h1 style="text-align:center">Twoje zamówienie</h1>
            <div v-if="!!cartItemsArray.length" class="cart__products-list">
                <cart-item v-for="(cartItem, index) of cartItemsArray" :key="`cart-item-${index}`" :cart-item="cartItem" />
            </div>
            <div v-if="!cartItemsArray.length">
                <h2 style="text-align:center">Brak produktów</h2>
            </div>
            <div class="cart__details">
                Wartość twojego zamówienia: <strong>{{cartTotal}} zł</strong><br />
                <div class="cart__buttons">
                    <vs-button style="font-size: 1.2rem; width: 130px;" color="rgb(59,222,200)" gradient @click.prevent="popupActivo=true" :disabled="!cartItemsArray.length">
                        Zamów
                    </vs-button>
                    <vs-button style="font-size: 1.2rem; width: 130px;" color="rgb(220, 53, 69)" gradient @click.prevent="popupActivo2=true" :disabled="!cartItemsArray.length">
                        Anuluj
                    </vs-button>
                    <vs-button style="font-size: 1.2rem; width: 130px;" gradient @click.prevent="goToMenu()">
                        Wróć
                    </vs-button>
                </div>
                <br />
            </div>


        </div>
        <div class="center">

            <vs-dialog not-close prevent-close square v-model="popupActivo">
                <template #header>
                    <h4 class="not-margin">
                        Czy na pewno chcesz złożyć zamówienie?
                    </h4>
                </template>

                <template #footer>
                    <div class="con-footer">
                        <vs-button @click="acceptOrder()" transparent>
                            <h5>Tak</h5>
                        </vs-button>
                        <vs-button @click="cancel()" dark transparent>
                            <h5>Nie</h5>
                        </vs-button>
                    </div>
                </template>
            </vs-dialog>
            <vs-dialog not-close prevent-close square v-model="popupActivo2">
                <template #header>
                    <h4 class="not-margin">
                        Czy na pewno chcesz anulować zamówienie?
                    </h4>
                </template>

                <template #footer>
                    <div class="con-footer">
                        <vs-button @click="cancelTheOrder()" transparent>
                            <h5>Tak</h5>
                        </vs-button>
                        <vs-button @click="cancel2()" dark transparent >
                            <h5>Nie</h5>
                        </vs-button>
                    </div>
                </template>
            </vs-dialog>
        </div>
    </div>
</template>

<script>
    import { mapActions, mapGetters } from "vuex";
    import CartItem from "./CartItem";
    //import _ from 'lodash';
    import Vuesax from 'vuesax'
    import Vue from 'vue'
    import 'vuesax/dist/vuesax.css'
    Vue.use(Vuesax)
    const name = "ordersStore/orderStore/indexStore";

    export default {
        name: "Cart",
        components: { CartItem },
        data: function () {
            return {

                popupActivo: false,
                popupActivo2: false,
                redirectInterval: null,
            };
        },
        computed: {
            ...mapGetters(name,{ cartItemsArray: 'cartItems', cartTotal: 'cartTotal' }),
        },
        methods: {
             ...mapActions(name, ['cancelOrder','addOrder']),
            cancelTheOrder() {
                this.popupActivo2 = false;
                this.popupActivo = false;
                this.cancelOrder()
                this.redirectInterval = setInterval(() => this.$router.push({ name: 'order.menu' }), 100);
            },
            acceptOrder() {
                this.popupActivo = false;
                this.popupActivo2 = false;
                this.addOrder()
                this.redirectInterval = setInterval(() => this.$router.push({ name: 'order.completeOrder' }), 100);
            },
            cancel() {
                this.popupActivo = false;
            },
            cancel2() {
                this.popupActivo2 = false;
            },
            goToMenu() {
                this.$router.push({ name: 'order.menu' })
            }
        },
        beforeDestroy() {
            if (null !== this.redirectInterval) {
                clearInterval(this.redirectInterval);
            }
        },
    }
</script>

<style scoped lang="sass">

    .sort
         margin: 20px
         padding: 10px
    .cart
        &__wrapper
            width: 800px
            margin: 0 auto

        &__details
            text-align: right
            padding: 50px 0
            font-size: 1.3rem
            color: black

        &__products-list
            background: #b1b6ba
            color: #c2454b
            padding: 20px
            

        &__buttons
            text-align: center
            display: flex;
            float: right
            vs-button
                margin-left: 10px
                &:first-child
                    margin-left: 0

</style>
<style >
    .not-margin {
        margin: 0px;
        font-weight: normal;
        padding: 10px;
    }

    .con-form {
        width: 100%;
    }

        .con-form .flex {
            display: flex;
            align-items: center;
            justify-content: space-between;
        }

            .con-form .flex a {
                font-size: 0.8rem;
                opacity: 0.7;
            }

                .con-form .flex a:hover {
                    opacity: 1;
                }

        .con-form .vs-checkbox-label {
            font-size: 0.8rem;
        }

        .con-form .vs-input-content {
            margin: 10px 0px;
            width: calc(100%);
        }

            .con-form .vs-input-content .vs-input {
                width: 100%;
            }

    .footer-dialog {
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
        width: calc(100%);
    }
    .con-footer {
        display: flex;
    }

            .footer-dialog .new a {
                color: rgba(var(--vs-primary), 1) !important;
                margin-left: 6px;
            }

                .footer-dialog .new a:hover {
                    text-decoration: underline;
                }

        .footer-dialog .vs-button {
            margin: 0px;
        }

  </style>