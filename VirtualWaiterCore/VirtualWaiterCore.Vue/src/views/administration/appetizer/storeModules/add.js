import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    Appetizer: {
        Name: '',
        Description: '',
        TimeOfPreparation: 0,
        Image: '',
        Price: 0,
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
    resetForm(state) {
        state.Appetizer.Name ='';
        state.Appetizer.Description = '';
        state.Appetizer.TimeOfPreparation = 0;
        state.Appetizer.Image = '';
        state.Appetizer.Price = 0;
    },
    setImage(state, image) {
        state.Appetizer.Image = image;
    },
};

const actions = {
    addAppetizer({ state }, ) {
        axios.post('/appetizer/add', state.Appetizer).then(() => router.push({ name: 'administration.appetizersList' }));
    },
    resetAppetizerForm({ commit }, ) {
        commit('resetForm');
    },
    setImage({ commit },image ) {
        commit('setImage', image);
    }

};

export default { namespaced, state, getters, mutations, actions };




