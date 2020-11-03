import axios from 'axios';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    appetizersList: null,
    Table: null,
    Products: []
};

const getters = {
    getField,
  getAppetizersList(state) {
        return state.appetizersList;
  },
};

const mutations = {
    updateField,
  setAppetizersList(state, payload) {
        state.appetizersList = payload;
  },
  addProductToCart(state, payload) {
      state.Products.push(payload) ;
  },
};

const actions = {
    setAppetizersList({commit}) {
        axios.get('/appetizer/getAppetizers')
            .then(({ data }) => commit('setAppetizersList', data));
    },
    deleteAppetizer({ dispatch }, id) {
        axios.delete('/appetizer/deleteAppetizer/' + id)
            .then(() => dispatch('setAppetizersList'));
    },
    addToCart({ commit }, id) {
        commit('addProductToCart', id)
    },
};

export default {namespaced, state, getters, mutations, actions };




