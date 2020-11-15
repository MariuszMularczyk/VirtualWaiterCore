import axios from 'axios';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    ordersList: null,
};

const getters = {
    getField,
  getOrdersList(state) {
    return state.ordersList;
  },
};

const mutations = {
    updateField,
  setOrderssList(state, payload) {
      state.ordersList = payload;
  },

};

const actions = {
    setOrdersList({commit}) {
        axios.get('/order/getOrders')
            .then(({ data }) => commit('setOrderssList', data));
    },

};

export default {namespaced, state, getters, mutations, actions };




