import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    Dessert: {
        Name: '',
        Description: '',
        TimeOfPreparation: 0,
        Image: '',
        Price: 0,
    }
};

const getters = {
    getField,
    getDessert(state) {
        return state.Dessert;
    },
};

const mutations = {
    updateField,
    updateUserField(state, dessert) {
        state.Dessert.Name = dessert.Name;
        state.Dessert.Description = dessert.Description;
        state.Dessert.Price = dessert.Price;
        state.Dessert.TimeOfPreparation = dessert.TimeOfPreparation;
        state.Dessert.Image = dessert.Image;
    },
    resetForm(state) {
        state.Dessert.Name ='';
        state.Dessert.Description = '';
        state.Dessert.TimeOfPreparation = 0;
        state.Dessert.Image = '';
        state.Dessert.Price = 0;
    },
    setImage(state, image) {
        state.Dessert.Image = image;
    },
};

const actions = {
    addDessert({ state }, ) {
        axios.post('/dessert/add', state.Dessert).then(() => router.push({ name: 'administration.dessertsList' }));
    },
    resetDessertForm({ commit }, ) {
        commit('resetForm');
    },
    setImage({ commit },image ) {
        commit('setImage', image);
    }

};

export default { namespaced, state, getters, mutations, actions };




