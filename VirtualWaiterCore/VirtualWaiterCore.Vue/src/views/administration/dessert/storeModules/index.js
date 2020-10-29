import axios from 'axios';
const namespaced = true;

const state = {
    dessertList: null
};

const getters = {
  getDessertsList(state) {
        return state.dessertList;
  },
};

const mutations = {
  setDessertsList(state, payload) {
        state.dessertList = payload;
  },

};

const actions = {
    setDessertsList({commit}) {
        axios.get('/dessert/getDesserts')
            .then(({ data }) => commit('setDessertsList', data));
    },
    deleteDessert({ dispatch }, id) {
        axios.delete('/dessert/deleteDessert/' + id)
            .then(() => dispatch('setDessertsList'));
    },
};

export default {namespaced, state, getters, mutations, actions };




