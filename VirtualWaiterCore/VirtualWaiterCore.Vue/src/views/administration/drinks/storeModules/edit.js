import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;
const state = {
    editDrink: {
        Id: null,
        Name: '',
        Description: '',
        Price: 0,
        TimeOfPreparation: 0,
        Image: '',
    }
};

const getters = {
    getField,
    getEditDrink(state) {
        return state.editDrink;
    },
    getImage(state) {
        return state.editDrink.Image;
    },
};

const mutations = {
    updateField,
    updateUserField(state, drink) {
        state.editDrink.Name = drink.Name;
        state.editDrink.Description = drink.Description;
        state.editDrink.Price = drink.Price;
        state.editDrink.TimeOfPreparation = drink.TimeOfPreparation;
        state.editDrink.Image = drink.Image;
    },
    setForm(state, payload) {
        state.editDrink.Id = payload.id;
        state.editDrink.Name = payload.name;
        state.editDrink.Description = payload.description;
        state.editDrink.Price = payload.price;
        state.editDrink.TimeOfPreparation = payload.timeOfPreparation;
        state.editDrink.Image = payload.image;
    },
    setImage(state, image) {
        state.editDrink.Image = image;
    },
    convertImage(state) {
        state.editDrink.Image = `data:image/png;base64,` +state.editDrink.Image;
    },
};

const actions = {
    editDrink({ state }, ) {
        axios.post('/drink/edit', state.editDrink).then(() => router.push({ name: 'administration.drinksList' }));
    },
    setDrinkForm({ commit }) {
        axios.get('/drink/getDrink/' + router.currentRoute.params.id).then(({ data }) => commit('setForm', data));
        commit('convertImage');
    },
    setDrinkForm2({ commit }, id) {
        axios.get('/drink/getDrink/' + id).then(({ data }) => commit('setForm', data));
        commit('convertImage');
    },
    setImage({ commit }, image) {
        commit('setImage', image);
    }

};

export default { namespaced , state, getters, mutations, actions };




