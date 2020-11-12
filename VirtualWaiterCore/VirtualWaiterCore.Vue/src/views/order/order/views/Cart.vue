<template>
    <div class="cart">
        <div v-if="!cartItemsArray.length">
            Brak produktów
        </div>

        <div class="cart__wrapper">
            <div v-if="!!cartItemsArray.length" class="cart__products-list">
                <cart-item v-for="(cartItem, index) of cartItemsArray" :key="`cart-item-${index}`" :cart-item="cartItem" />
            </div>

            <div class="cart__details">
                Wartoœæ twojego zamówienia: <strong>{{cartTotal}} z³</strong>
            </div>

            <div class="cart__buttons">
                <button class="btn button" @click.prevent="goToMenu()">
                    Wróæ
                </button>

                <button class="btn button--red" @click.prevent="popupActivo2=true">
                    Anuluj
                </button>

                <button :disabled="!cartItemsArray.length" class="btn button" @click.prevent="popupActivo=true">
                    Zamów
                </button>
            </div>
        </div>
        <div class="center">

            <vs-dialog not-close prevent-close square v-model="popupActivo">
                <template #header>
                    <h4 class="not-margin">
                        Czy na pewno chcesz z³o¿yæ zamówienie?
                    </h4>
                </template>

                <template #footer>
                    <div class="con-footer">
                        <vs-button @click="acceptOrder()" transparent>
                            Tak
                        </vs-button>
                        <vs-button @click="cancel()" dark transparent>
                            Nie
                        </vs-button>
                    </div>
                </template>
            </vs-dialog>
            <vs-dialog not-close prevent-close square v-model="popupActivo2">
                <template #header>
                    <h4 class="not-margin">
                        Czy na pewno chcesz anulowaæ zamówienie?
                    </h4>
                </template>

                <template #footer>
                    <div class="con-footer">
                        <vs-button @click="cancelTheOrder()" transparent>
                            Tak
                        </vs-button>
                        <vs-button @click="cancel2()" dark transparent>
                            Nie
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
                //this.redirectInterval = setInterval(() => this.$router.push({ name: 'order.menu' }), 100);
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
            color: #01673d

        &__products-list
            background: #01673d
            color: #c2454b
            padding: 20px
            border-radius: 5px

        &__buttons
            text-align: center
            button
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