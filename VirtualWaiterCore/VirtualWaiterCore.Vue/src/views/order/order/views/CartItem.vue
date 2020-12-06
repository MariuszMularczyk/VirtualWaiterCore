<template>
    <div class="cart-item">
        <article class="blog-card">
            <img class="post-image" :src="`data:image/png;base64,${cartItem.product.image}`" />
            <div class="article-details">

                <div class="post-title floatLeft">{{ cartItem.quantity }} x {{ cartItem.product.name }}</div>
                <div class="cart-item__info__right">
                    <strong>{{ totalPrice }} zł</strong>

                    <div class="cart-item__info__right__buttons">
                        <a @click.prevent="reduce(cartItem.id)" :disabled="!canRemoveQuantity" class="btn btn-info"
                           :class="{disabled: !canRemoveQuantity}">-</a>
                        <a @click.prevent="add(cartItem.id)" class="btn btn-info">+</a>
                        <a @click.prevent="removeProduct(cartItem)" class="btn btn-danger">x</a>
                    </div>
                </div>

            </div>
        </article>
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
                float: right
                align-items: center

                &__buttons
                    margin-left: 10px

                    a
                        margin: 0 4px
</style>

<style scoped lang="scss">
    @import url('https://fonts.googleapis.com/css?family=Roboto:400,700');

    $bg: #eedfcc;
    $text: #777;
    $black: #121212;
    $white: #fff;
    $red: #e04f62;
    $border: #ebebeb;
    $shadow: rgba(0, 0, 0, 0.2);

    @mixin transition($args...) {
        transition: $args;
    }

    * {
        box-sizing: border-box;
        &::before, &::after

    {
        box-sizing: border-box;
    }

    }

    .floatLeft{
        float: left;
        margin-top: 5%
    }
    .buttons {
        width: 25px;
        height: 25px;
    }
    .btn-span {
        float: right;
        margin-left: 8px;
    }
    .buttons:hover {
        cursor: pointer;
    }
    .blog-card {
        display: flex;
        flex-direction: row;
        background: $white;
        box-shadow: 0 0.1875rem 1.5rem $shadow;
        border-radius: 0.375rem;
        overflow: hidden;
    }

    .card-link {
        position: relative;
        display: block;
        color: inherit;
        text-decoration: none;
        &:hover .post-title

    {
        @include transition(color 0.3s ease);
        color: $red;
    }

    &:hover .post-image {
        @include transition(opacity 0.3s ease);
        opacity: 0.9;
    }

    }

    .post-image {
        @include transition(opacity 0.3s ease);
        display: block;
        width: 100%;
        object-fit: cover;
    }

    .article-details {
        padding: 1.5rem;
    }

    .post-category {
        display: inline-block;
        text-transform: uppercase;
        font-size: 0.75rem;
        font-weight: 700;
        line-height: 1;
        letter-spacing: 0.0625rem;
        margin: 0 0 0.75rem 0;
        padding: 0 0 0.25rem 0;
        border-bottom: 0.125rem solid $border;
    }

    .post-title {
        @include transition(color 0.3s ease);
        font-size: 1.125rem;
        line-height: 1.4;
        color: $black;
        font-weight: 700;
        margin: 5px 0 0 0;
    }

    .post-author {
        font-size: 0.875rem;
        line-height: 1;
        margin: 1.125rem 0 0 0;
        padding: 1.125rem 0 0 0;
        border-top: 0.0625rem solid $border;
    }

    @media (max-width: 40rem) {
        #container {
            width: 18rem;
            height: 27.25rem;
        }

        .blog-card {
            flex-wrap: wrap;
        }
    }

    @supports (display: grid) {
        body {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            grid-gap: 0.625rem;
            grid-template-areas: ". main main ." ". main main .";
        }

        #container {
            grid-area: main;
            align-self: center;
            justify-self: center;
        }

        .post-image {
            height: 100%;
        }

        .blog-card {
            display: grid;
            grid-template-columns: 1fr 2fr;
            grid-template-rows: 1fr;
        }

        @media (max-width: 40rem) {
            .blog-card {
                grid-template-columns: auto;
                grid-template-rows: 12rem 1fr;
            }
        }
    }
</style>
