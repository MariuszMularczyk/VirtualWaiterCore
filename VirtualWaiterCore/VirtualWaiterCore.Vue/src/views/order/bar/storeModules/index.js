import axios from 'axios';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    drinksOrderList: null,
};

const getters = {
    getField,
  getDrinksOrdersList(state) {
    return state.ordersList;
  },
};

const mutations = {
    updateField,
    setDrinksOrderList(state, payload) {
        state.drinksOrderList = payload;
  },

};

const actions = {
    setDrinksOrderList({commit}) {
        axios.get('/order/getDrinksOrder')
            .then(({ data }) => commit('setDrinksOrderList', data));
    },

};

export default {namespaced, state, getters, mutations, actions };




