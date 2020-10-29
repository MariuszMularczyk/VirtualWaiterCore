import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;
const state = {
    MainCourse: {
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
    getMainCourse(state) {
        return state.MainCourse;
    },
};

const mutations = {
    updateField,
    updateUserField(state, mainCourse) {
        state.MainCourse.Name = mainCourse.Name;
        state.MainCourse.Description = mainCourse.Description;
        state.MainCourse.Price = mainCourse.Price;
        state.MainCourse.TimeOfPreparation = mainCourse.TimeOfPreparation;
        state.MainCourse.Image = mainCourse.Image;
    },
    setForm(state, payload) {
        state.MainCourse.Id = payload.id;
        state.MainCourse.Name = payload.name;
        state.MainCourse.Description = payload.description;
        state.MainCourse.Price = payload.price;
        state.MainCourse.TimeOfPreparation = payload.timeOfPreparation;
        state.MainCourse.Image = payload.image;
    },
    setImage(state, image) {
        state.MainCourse.Image = image;
    },
    convertImage(state) {
        state.MainCourse.Image = `data:image/png;base64,` + state.MainCourse.Image;
    },
};

const actions = {
    editMainCourse({ state }, ) {
        axios.post('/mainCourse/edit', state.MainCourse).then(() => router.push({ name: 'administration.mainCoursesList' }));
    },
    setMainCourseForm({ commit }) {
        axios.get('/mainCourse/getMainCourse/' + router.currentRoute.params.id).then(({ data }) => commit('setForm', data));
        commit('convertImage');
    },
    setImage({ commit }, image) {
        commit('setImage', image);
    }

};

export default { namespaced , state, getters, mutations, actions };




