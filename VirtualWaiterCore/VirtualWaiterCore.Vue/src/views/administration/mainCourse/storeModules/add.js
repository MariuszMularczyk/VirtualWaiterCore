import axios from 'axios';
import router from '@/router/index';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    MainCourse: {
        Name: '',
        Description: '',
        TimeOfPreparation: 0,
        Image: '',
        Price: 0,
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
    resetForm(state) {
        state.MainCourse.Name ='';
        state.MainCourse.Description = '';
        state.MainCourse.TimeOfPreparation = 0;
        state.MainCourse.Image = '';
        state.MainCourse.Price = 0;
    },
    setImage(state, image) {
        state.MainCourse.Image = image;
    },
};

const actions = {
    addMainCourse({ state }, ) {
        axios.post('/mainCourse/add', state.MainCourse).then(() => router.push({ name: 'administration.mainCoursesList' }));
    },
    resetMainCourseForm({ commit }, ) {
        commit('resetForm');
    },
    setImage({ commit },image ) {
        commit('setImage', image);
    }

};

export default { namespaced, state, getters, mutations, actions };




