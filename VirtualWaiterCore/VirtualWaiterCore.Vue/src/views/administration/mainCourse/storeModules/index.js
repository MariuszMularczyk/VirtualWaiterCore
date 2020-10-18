import axios from 'axios';
const namespaced = true;

const state = {
    drinksList: null
};

const getters = {
  getDrinksList(state) {
        return state.drinksList;
  },
};

const mutations = {
  setDrinksList(state, payload) {
        state.drinksList = payload;
  },

};

const actions = {
    setDrinksList({commit}) {
        axios.get('/drink/getDrinks')
            .then(({ data }) => commit('setDrinksList', data));
    },

};

export default {namespaced, state, getters, mutations, actions };




