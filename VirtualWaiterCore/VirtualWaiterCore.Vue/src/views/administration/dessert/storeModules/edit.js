import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;
const state = {
    Dessert: {
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
    getDessert(state) {
        return state.Dessert;
    },
};

const mutations = {
    updateField,
    updateUserField(state, drink) {
        state.Dessert.Name = drink.Name;
        state.Dessert.Description = drink.Description;
        state.Dessert.Price = drink.Price;
        state.Dessert.TimeOfPreparation = drink.TimeOfPreparation;
        state.Dessert.Image = drink.Image;
    },
    setForm(state, payload) {
        state.Dessert.Id = payload.id;
        state.Dessert.Name = payload.name;
        state.Dessert.Description = payload.description;
        state.Dessert.Price = payload.price;
        state.Dessert.TimeOfPreparation = payload.timeOfPreparation;
        state.Dessert.Image = payload.image;
    },
    setImage(state, image) {
        state.Dessert.Image = image;
    },
    convertImage(state) {
        state.Dessert.Image = `data:image/png;base64,` + state.Dessert.Image;
    },
};

const actions = {
    editDessert({ state }, ) {
        axios.post('/drink/edit', state.Dessert).then(() => router.push({ name: 'administration.drinksList' }));
    },
    setDessertForm({ commit }) {
        axios.get('/dessert/getDessert/' + router.currentRoute.params.id).then(({ data }) => commit('setForm', data));
        commit('convertImage');
    },
    setImage({ commit }, image) {
        commit('setImage', image);
    }

};

export default { namespaced , state, getters, mutations, actions };




