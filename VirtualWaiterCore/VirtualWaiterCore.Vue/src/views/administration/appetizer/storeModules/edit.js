import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;
const state = {
    Appetizer: {
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
    getAppetizer(state) {
        return state.Appetizer;
    },
};

const mutations = {
    updateField,
    updateUserField(state, appetizer) {
        state.Appetizer.Name = appetizer.Name;
        state.Appetizer.Description = appetizer.Description;
        state.Appetizer.Price = appetizer.Price;
        state.Appetizer.TimeOfPreparation = appetizer.TimeOfPreparation;
        state.Appetizer.Image = appetizer.Image;
    },
    setForm(state, payload) {
        state.Appetizer.Id = payload.id;
        state.Appetizer.Name = payload.name;
        state.Appetizer.Description = payload.description;
        state.Appetizer.Price = payload.price;
        state.Appetizer.TimeOfPreparation = payload.timeOfPreparation;
        state.Appetizer.Image = payload.image;
    },
    setImage(state, image) {
        state.Appetizer.Image = image;
    },
    convertImage(state) {
        state.Appetizer.Image = `data:image/png;base64,` + state.Appetizer.Image;
    },
};

const actions = {
    editAppetizer({ state }, ) {
        axios.post('/appetizer/edit', state.Appetizer).then(() => router.push({ name: 'administration.appetizersList' }));
    },
    setAppetizerForm({ commit }) {
        axios.get('/appetizer/getAppetizer/' + router.currentRoute.params.id).then(({ data }) => commit('setForm', data));
        commit('convertImage');
    },
    setImage({ commit }, image) {
        commit('setImage', image);
    }

};

export default { namespaced , state, getters, mutations, actions };




