import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    Drink: {
        Name: '',
        Description: '',
        TimeOfPreparation: 0,
        Image: '',
        Price: 0,
    }
};

const getters = {
    getField,
    getDrink(state) {
        return state.Drink;
    },
};

const mutations = {
    updateField,
    updateUserField(state, drink) {
        state.Drink.Name = drink.Name;
        state.Drink.Description = drink.Description;
        state.Drink.Price = drink.Price;
        state.Drink.TimeOfPreparation = drink.TimeOfPreparation;
        state.Drink.Image = drink.Image;
    },
    resetForm(state) {
        state.Drink.Name ='';
        state.Drink.Description = '';
        state.Drink.TimeOfPreparation = 0;
        state.Drink.Image = '';
        state.Drink.Price = 0;
    },
    setImage(state, image) {
        state.Drink.Image = image;
    },
};

const actions = {
    addDrink({ state }, ) {
        axios.post('/drink/add', state.Drink).then(() => router.push({ name: 'administration.drinksList' }));
    },
    resetDrinkForm({ commit }, ) {
        commit('resetForm');
    },
    setImage({ commit },image ) {
        commit('setImage', image);
    }

};

export default { namespaced, state, getters, mutations, actions };




