import axios from 'axios';
const namespaced = true;

const state = {
    mainCoursesList: null
};

const getters = {
  getMainCoursesList(state) {
        return state.mainCoursesList;
  },
};

const mutations = {
  setMainCoursesList(state, payload) {
        state.mainCoursesList = payload;
  },

};

const actions = {
    setMainCoursesList({commit}) {
        axios.get('/mainCourse/getMainCourses')
            .then(({ data }) => commit('setMainCoursesList', data));
    },
    deleteMainCourse({ dispatch }, id) {
        axios.delete('/mainCourse/deleteMainCourse/' + id)
            .then(() => dispatch('setMainCoursesList'));
    },
};

export default {namespaced, state, getters, mutations, actions };




