<template>
    <div>
        <h1>Kucharz {{index+1}}</h1>
        <vs-card-group>
            <div v-if="!item.length" style="text-align: center;">
                <svg id="Layer_1" height="112" viewBox="0 0 150 150" width="112" xmlns="http://www.w3.org/2000/svg" data-name="Layer 1"><circle cx="75" cy="75" fill="#21b3a9" r="64" /><path d="m115.63 82.2a4.94 4.94 0 0 0 -4.94-4.94 4.94 4.94 0 0 0 4.92-5.42 5.09 5.09 0 0 0 -5.13-4.46h-17.09l-.39-2 5-5.38a21.15 21.15 0 0 0 4.64-7.78 6.68 6.68 0 0 0 .37-1.45c.26-5.71-2.64-8.5-5.31-8.72-.72-.06-1.4-.29-1.83.29-2.39 6.7-5.77 11-9.94 13.44l-13.16 11.73-12.09 6.72-.74 28.77 14.06 3.9.5-.21v.21h36a5.09 5.09 0 0 0 5.13-4.46 4.94 4.94 0 0 0 -4.94-5.44 4.94 4.94 0 0 0 0-9.88 4.94 4.94 0 0 0 4.94-4.92z" fill="#fcd462" /><path d="m34.37 69.09h32.49v39.01h-32.49z" fill="#3a556a" /></svg>
                <h1 style="text-align:center">Wszystkie zamówienia wydane</h1>
            </div>
            <vs-card v-for="order in  item " :key="`${order.id}`">
                <template #title>
                    <h3>Stolik nr {{order.table}}</h3>
                    <h1>{{order.productTypeName}}</h1>
                </template>
                <template #text>
                    <div>
                        <h3>
                            {{order.productName}}
                        </h3>
                        <br />
                        <vs-button square
                                   success
                                   flat
                                   @click.prevent="readyToPickUp(order)">
                            <h4>Zrobione!!</h4>
                        </vs-button>
                    </div>
                </template>
            </vs-card>
        </vs-card-group>
    </div>
</template>

<script>
    export default {
        name: "ItemList",
        props: ['item', 'index'],
        data() {
            return {
            }
        },
        computed: {
        },
        methods: {
            readyToPickUp(item) {
                this.$emit('readyToPickUp', item)
            },

        },
        mounted() {

        },
    }
</script>

<style scoped lang="scss">
    @import url('https://fonts.googleapis.com/css?family=Roboto:400,700');

   
    .buttons {
        width: 50px;
        height: 50px;
    }

    #style-1::-webkit-scrollbar-track {
        -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
        border-radius: 10px;
        background-color: #F5F5F5;
    }

</style>
