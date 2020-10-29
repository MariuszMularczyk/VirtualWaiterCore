import axios from 'axios';
const namespaced = true;

const state = {
    appetizersList: null
};

const getters = {
  getAppetizersList(state) {
        return state.appetizersList;
  },
};

const mutations = {
  setAppetizersList(state, payload) {
        state.appetizersList = payload;
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

};

export default {namespaced, state, getters, mutations, actions };




