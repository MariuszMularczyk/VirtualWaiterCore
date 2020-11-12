<template>
    <div class="cart-item">
        <div class="cart-item__info">
            <h5 class="card-title">{{ cartItem.quantity }} x {{ cartItem.product.name }} </h5>

            <div class="cart-item__info__right">
                <strong>{{ totalPrice }} z³</strong>

                <div class="cart-item__info__right__buttons">
                    <a @click.prevent="reduce(cartItem.id)" :disabled="!canRemoveQuantity" class="btn btn-info"
                       :class="{disabled: !canRemoveQuantity}">-</a>
                    <a @click.prevent="add(cartItem.id)" class="btn btn-info">+</a>
                    <a @click.prevent="removeProduct(cartItem)" class="btn button--red">x</a>
                </div>
            </div>
        </div>


    </div>
</template>

<script>
    const name = "ordersStore/orderStore/indexStore";

    import { mapActions} from 'vuex';
    export default {
        name: "CartItem",
        props: {
            cartItem: {
                required: true,
                type: Object
            },
        },
        methods: {
            ...mapActions(name, ['reduceQuantity', 'removeProduct']),
            reduce(id) {
                this.cartItem.quantity--;
                this.reduceQuantity(id)
            },
            add(id) {
                this.cartItem.quantity++;
                this.addQuantity(id)
            }
        },
        computed: {
            totalPrice() {
                return this.cartItem.quantity * this.cartItem.product.price;
            },
            canRemoveQuantity() {
                return 1 < this.cartItem.quantity;
            },
        }
    }
</script>

<style scoped lang="sass">


    .cart-item
        border-bottom: 1px dashed #ffffff
        padding: 20px 0

        &:last-child
            border-bottom: 0

        &__info
            display: flex
            justify-content: space-between
            align-items: center

            &__right
                display: flex
                align-items: center

                &__buttons
                    margin-left: 10px

                    a
                        margin: 0 4px
</style>
